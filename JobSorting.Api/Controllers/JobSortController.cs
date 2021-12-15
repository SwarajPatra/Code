using JobSorting.Api.JobProcessor;
using JobSorting.Api.Models.Class;
using JobSorting.Api.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JobSorting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSortController : ControllerBase
    {
        private readonly ISortJobProcessor _sortJobProcessor;

        public JobSortController(ISortJobProcessor sortJobProcessor)
        {
            _sortJobProcessor = sortJobProcessor;
        }

        [HttpPost("EnqueueJob")]
        public async Task<ActionResult<Job>> EnqueueJob(int[] values)
        {
            // TODO: Should enqueue a job to be processed in the background.
            var pendingJob = new Job(
                id: Guid.NewGuid(),
                status: SortJobStatus.Pending,
                duration: null,
                input: values,
                output: null);

            await _sortJobProcessor.ProcessAsync(pendingJob);

            return Ok(pendingJob);
        }

        [HttpGet("GetJobs")]
        public async Task<ActionResult<Job[]>> GetJobs()
        {
            // TODO: Should return all jobs that have been enqueued (both pending and completed).
            Job[] allJobs = await _sortJobProcessor.GetSortJobs();

            return Ok(allJobs);
        }

        [HttpGet("GetJobByID/{jobId}")]
        public async Task<ActionResult<Job>> GetJobById(Guid jobId)
        {
            // TODO: Should return a specific job by ID.
            Job job = await _sortJobProcessor.GetSortJob(jobId.ToString());

            return Ok(job);
        }
    }
}
