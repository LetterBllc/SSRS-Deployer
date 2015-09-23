// -----------------------------------------------
//   Author:     Hung Vo ( it.minhhung@gmail.com )
//   Modified:   2014/12/18
// -----------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using SSRSDeployerTool.SSRSWebService;

namespace SSRSDeployerTool
{
    public class ReportDeployHelper
    {
        private readonly ReportingService2005 _rs = new ReportingService2005();

        public ReportDeployHelper(string domain, string userName, string password, string reportService)
        {
            this._rs = new ReportingService2005
            {
                Url = reportService,
                Credentials = new NetworkCredential(userName, password, domain)
            };
        }

        public void DeployReport(string reportPath, string folderPath, Dictionary<string, string> dicRdlDataSources)
        {
            var reportDeployedFullPath = string.Empty;
            if (File.Exists(reportPath))
            {
                var fileName = Path.GetFileName(reportPath);

                var stream = File.OpenRead(reportPath);
                var reportDefinition = new Byte[stream.Length];
                stream.Read(reportDefinition, 0, (int)stream.Length);
                stream.Close();

                if (fileName != null)
                {
                    reportDeployedFullPath = string.Format("{0}/{1}", folderPath, Path.GetFileNameWithoutExtension(fileName));
                    this._rs.CreateReport(Path.GetFileNameWithoutExtension(fileName), folderPath, true, reportDefinition, null);
                }
                else
                {
                    throw new Exception(string.Format("File not found or can't get file name from path: {0}", reportPath));
                }
            }

            DataSource[] reportDsns = this._rs.GetItemDataSources(reportDeployedFullPath);

            foreach (var dataSource in reportDsns)
            {
                foreach (var dataSourcePath in dicRdlDataSources)
                {
                    if (string.IsNullOrEmpty(folderPath))
                    {
                        throw new Exception("Please input folder path");
                    }

                    //folder Name: /MSI Report Demo
                    folderPath = folderPath.BuildPath();

                    if (string.IsNullOrEmpty(dataSourcePath.Value))
                    {
                        throw new Exception("Please input data source path");
                    }

                    var dsnPath = dataSourcePath.Value.BuildPath();

                    if (dataSourcePath.Key.ToLower().Trim() == dataSource.Name.ToLower().Trim())
                    {
                        var reference = new DataSourceReference
                        {
                            Reference = dsnPath
                        };

                        dataSource.Item = reference;

                        break;
                    }
                }
            }

            foreach (var dataSource in reportDsns)
            {
                if (dataSource.Item is InvalidDataSourceReference)
                {
                    Utils.AddLog(string.Format("{0}{1}InvalidDataSourceReference: Please check '{2}' datasource{3}", Environment.NewLine, Environment.NewLine, dataSource.Name, Environment.NewLine), Utils.MessageType.WARNING);
                }
            }
            this._rs.SetItemDataSources(reportDeployedFullPath, reportDsns);
        }

