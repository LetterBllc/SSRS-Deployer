// -----------------------------------------------
//   Author:     Hung Vo ( it.minhhung@gmail.com )
//   Modified:   2014/12/18
// -----------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SSRSDeployerTool
{
    internal class Program
    {
        private static void DoLoggingStuff()
        {
            //string tempFileName = Path.GetTempFileName();
            var folderPath = string.Format("{0}\\Logs", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            var tempFileName = string.Format("{0}\\log{1}.txt", folderPath, DateTime.Now.ToString("-yyMMdd-HHmm"));

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            File.WriteAllText(tempFileName, Utils.LogInfo.ToString());

            var isShowLog = false;

            if (ConfigurationManager.AppSettings.Get("ShowLogCompleted") != null)
            {
                isShowLog = ConfigurationManager.AppSettings.Get("ShowLogCompleted").ToUpper().Trim() == "TRUE";
            }

            if (isShowLog)
            {
                Process.Start(tempFileName);
            }
        }

        private static void Main(string[] args)
        {
            var ssrsSection = (SsrsDeploy)ConfigurationManager.GetSection("ssrsDeploy");

            // check service
            if (ssrsSection != null)
            {
                var rptGroups = ssrsSection.ReportGroups;

                var reportHelper = new ReportDeployHelper(ssrsSection.Domain, ssrsSection.Username, ssrsSection.Password, ssrsSection.ReportServiceUrl);

                reportHelper.CreateFolder("/~tmp-");

                Utils.AddLog(string.Format("{0}CHECK REPORT SERVICE: OK{1}", Environment.NewLine, Environment.NewLine), Utils.MessageType.INFO);

                if (rptGroups != null && rptGroups.Count > 0)
                {
                    foreach (SsrsReportGroup group in rptGroups)
                    {
                        // create deploy target folder
                        reportHelper.CreateFolder(group.Target);

                        var dicDataSource = new Dictionary<string, string>(); // name | path

                        // create datasource folders & deploy datasource
                        foreach (SsrsDataSource ds in group.DataSources)
                        {
                            var conn = ds.ConnectionString;
                            var connBuilder = new SqlConnectionStringBuilder(conn);

                            reportHelper.CreateFolder(ds.DatasourcePathWithName.GetPath());

                            reportHelper.CreateDataSource(ds.DatasourcePathWithName.GetName(), ds.DatasourcePathWithName.GetPath(),
                                connBuilder.DataSource, connBuilder.InitialCatalog,
                                connBuilder.UserID, connBuilder.Password);

                            dicDataSource.Add(ds.DatasourcePathWithName.GetName().ToLower(), string.Format("{0}/{1}", ds.DatasourcePathWithName.GetPath(), ds.DatasourcePathWithName.GetName()));
                        }

                        // deploy all report in group
                        var rdlFiles = new DirectoryInfo(group.Source).GetFilesByExtensions(".rdl");
                        foreach (var rdl in rdlFiles)
                        {
                            try
                            {
                                var strCurrentName = string.Format("{0}/{1}... ", group.Target.Trim('/'), Path.GetFileName(rdl.FullName));
                                Utils.AddLog(string.Format("{0}=> {1}", Environment.NewLine, strCurrentName), Utils.MessageType.MESSAGE, false);

                                var dic = reportHelper.GetDataSourceFromRdlFile(rdl.FullName, dicDataSource);

                                reportHelper.DeployReport(rdl.FullName, group.Target.BuildPath(), dic);

                                Utils.AddLog("Done!", Utils.MessageType.INFO, false);
                            }
                            catch (Exception)
                            {
                                Utils.AddLog(string.Format("Error :({0}", Environment.NewLine), Utils.MessageType.ERROR, false);
                                throw;
                            }
                        }

                        // deploy resources 
                        var imgTypes = ConfigurationManager.AppSettings["imgTypeSupport"];
                        var allowDeployImages = ConfigurationManager.AppSettings["AllowDeployImages"];
                        var bDeployImage = false;
                        if (imgTypes == null || !imgTypes.Split('|').Any())
                        {
                            imgTypes = ".jpg|.bmp|.png|.gif";
                        }

                        if (!string.IsNullOrEmpty(allowDeployImages))
                        {
                            if (allowDeployImages.ToUpper().Trim() == "TRUE")
                            {
                                bDeployImage = true;
                            }
                        }

                        if (bDeployImage)
                        {
                            var imgFiles = new DirectoryInfo(group.Source).GetFilesByExtensions(imgTypes.Split('|'));

                            foreach (var imgFile in imgFiles)
                            {
                                try
                                {
                                    var strCurrentName = string.Format("{0}/{1}... ", group.Target.Trim('/'), Path.GetFileName(imgFile.FullName));
                                    Utils.AddLog(string.Format("{0}=> {1}", Environment.NewLine, strCurrentName), Utils.MessageType.MESSAGE, false);

                                    reportHelper.DeployResource(imgFile.FullName, group.Target);

                                    Utils.AddLog("Done!", Utils.MessageType.INFO, false);
                                }
                                catch (Exception)
                                {
                                    Utils.AddLog(string.Format("Error :({0}", Environment.NewLine), Utils.MessageType.ERROR, false);
                                    throw;
                                }
                            }
                        }

                        Utils.AddLog(Environment.NewLine, Utils.MessageType.INFO);
                    }

                    Utils.AddLog(string.Format("{0}{1}=> REPORTS DEPLOYED SUCCESSFULLY!", Environment.NewLine, Environment.NewLine), Utils.MessageType.INFO);
                }
                else
                {
                    Utils.AddLog("Please config folder section", Utils.MessageType.WARNING);
                }
            }

            DoLoggingStuff();
        }
    }
}