using JobSorting.Api.DataAccessLayer.Utilities;
using JobSorting.Api.Models.Class;
using JobSorting.Api.Models.Enum;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobSorting.Api.JobProcessor
{
    public class SortJobProcessor : ISortJobProcessor
    {
        private IJobSortUtilities jobSortUtilities;
        private readonly ILogger<SortJobProcessor> _logger;

        public SortJobProcessor(ILogger<SortJobProcessor> logger, IJobSortUtilities dBUtilities)
        {
            this._logger = logger;
            this.jobSortUtilities = dBUtilities;
        }

        public async Task<Job> Process(Job job)
        {
            _logger.LogInformation("Processing job with ID '{JobId}'.", job.JobId);

            var stopwatch = Stopwatch.StartNew();

            var output = job.JobInput.OrderBy(n => n).ToArray();
            await Task.Delay(5000); // NOTE: This is just to simulate a more expensive operation

            var duration = stopwatch.Elapsed;

            _logger.LogInformation("Completed processing job with ID '{JobId}'. Duration: '{Duration}'.", job.JobId, duration);

            return new Job(
                id: job.JobId,
                status: SortJobStatus.Completed,
                duration: duration,
                input: job.JobInput,
                output: output);
        }

        public async Task ProcessAsync(Job job)
        {
            await this.jobSortUtilities.WriteToDb(job);
        }

        public async Task<Job[]> GetSortJobs()
        {
            List<Job> listOfJobs = await jobSortUtilities.GetSortJobs();

            Job[] arrayJobs = listOfJobs.ToArray<Job>();

            return arrayJobs;
        }

        public Task<Job> GetSortJob(string id)
        {
            var job = jobSortUtilities.GetSortJob(id);

            return job;
        }
    }
}
