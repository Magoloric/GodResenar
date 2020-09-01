﻿using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace GodResenar.Functions
{
    class Reporter
    {
        private const string StorageConnection = "BlobEndpoint=https://godresenarblob.blob.core.windows.net/;QueueEndpoint=https://godresenarblob.queue.core.windows.net/;FileEndpoint=https://godresenarblob.file.core.windows.net/;TableEndpoint=https://godresenarblob.table.core.windows.net/;SharedAccessSignature=sv=2019-02-02&ss=bfqt&srt=sco&sp=rwdlacup&se=2020-04-17T20:18:40Z&st=2020-04-17T12:18:40Z&spr=https&sig=b5fttn0urW43gPuoMMeOlucBjoNySA3cSYvYVmVwfj0%3D";
        Report report;
        CloudBlobContainer container;

        static CloudBlobContainer GetUserContainer(Report report)
        {
            var account = CloudStorageAccount.Parse(StorageConnection);
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(report.UserName.ToLower());
        }
        /*
        internal async Task<bool> SendReport()
        {
            container = GetUserContainer(report);
            await container.CreateIfNotExistsAsync();

            if (report.PhotoAttached != null)
            {
                await UploadVoice(report.PhotoAttached);
            }
            if (report.VideoAttached != null)
            {
                await UploadVoice(report.VideoAttached);
            }
            if (report.VoiceMessage != null)
            {
                await UploadVoice(report.VoiceMessage);
            }
            if (report.TextMessage != null)
            {

            }

        }

        internal async Task<bool> UploadVoice(Stream stream)
        {
            var name = Guid.NewGuid().ToString();
            var fileBlob = container.GetBlockBlobReference(name);
            await fileBlob.UploadFromStreamAsync(stream);
        }

        internal async Task<bool> UploadImage(Stream stream)
        {
            var name = Guid.NewGuid().ToString();
            var fileBlob = container.GetBlockBlobReference(name);
            await fileBlob.UploadFromStreamAsync(stream);
        }

        internal async Task<bool> UploadVideo(Stream stream)
        {
            var name = Guid.NewGuid().ToString();
            var fileBlob = container.GetBlockBlobReference(name);
            await fileBlob.UploadFromStreamAsync(stream);
        }*/
    }
}
