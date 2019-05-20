using DDClassLibrary1.Properties;
using Microsoft.Azure.Storage;
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
            //string storageConnectionString = Resources.ResourceManager.GetString("ConnectionString");
            string storageConnectionString = Resources.ResourceManager.GetString("EmulatorConnectionString"); // for Emulator

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
            //string storageConnectionString = Resources.ResourceManager.GetString("ConnectionString");
            string storageConnectionString = Resources.ResourceManager.GetString("EmulatorConnectionString"); // for Emulator

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
