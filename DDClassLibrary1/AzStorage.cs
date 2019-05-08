﻿using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DDClassLibrary1
{
    class AzStorage
    {
        public static async void UploadExcelAsync(MemoryStream uploadstream)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("libsettings.json", optional: true)
            .AddJsonFile("../libsettings.json", optional: true)
            .Build();

            string storageConnectionString = configuration["AzureBlobStorage:ConnectionString"];
            // Emulator
            //string storageConnectionString = configuration["AzureBlobStorage:EmulatorConnectionString"];


            CloudStorageAccount storageAccount;
            CloudStorageAccount.TryParse(storageConnectionString, out storageAccount);

            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

            // Create a container
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("output");

            // Get a reference to the blob address, then upload the file to the blob.
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("Result.xlsx");

            await cloudBlockBlob.UploadFromStreamAsync(uploadstream);
        }

        public static async void UploadPdfAsync(MemoryStream uploadstream)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("libsettings.json", optional: true)
            .AddJsonFile("../libsettings.json", optional: true)
            .Build();

            string storageConnectionString = configuration["AzureBlobStorage:ConnectionString"];
            // Emulator
            //string storageConnectionString = configuration["AzureBlobStorage:EmulatorConnectionString"];


            CloudStorageAccount storageAccount;
            CloudStorageAccount.TryParse(storageConnectionString, out storageAccount);

            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

            // Create a container
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("output");

            // Get a reference to the blob address, then upload the file to the blob.
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference("Result.pdf");

            await cloudBlockBlob.UploadFromStreamAsync(uploadstream);
        }
    }
}
