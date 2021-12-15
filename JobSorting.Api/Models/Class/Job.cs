using JobSorting.Api.Models.Enum;
using System;
using System.Collections.Generic;

namespace JobSorting.Api.Models.Class
{
    public class Job
    {
        public Job(Guid id, SortJobStatus status, TimeSpan? duration, IReadOnlyCollection<int> input, IReadOnlyCollection<int>? output)
        {
            JobId = id;
            JobStatus = status;
            JobDuration = duration;
            JobInput = input;
            JobOutput = output;
        }

        public Guid JobId { get; }
        public SortJobStatus JobStatus { get; }
        public TimeSpan? JobDuration { get; }
        public IReadOnlyCollection<int> JobInput { get; }
        public IReadOnlyCollection<int>? JobOutput { get; }
    }
}
