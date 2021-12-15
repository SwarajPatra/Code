using JobSorting.Api.DataAccessLayer.Context;
using JobSorting.Api.DataAccessLayer.Models;
using JobSorting.Api.Models.Class;
using JobSorting.Api.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSorting.Api.DataAccessLayer.Utilities
{
    public class JobSortUtilities : IJobSortUtilities
    {
        public JobContext _context;

        public JobSortUtilities(JobContext _context)
        {
            this._context = _context;
        }

        public Task WriteToDb(Job job)
        {
            var sortj = _context.SortJobs.ToList().Find(x => x.JobId == job.JobId.ToString());
            if (sortj != null)
            {
                sortj.JobId = job.JobId.ToString();
                sortj.JobStatus = job.JobStatus.ToString();
                sortj.JobInput = string.Join(',', job.JobInput);
                sortj.JobOutput = job.JobOutput != null ? string.Join(',', job.JobOutput) : "";
                sortj.JobDuration = job.JobDuration.HasValue ? job.JobDuration.Value.Ticks : 0;

                _context.SortJobs.Update(sortj);
            }
            else
            {
                SortJob sortJobEntity = new SortJob(job);
                _context.Add(sortJobEntity);
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<Job>> GetSortJobs()
        {
            List<Job> allsortJobs = new List<Job>();
            var allJobs = _context.SortJobs.ToList();
            foreach (var job in allJobs)
            {
                allsortJobs.Add(ExtractSortJobFromSortJobEntity(job));
            }
            return Task.FromResult(allsortJobs);
        }

        public Task<Job> GetSortJob(string id)
        {
            SortJob result = _context.SortJobs.SingleOrDefault(x => x.JobId == id);
            Job job = ExtractSortJobFromSortJobEntity(result);

            return Task.FromResult(job);
        }

        public static Job ExtractSortJobFromSortJobEntity(SortJob result)
        {
            Job job;
            if (result != null)
            {
                Guid jobId = new Guid(result.JobId);
                SortJobStatus status = default!;

                if (result.JobStatus == "Pending")
                    status = SortJobStatus.Pending;
                else
                    status = SortJobStatus.Completed;

                TimeSpan duration = new TimeSpan(result.JobDuration);

                int[] input = Array.ConvertAll(result.JobInput.Split(','), value => Convert.ToInt32(value));

                int[]? output = default!;

                if (!String.IsNullOrEmpty(result.JobOutput))
                    output = Array.ConvertAll(result.JobOutput.Split(','), value => Convert.ToInt32(value));
                else
                    output = null;

                job = new Job(jobId, status, duration, input, output);
            }
            else
                job = default!;
            return job;
        }
    }
}
