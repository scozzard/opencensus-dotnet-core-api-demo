# broken-arrow
A simple dockerized Web API with a unit test.

The `Http.Api` project is a Web API that has two GET endpoints - `/movies` and `actors` (and a `/healthcheck` endpoint that simply returns OK).

The project has been setup with middleware that uses [OpenCensus](https://github.com/census-instrumentation/opencensus-csharp) to push custom metrics to Stackdriver with every request.

The `Http.Api.Tests.Unit` project has one unit test. It tests the GET endpoint `/movies` only returns 1990's movies starring John Travolta.

This repo has been setup exclusively to test and demo pushing metrics to Stackdriver with Opencensus.

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
* In the root directory, run 'docker-compose up'.
* View the website on port 5007 (0.0.0.0 mac and localhost windows).
