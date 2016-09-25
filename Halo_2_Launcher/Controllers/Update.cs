using Halo_2_Launcher.Objects;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Halo_2_Launcher.Controllers
{
    
    
    public class UpdateController
    {
        private UpdateCollection _RemoteUpdateCollection;
        private UpdateCollection _LocalUpdateCollection;
        private UpdateCollection _UpdateCollection;
        private volatile bool _LauncherUpdated = false; //Flags the launcher to need a restart, to replace the current version with H2Launcher_temp.exe
        private volatile bool _RunUpdates = false;
        private volatile bool _Finished = false;
        private volatile bool _RemoteLoaded = false;
        private volatile bool _LocalLoaded = false;
        private Halo_2_Launcher.Forms.Update _Form;
        public UpdateController(Halo_2_Launcher.Forms.Update Form)
        {
            this._Form = Form;
        }
        public void LoadRemoteUpdateCollection()
        {
            //try
            //{
                this._Form.AddToDetails("Downloading remote update XML file....");
                if (File.Exists(Paths.Files + "RemoteUpdate.xml")) File.Delete(Paths.Files + "RemoteUpdate.xml");
                WebClient Client = new WebClient();
                bool _isDownloading = false;
                Client.DownloadFileCompleted += (s, e) =>
                {
                    this._Form.UpdateProgress(100);
                    this._Form.AddToDetails("Download Complete.");

                    Client.Dispose();
                    Client = null;
                    _isDownloading = false;
                };
                Client.DownloadProgressChanged += (s, e) =>
                {
                    this._Form.UpdateProgress(e.ProgressPercentage);
                };
                try
                {
                    Client.DownloadFileAsync(new Uri(Paths.RemoteUpdateXML), Paths.Files + "RemoteUpdate.xml");
                    _isDownloading = true;
                }
                catch (Exception) { throw new Exception("Error"); }
                //await Task.Run(() =>
                //{
                    while (_isDownloading) { }
               // });
                XDocument RemoteXML = XDocument.Load(Paths.Files + "RemoteUpdate.xml");
                UpdateCollection tUpdateColleciton = new UpdateCollection();
                //replaceoriginal = (XmlRoot.Element("localpath").HasAttributes) ? ((XmlRoot.Element("localpath").Attribute("replaceoriginal") != null) ? true : false) : false
                foreach (object UO in (from XmlRoot in RemoteXML.Element("update").Elements("file")
                                       select
                                           new UpdateObject
                                           {
                                               localpath = (string)XmlRoot.Element("localpath"),
                                               remotepath = (string)XmlRoot.Element("remotepath"),
                                               version = (string)XmlRoot.Element("version"),
                                               name = (string)XmlRoot.Element("name")
                                           }
                                    )
                )
                {
                    tUpdateColleciton.AddObject((UpdateObject)UO);
                }
                _RemoteUpdateCollection = tUpdateColleciton;
                this._RemoteLoaded = true;
            //}
            //catch (Exception) { throw new Exception("Error downloading remote update xml"); }
        }

        public void LoadLocalUpdateCollection()
        {
            try
            {
                if (File.Exists(Paths.Files + "LocalUpdate.xml"))
                {
                    //await Task.Delay(0);
                    XDocument RemoteXML = XDocument.Load(Paths.Files + "LocalUpdate.xml");
                    UpdateCollection tUpdateColleciton = new UpdateCollection();
                    foreach (object UO in (from XmlRoot in RemoteXML.Element("update").Elements("file")
                                           select
                                               new UpdateObject
                                               {
                                                   localpath = (string)XmlRoot.Element("localpath"),
                                                   remotepath = (string)XmlRoot.Element("remotepath"),
                                                   version = (string)XmlRoot.Element("version"),
                                                   name = (string)XmlRoot.Element("name")
                                                   //replaceoriginal = (bool)XmlRoot.Element("localpath").Attribute("replaceoriginal")
                                               }
                                        )
                    )
                    {
                        if (File.Exists(((UpdateObject)UO).localpath.Replace("_temp", "")))
                            tUpdateColleciton.AddObject((UpdateObject)UO);
                    }
                    _LocalUpdateCollection = tUpdateColleciton;
                    this._LocalLoaded = true;
                }
                else
                {
                    this._LocalLoaded = true;
                }
            }
            catch (Exception) { throw new Exception("Error loading local update xml"); }
        }
        public async void CheckUpdates()
        {
            await Task.Run(() =>
            {
                LoadLocalUpdateCollection();
                LoadRemoteUpdateCollection();
                bool Update = NeedToUpdate();
                if (Update)
                {
                    DownloadUpdates();
                    this._Form.AddToDetails("Updates Complete");
                    Task.Delay(1000);
                    Finished();
                }
                else
                {
                    this._Form.AddToDetails("No Updates found.");
                    Task.Delay(1000);
                    this._Form.UpdaterFinished();
                }
            });
            //await Task.Run(() => { LoadLocalUpdateCollection(); });
            //await Task.Run(() => { LoadRemoteUpdateCollection(); });
            //bool Update = await Task.Run(() => NeedToUpdate());
            //if (Update)
            //{
            //    await Task.Run(() => { DownloadUpdates(); });
            //    this._Form.AddToDetails("Updates Complete");
            //    await Task.Delay(1000);
            //    await Task.Run(() => { Finished(); });
            //}
            //else
            //{
            //    this._Form.AddToDetails("No Updates found.");
            //    await Task.Delay(1000);
            //    this._Form.UpdaterFinished();
            //}

            //LoadRemoteUpdateCollection();
            //DownloadUpdates();
            //Finished();
        }
        private bool NeedToUpdate()
        {
            if (this._LocalUpdateCollection != null)
            {
                this._UpdateCollection = new UpdateCollection();
                foreach (UpdateObject UO in _RemoteUpdateCollection)
                {
                    UpdateObject tUO = _LocalUpdateCollection[UO.name];
                    if (tUO == null)
                        _UpdateCollection.AddObject(UO);
                    else if (tUO.version != UO.version)
                        _UpdateCollection.AddObject(UO);
                    else if (tUO.localpath != UO.localpath)
                        MoveFile(tUO.name, tUO.localpath, UO.localpath);
                }
            }
            bool ssd = this._RemoteLoaded;
            this._UpdateCollection = (this._UpdateCollection != null) ? this._UpdateCollection : this._RemoteUpdateCollection;
            if (this._UpdateCollection.Count > 0)
                return true;
            else
                return false;
        }
        private void DownloadUpdates()
        {

            for (int i = 0; i < this._UpdateCollection.Count; i++)
            {
                UpdateObject tUO = this._UpdateCollection[i];
                this._Form.AddToDetails("Downloading " + tUO.name + "....");
                if (tUO.name == "Halo_2_Launcher")
                    this._LauncherUpdated = true;
                WebClient Client = new WebClient();
                bool _isDownloading = false;
                Client.DownloadFileCompleted += (s, e) =>
                {
                    this._Form.UpdateProgress(100);
                    this._Form.AddToDetails("Download Complete.");
                    Client.Dispose();
                    Client = null;
                    _isDownloading = false;
                };
                Client.DownloadProgressChanged += (s, e) =>
                {
                    this._Form.UpdateProgress(e.ProgressPercentage);
                };
                try
                {
                    Client.DownloadFileAsync(new Uri(tUO.remotepath), tUO.localpath);
                    _isDownloading = true;
                }
                catch (Exception) { throw new Exception("Error"); }
                //DownloadFile(tUO.remotepath, tUO.localpath);
                while (_isDownloading) { }
                if (i == this._UpdateCollection.Count - 1)
                    _Finished = true;
            }
        }
        //public void 
        public  void Finished()
        {
            //public void 
            //await Task.Run(() => { while (!_Finished) { } 
                File.Delete(Paths.Files + "LocalUpdate.xml"); File.Copy(Paths.Files + "RemoteUpdate.xml", Paths.Files + "LocalUpdate.xml"); 
            //});
            if (this._LauncherUpdated)
            {
                this._Form.AddToDetails("Restarting Launcher to complete update");
                Task.Delay(5000);
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.Arguments = "/C ping 127.0.0.1 -n 1 -w 5000 > Nul & Del \"" + Application.ExecutablePath + "\" & ping 127.0.0.1 -n 1 -w 2000 > Nul & rename Halo_2_Launcher_temp.exe Halo_2_Launcher.exe & ping 127.0.0.1 -n 1 -w 2000 > Nul & start Halo_2_Launcher.exe";
                Info.WindowStyle = ProcessWindowStyle.Hidden;
                Info.CreateNoWindow = true;
                Info.WorkingDirectory = Application.StartupPath;
                Info.FileName = "cmd.exe";
                Process.Start(Info);
                Process.GetCurrentProcess().Kill();
            } else
            {
                this._Form.UpdaterFinished();
            }
        }
        //public void 
        private void MoveFile(string Name, string Source, string Destination)
        {
            using (Stream SourceStream = File.Open(Source, FileMode.Open))
            {
                using (Stream DestinationStream = File.Create(Destination))
                {
                    this._Form.AddToDetails("Moving " + Name + " \r\n\tFrom " + Source + " \r\n\tTo " + Destination);
                    this._Form.UpdateProgress(0);
                    byte[] buffer = new byte[SourceStream.Length / 1024];
                    int read;
                    while ((read = SourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        DestinationStream.Write(buffer, 0, buffer.Length);
                        int progress = (read / buffer.Length) * 100;
                        this._Form.UpdateProgress(progress);
                    }
                    this._Form.UpdateProgress(100);
                    this._Form.AddToDetails("Moving Complete");
                }
            }
            Task.Delay(500);
            File.Delete(Source);
        }
        private void DownloadFile(String remoteFilename, String localFilename)
        {
            bool _isDownloading = false;
            WebClient Client = new WebClient();
            Client.DownloadFileCompleted += (s, e) => 
                {
                    this._Form.UpdateProgress(100);
                    this._Form.AddToDetails("Download Complete.");
                    Client.Dispose();
                    Client = null;
                    _isDownloading = false;
                };
            Client.DownloadProgressChanged += (s, e) =>
                {
                    this._Form.UpdateProgress(e.ProgressPercentage);
                };
            try
            {
                this._Form.UpdateProgress(0);
                Client.DownloadFileAsync(new Uri(remoteFilename), localFilename);
                _isDownloading = true;
                while (_isDownloading) { }
            }
            catch (Exception) { throw new Exception("Error"); }
        }
    }
}
