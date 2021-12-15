using JobSorting.Api.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSorting.Api.JobProcessor
{
    public interface ISortJobProcessor
    {
        Task<Job> Process(Job job);

        Task ProcessAsync(Job job);

        Task<Job[]> GetSortJobs();

        Task<Job> GetSortJob(string id);
    }
}
