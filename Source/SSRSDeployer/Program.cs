using SSRSDeployer.SSRSWebService;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;

namespace SSRSDeployer
{
    internal class Program
    {
        private static BackgroundWorker bgwDS;
        private static BackgroundWorker bgwFolders;
        private static ReportingService2005 rs;

        private static void CheckExistsDataSource(string dataSource, string connectionString, string userName)
        {
            CatalogItem[] target = rs.ListChildren("/", true);
            bool chk = false;
            foreach (var item in target)
            {
                if (item.Type == ItemTypeEnum.DataSource)
                {
                    if (item.Path == dataSource)
                    {
                        chk = true;
                        break;
                    }
                    else
                    {
                        chk = false;
                    }
                }
            }
            DataSourceDefinition definition = new DataSourceDefinition();
            definition.Extension = "SQL";
            definition.ConnectString = connectionString;
            definition.UseOriginalConnectString = false;
            definition.CredentialRetrieval = CredentialRetrievalEnum.Store;
            definition.WindowsCredentials = false;
            definition.UserName = userName;
            definition.Enabled = true;
            if (chk == false)
            {
                int c = dataSource.IndexOf("/");
                if (c != -1)
                {
                    string[] arr = dataSource.Split('/');
                    string dsName = arr.Last();
                    bool ck = false;
                    string parent = "";
                    string dic = "";
                    foreach (string item in arr)
                    {
                        if (item != "")
                        {
                            dic += item + "/";
                            foreach (var it in target)
                            {
                                if (it.Type == ItemTypeEnum.Folder)
                                {
                                    if (it.Path + "/" == "/" + dic)
                                    {
                                        ck = true;
                                        parent += it.Path;
                                        break;
                                    }
                                    else
                                    {
                                        if (dic.Length - (item.Length + 2) < 0)
                                        {
                                            parent = "/" + dic.Substring(0, dic.Length - (item.Length + 1));
                                        }
                                        else
                                        {
                                            parent = "/" + dic.Substring(0, dic.Length - (item.Length + 2));
                                        }
                                        ck = false;
                                    }
                                }
                            }
                            if (ck == false)
                            {
                                if (item == dsName)
                                {
                                    rs.CreateDataSource(item, parent, false, definition, null);
                                }
                                else
                                {
                                    rs.CreateFolder(item, parent, null);
                                }
                            }
                        }
                    }
                }
                else
                {
                    rs.CreateDataSource(dataSource, "/", false, definition, null);
                }
            }
            else
            {
                if (connectionString != "")
                {
                    DataSourceDefinition dsDef = rs.GetDataSourceContents(dataSource);
                    dsDef.ConnectString = connectionString;
                    rs.SetDataSourceContents(dataSource, dsDef);
                }
            }
        }

        private static void CheckExistsTargetFolder(string folder)
        {
            CatalogItem[] target = rs.ListChildren("/", true);
            bool chk = false;
            foreach (var item in target)
            {
                if (item.Type == ItemTypeEnum.Folder)
                {
                    if (item.Path == folder)
                    {
                        chk = true;
                        break;
                    }
                    else
                    {
                        chk = false;
                    }
                }
            }
            if (chk == false)
            {
                int c = folder.IndexOf("/");
                if (c != -1)
                {
                    string[] arr = folder.Split('/');
                    bool ck = false;
                    string parent = "";
                    string dic = "";
                    foreach (string item in arr)
                    {
                        if (item != "")
                        {
                            dic += item + "/";
                            foreach (var it in target)
                            {
                                if (it.Type == ItemTypeEnum.Folder)
                                {
                                    if (it.Path + "/" == "/" + dic)
                                    {
                                        ck = true;
                                        parent += it.Path;
                                        break;
                                    }
                                    else
                                    {
                                        if (dic.Length - (item.Length + 2) < 0)
                                        {
                                            parent = "/" + dic.Substring(0, dic.Length - (item.Length + 1));
                                        }
                                        else
                                        {
                                            parent = "/" + dic.Substring(0, dic.Length - (item.Length + 2));
                                        }
                                        ck = false;
                                    }
                                }
                            }
                            if (ck == false)
                            {
                                rs.CreateFolder(item, parent, null);
                            }
                        }
                    }
                }
                else
                {
                    rs.CreateFolder(folder, "/", null);
                }
            }
        }

