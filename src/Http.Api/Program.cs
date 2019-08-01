﻿using System;
using Google.Api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using OpenCensus.Exporter.Stackdriver;
using OpenCensus.Exporter.Stackdriver.Implementation;
using OpenCensus.Stats;
using OpenCensus.Trace;

namespace Http.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // A little hacky, but at this point you need to add a file 'creds.json to the root of the 'Http.Api' directory.
            // The cred.json file contains the login details for a user/serivce account required to access GCP stackdriver.
            // It can be generated using a gcloud command.'
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Environment.CurrentDirectory + "/creds.json");

            var projectId = "crested-bloom-231015";

            var exporter = new StackdriverExporter(
                projectId,
                Tracing.ExportComponent,
                Stats.ViewManager);

            exporter.Start();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
