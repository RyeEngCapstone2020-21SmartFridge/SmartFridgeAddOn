﻿using System;
using System.Globalization;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;

namespace Amazon.Sender.S3
{
    public static class AWSUpload
    {
        private const string bucketName = "smart-fridge-pictures";                                  //The name of the S3 Bucket
        private const string FilePath = @"..\..\..\..\images\FridgePicture.jpg";                        //Path of test image

        public static readonly RegionEndpoint BucketRegion = RegionEndpoint.USEast1;             //server region declaration
        
        //Instantiating S3 Client
        private static IAmazonS3 s3Client =
                new AmazonS3Client(BucketRegion);

        public static async Task UploadingFileAsync()                                               //Method to upload files to S3 bucket
        {
            try
            {
                Console.WriteLine("Sending image to server ...");
                var fileTransferUtility = new TransferUtility(s3Client);

                await fileTransferUtility.UploadAsync(FilePath, bucketName);
                Console.WriteLine("Upload completed.");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }
    }
}
