# broken-arrow
A simple dockerized Web API with a unit test.

The `Http.Api` project is a Web API that has two GET endpoints - `/movies` and `actors` (and a `/healthcheck` endpoint that simply returns OK).

The project has been setup with middleware that uses [OpenCensus](https://github.com/census-instrumentation/opencensus-csharp) to push metrics to Stackdriver with every request.

The `Http.Api.Tests.Unit` project has one unit test. It tests the GET endpoint `/movies` only returns 1990's movies starring John Travolta.

This repo has been setup exclusively to test and demo pushing metrics to Stackdriver with Opencensus.
