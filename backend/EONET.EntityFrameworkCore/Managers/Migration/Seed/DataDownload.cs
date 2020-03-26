using EONET.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Net;

namespace EONET.Managers.Migration.Seed
{
    public class DataDownload
    {
        string url = "https://eonet.sci.gsfc.nasa.gov/api/v2.1/events";

        public event System.Net.DownloadDataCompletedEventHandler DownloadDataCompleted;

        public WebClient w = new WebClient();
        public DataDownload() { }

        public void DataCallBack(string status)
        {
            try
            {
                w.DownloadDataCompleted += DownloadDataCompleted;

                w.DownloadStringAsync(new Uri(url + status), status);

            }
            catch (Exception) { }
        }
    }
}