        private static string DeployModel(string localPath, string serverPath, string dataSource)
        {
            byte[] definition = null;
            Warning[] warnings = null;
            string retRes = String.Empty;

            try
            {
                // Read the file and put it into a byte array to pass to SRS
                FileStream stream = File.OpenRead(localPath);
                definition = new byte[stream.Length];
                stream.Read(definition, 0, (int)(stream.Length));
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // We are going to use the name of the rdl file as the name of our report
            string reportName = Path.GetFileNameWithoutExtension(localPath);

            // Now lets use this information to publish the report
            try
            {
                warnings = rs.CreateModel(reportName, serverPath, definition, null);

                if (warnings != null)
                {
                    retRes = String.Format("Report {0} failed with warnings :\n", reportName);
                    foreach (Warning warning in warnings)
                    {
                        retRes += warning.Message + "\n";
                    }
                }
                else
                {
                    retRes = String.Format("Report {0} created successfully with no warnings\n", reportName);
                }

                //set the datasource
                DataSourceReference dsr = new DataSourceReference();
                dsr.Reference = dataSource;

                DataSource[] dsarray = rs.GetItemDataSources(serverPath + "/" + reportName);
                DataSource ds = new DataSource();
                if (dsarray.Length > 0)
                {
                    ds = dsarray[0];
                    ds.Item = (DataSourceReference)dsr;
                    rs.SetItemDataSources(serverPath + "/" + reportName, dsarray);
                    retRes += String.Format("Data source succesfully set to {0}\n", dsr.Reference);
                }
            }
            catch (SoapException ex)
            {
                return String.Format("Report {0} failed with exception {1}\n", reportName, ex.Detail.InnerXml.ToString());
            }

            return retRes;
        }

        private static string DeployReport(string localPath, string serverPath, string dataSource)
        {
            byte[] definition = null;
            Warning[] warnings = null;
            string retRes = String.Empty;

            try
            {
                // Read the file and put it into a byte array to pass to SRS
                FileStream stream = File.OpenRead(localPath);
                definition = new byte[stream.Length];
                stream.Read(definition, 0, (int)(stream.Length));
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // We are going to use the name of the rdl file as the name of our report
            string reportName = Path.GetFileNameWithoutExtension(localPath);

            // Now lets use this information to publish the report
            try
            {
                warnings = rs.CreateReport(reportName, serverPath, true, definition, null);

                if (warnings != null)
                {
                    retRes = String.Format("Report {0} created with warnings :\n", reportName);
                    foreach (Warning warning in warnings)
                    {
                        retRes += warning.Message + "\n";
                    }
                }
                else
                {
                    retRes = String.Format("Report {0} created successfully with no warnings\n", reportName);
                }

                // check xml datasource
                var isXmlProvider = IsXmlDataProvider(localPath);
                if (isXmlProvider)
                {
                    return retRes;
                }

                //set the datasource
                DataSourceReference dsr = new DataSourceReference();
                dsr.Reference = dataSource;

                DataSource[] dsarray = rs.GetItemDataSources(serverPath + "/" + reportName);
                DataSource ds = new DataSource();
                if (dsarray.Length > 0)
                {
                    ds = dsarray[0];
                    ds.Item = (DataSourceReference)dsr;
                    rs.SetItemDataSources(serverPath + "/" + reportName, dsarray);
                    retRes += String.Format("Data source succesfully set to {0}\n", dsr.Reference);
                }
            }
            catch (SoapException ex)
            {
                return String.Format("Report {0} failed with exception {1}\n", reportName, ex.Detail.InnerXml.ToString());
            }

            return retRes;
        }

        private static void DoLoggingStuff(StringBuilder result)
        {
            string path = Path.GetTempFileName();
            File.AppendAllText(path, result.ToString());
            File.Move(path, path + ".txt");
            Process.Start(path + ".txt");
        }

        private static void InitSSRS(string rsUrl, string username, string password, string domain)
        {
            rs = new ReportingService2005();
            rs.Credentials = new NetworkCredential(username, password, domain);
            rs.Url = rsUrl + "/ReportService2005.asmx";
        }

        private static bool IsXmlDataProvider(string reportPath)
        {
            var fs = File.OpenRead(reportPath);
            var b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();

            XmlDocument xmldoc;

            using (var ms = new MemoryStream(b))
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(ms);
                ms.Close();
            }

            XmlNode root = xmldoc.DocumentElement;

            // Get all the elements under the root node.
            if (root != null)
            {
                var nodes = root.SelectNodes("descendant::*");

                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        if (node.Name == "DataSources") // Search for Report Parameters
                        {
                            var listDataSource = node.ChildNodes;
                            foreach (XmlNode ds in listDataSource)
                            {
                                foreach (XmlNode child in ds.ChildNodes)
                                {
                                    if (child.Name == "ConnectionProperties")
                                    {
                                        foreach (XmlNode xmlNode in child.ChildNodes)
                                        {
                                            if (xmlNode.Name == "DataProvider" && xmlNode.InnerText.ToUpper().Trim() == "XML")
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static void Main(string[] args)
        {
            bgwFolders = new BackgroundWorker();
            bgwDS = new BackgroundWorker();
            SSRSDeployConfigSection section = (SSRSDeployConfigSection)ConfigurationManager.GetSection("ssrsdeploy");
            if (section != null)
            {
                Console.WriteLine(string.Format("Connecting report server {0}\n", section.Target));
                InitSSRS(section.Target, section.UserName, section.Password, section.Domain);
                bgwFolders.RunWorkerAsync(rs);
                StringBuilder result = new StringBuilder();
                int count = 0;
                foreach (SSRSDeployFolderElement item in section.FolderItems)
                {
                    CheckExistsTargetFolder(item.Target);
                    CheckExistsDataSource(item.Datasource, item.ConnectionString, section.UserName);
                    object[] arguments = new object[2];
                    arguments[0] = rs;
                    arguments[1] = item.Datasource;
                    bgwDS.RunWorkerAsync(arguments);

                    DirectoryInfo dInfo = new DirectoryInfo(item.Path);
                    FileInfo[] Files = dInfo.GetFiles();
                    foreach (FileInfo file in Files)
                    {
                        if (Path.GetExtension(file.Name).ToUpper() == ".RDL")
                        {
                            result.AppendLine("Starting deployement of report " + file.Name);
                            Console.WriteLine("Starting deployement of report " + file.Name);
                            string ret = DeployReport(file.FullName, item.Target, item.Datasource);
                            result.AppendLine(ret);
                            Console.WriteLine(ret);
                            count++;
                        }
                        else if (Path.GetExtension(file.Name).ToUpper() == ".SMDL")
                        {
                            result.AppendLine("Starting deployement of model " + file.Name);
                            Console.WriteLine("Starting deployement of model " + file.Name);
                            string ret = DeployModel(file.FullName, item.Target, item.Datasource);
                            result.AppendLine(ret);
                            Console.WriteLine(ret);
                            count++;
                        }
                    }
                }
                result.AppendLine("Job completed");
                Console.WriteLine("Job completed");
                result.AppendLine(string.Format("Deployed total of {0} reports", count.ToString()));
                Console.WriteLine(string.Format("Deployed total of {0} reports", count.ToString()));
                DoLoggingStuff(result);
            }
        }
    }
}