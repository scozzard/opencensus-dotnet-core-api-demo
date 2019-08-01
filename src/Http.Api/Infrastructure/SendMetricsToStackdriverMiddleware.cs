using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenCensus.Stats;
using OpenCensus.Stats.Aggregations;
using OpenCensus.Stats.Measures;
using OpenCensus.Tags;

namespace Http.Api.Infrastructure
{
    public class SendMetricsToStackdriverMiddleware
    {
        private readonly RequestDelegate _next;
        
        private static readonly ITagger Tagger = Tags.Tagger;
        private static readonly IStatsRecorder StatsRecorder = Stats.StatsRecorder;
        
        // Measure
        private static readonly IMeasureLong Requests = MeasureLong.Create("broken_arrow6/measure/requests", "Number of requests.", "UNIT");
        
        // Tags
        private static readonly ITagKey MethodKey = TagKey.Create("broken_arrow6/keys/method");
        private static readonly ITagKey PathKey = TagKey.Create("broken_arrow6/keys/path");
        
        // View
        private static readonly IViewName RequestsViewName = ViewName.Create("broken_arrow6/views/requests");

        public SendMetricsToStackdriverMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)
        {
            var tagContextBuilder = Tagger
                .CurrentBuilder
                .Put(MethodKey, TagValue.Create(context.Request.Method))
                .Put(PathKey, TagValue.Create(context.Request.Path));
            
            Stats.ViewManager.RegisterView(RequestsView);
            
            using (var scopedTags = tagContextBuilder.BuildScoped())
            {
                StatsRecorder.NewMeasureMap()
                    .Put(Requests, 1)
                    .Record();
            }
            
            var viewData = Stats.ViewManager.GetView(RequestsViewName);

            Console.WriteLine("Metric data sent for " + viewData.View.Name + ".");
            Console.WriteLine("Done... wait for events to arrive to backend!");
            
            await _next(context);
        }
        
        private static readonly IView RequestsView = View.Create(
            name: RequestsViewName,
            description: "Requests made over time.",
            measure: Requests,
            aggregation: Sum.Create(),
            columns: new List<ITagKey>() { MethodKey, PathKey });
    }
}