        public Dictionary<string, string> GetDataSourceFromRdlFile(string reportPath, Dictionary<string, string> listDsPaths)
        {
            if (!File.Exists(reportPath))
            {
                throw new Exception("Please input report path");
            }

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

            var dicDs = new Dictionary<string, string>();

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
                                var name = string.Empty;
                                var referenceName = string.Empty;

                                if (ds.Attributes != null && ds.Attributes["Name"] != null)
                                {
                                    name = ds.Attributes["Name"].Value;
                                }

                                foreach (var childOfDs in ds.ChildNodes.Cast<XmlNode>().Where(childOfDs => childOfDs.Name == "DataSourceReference"))
                                {
                                    referenceName = childOfDs.InnerText;
                                    break;
                                }

                                if (!string.IsNullOrWhiteSpace(name) && !dicDs.ContainsKey(name))
                                {
                                    dicDs.Add(name.ToLower(), referenceName.ToLower());
                                }
                            }
                        }
                    }
                }
            }

            var retVal = new Dictionary<string, string>();
            foreach (var dicD in dicDs)
            {
                var key = dicD.Key.ToLower();
                string value = string.Empty;

                if (listDsPaths.ContainsKey(dicD.Value))
                {
                    value = listDsPaths[dicD.Value];
                }

                if (!retVal.ContainsKey(key) && !string.IsNullOrEmpty(value))
                {
                    retVal.Add(key, value);
                }
            }
            return retVal;
        }

        public void DeployResource(string resourcePath, string folderPath)
        {
            try
            {
                if (File.Exists(resourcePath))
                {
                    var fileName = Path.GetFileName(resourcePath);

                    var extension = Path.GetExtension(fileName);

                    if (fileName != null && extension != null)
                    {
                        string result = fileName.Substring(0, fileName.Length - extension.Length);

                        var stream = File.OpenRead(resourcePath);
                        var fileContent = new Byte[stream.Length];

                        stream.Read(fileContent, 0, (int)stream.Length);

                        stream.Close();

                        this._rs.CreateResource(string.Format("{0}{1}", result, extension), folderPath, true, fileContent, Utils.GetMimeType(extension), null);
                    }
                }
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public void CreateDataSource(string datasourceName, string datasourcePath, string connectDs, string connectDatabase, string connUsername, string connPass)
        {
            // /MSI Report Demo/Data Sources
            datasourcePath = datasourcePath.Replace(@"\", "/");
            while (datasourcePath.Contains("//"))
            {
                datasourcePath = datasourcePath.Replace("//", "/");
            }

            datasourcePath = datasourcePath.TrimStart('/').TrimEnd('/').Trim();
            datasourcePath = string.Format("/{0}", datasourcePath);

            var dSource = new DataSource();
            var dDefinition = new DataSourceDefinition();

            //if (!CheckExist(ItemTypeEnum.Folder, "/", "Data Sources"))
            //{
            //    rs.CreateFolder("Data Sources", "/", null);
            //}

            //if (!CheckExist(ItemTypeEnum.Folder, "/MSI Report Demo", "/Data Sources"))
            //{
            //    rs.CreateFolder("Data Sources", "/MSI Report Demo", null);
            //}

            dSource.Item = dDefinition;
            dDefinition.Extension = "SQL";
            dDefinition.ConnectString = string.Format("{0}{1};Initial Catalog={2}", @"Data Source=", connectDs, connectDatabase);
            dDefinition.UserName = connUsername;
            dDefinition.Password = connPass;

            Trace.WriteLine(dDefinition.ConnectString);

            dDefinition.ImpersonateUserSpecified = true;
            dDefinition.Prompt = null;
            dDefinition.WindowsCredentials = false;
            dDefinition.CredentialRetrieval = CredentialRetrievalEnum.Store;
            dSource.Name = datasourceName;

            //if (!CheckExist(ItemTypeEnum.DataSource, "/MSI Report Demo/Data Sources", "/" + dataSourceName))
            //{
            this._rs.CreateDataSource(datasourceName, datasourcePath, true, dDefinition, null);   // overwrite, so, don't check exists datassouce  
            //}
        }

        public void CreateFolder(string item)
        {
            item = item.Replace("\\", "/");

            var result = item.Split('/').ToList();

            result.RemoveAll(String.IsNullOrEmpty);

            for (var i = 0; i < result.Count; i++)
            {
                string path;

                if (i == 0)
                {
                    path = "/";
                }
                else
                {
                    string buildPath = string.Empty;
                    for (var x = 0; x < i; x++)
                    {
                        if (!string.IsNullOrWhiteSpace(result[x]))
                        {
                            buildPath += string.Format("/{0}", result[x]);
                        }
                    }

                    path = buildPath;
                }

                var name = result[i].Trim();

                if (string.IsNullOrWhiteSpace(path))
                {
                    path = "/";
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!this.CheckExist(ItemTypeEnum.Folder, path, name))
                    {
                        this._rs.CreateFolder(name, path, null);
                    }
                }
            }
        }

        /// Checks if the folder exists or not.
        /// <param name="type"></param>
        /// <param name="path">Parent folder path</param>
        /// <param name="folderName">Name of the folder to search</param>
        /// <returns>True if found, else false.</returns>
        public bool CheckExist(ItemTypeEnum type, string path, string folderName)
        {
            var tempPath = Path.Combine(path, folderName).Replace(@"\", "/");

            // Condition criteria.

            // Condition criteria.
            var condition = new SearchCondition
            {
                Condition = ConditionEnum.Contains,
                ConditionSpecified = true,
                Name = "Name",
                Value = ""
            };
            var conditions = new SearchCondition[1];
            conditions[0] = condition;

            var returnedItems = this._rs.FindItems(path, BooleanOperatorEnum.Or, conditions);
            
            // Iterate thro' each report properties to get the path.
            foreach (var item in returnedItems)
            {
                if (item.Type == type)
                {
                    if (item.Path.Trim().ToLower() == tempPath.Trim().ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}