# Send Custom Metrics to Stackdriver from a .net core Web API with Opencensus

A simple dockerized .net core Web API set up with middleware that uses [OpenCensus](https://github.com/census-instrumentation/opencensus-csharp) to push custom metrics to Stackdriver with every request.

The `Http.Api` project is a Web API that has two GET endpoints - `/movies` and `actors` (and a `/healthcheck` endpoint that simply returns OK).

### Requirements
* (.NET Core)[https://dotnet.microsoft.com/download]
* [Docker Desktop](https://www.docker.com/products/docker-desktop) and [Docker Compose](https://docs.docker.com/compose/)
* A [Google Cloud](https://cloud.google.com/) account with a default project and Stackdriver activated.
* [The Google Cloud SDK](https://cloud.google.com/sdk/docs/quickstarts)

### Running locally
* Clone the repository.
* Authorize `gcloud` and select default project. 
  * `gcloud init` (if using the cli for the first time), or
  * `gcloud auth login`
* In the `/src/Http.Api` directory, download the credentials of your GCP project's server account:
  * e.g., `gcloud iam service-accounts keys create ~/key.json --iam-account [SA-NAME]@[PROJECT-ID].iam.gserviceaccount.com`
  * In the examples above, [SA-NAME] is the name of your service account, and [PROJECT-ID] is the ID of your Google Cloud project.
* In the root directory, run: 
  * `docker-compose build`, then
  * `docker-compose up`
* View the website on port 5007 (0.0.0.0 mac and localhost windows).

### Viewing metrics on Stackdriver

With the default project selected, go to the Stackdriver's [metrics explorer](https://console.cloud.google.com/monitoring/metrics-explorer) in the Google Cloud console, and apply the following options (metric is _opencensus_api/views/requests_):

![metrics](https://i.imgur.com/QK17Odr.png)
