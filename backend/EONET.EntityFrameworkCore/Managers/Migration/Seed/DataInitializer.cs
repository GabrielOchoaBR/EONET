using EONET.Domain.Dtos;
using EONET.Domain.Entities;
using EONET.EntityFrameworkCore.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EONET.Managers.Migration.Seed
{
    public class DataInitializer
    {
        EONETDbContext appContext;

        WebClient webDownloaderOpen;
        WebClient webDownloaderClosed;

        string url = "https://eonet.sci.gsfc.nasa.gov/api/v2.1/events";


        MigrationEventDto migrationOpen = null;
        MigrationEventDto migrationClosed = null;

        public DataInitializer(EONETDbContext appContext)
        {
            this.appContext = appContext;

            this.webDownloaderOpen = new WebClient();
            this.webDownloaderClosed = new WebClient();
        }

        public async Task InitializeDataAsync()
        {
            DataDownload dataDownload = new DataDownload();

            webDownloaderOpen.DownloadStringCompleted += DataDownloadOpen_DownloadDataCompleted;
            webDownloaderClosed.DownloadStringCompleted += DataDownloadClosed_DownloadDataCompleted;

            webDownloaderOpen.DownloadStringAsync(new Uri(url + "?status=Open"), false);
            webDownloaderClosed.DownloadStringAsync(new Uri(url + "?limit=200&status=closed"), false);

            while ((migrationOpen == null) || (migrationClosed == null))
                await Task.Delay(1000);


            UploadData(migrationOpen, false);
            UploadData(migrationClosed, true);
        }

        private void DataDownloadClosed_DownloadDataCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            migrationClosed = !string.IsNullOrEmpty(e.Result) ? JsonConvert.DeserializeObject<MigrationEventDto>(e.Result) : null;
        }

        private void DataDownloadOpen_DownloadDataCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            migrationOpen = !string.IsNullOrEmpty(e.Result) ? JsonConvert.DeserializeObject<MigrationEventDto>(e.Result) : null;

        }

        private void UploadData(MigrationEventDto migrationEventDto, bool closed)
        {
            DataUploadDatabase dataUpload = new DataUploadDatabase();

            dataUpload.Upload(appContext, migrationEventDto, closed);

        }
    }
}
