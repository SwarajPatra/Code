using JobSorting.Api.Models.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSorting.Api.DataAccessLayer.Utilities
{
    public interface IJobSortUtilities
    {
        Task WriteToDb(Job job);

        Task<Job> GetSortJob(string id);

        Task<List<Job>> GetSortJobs();
    }
}
