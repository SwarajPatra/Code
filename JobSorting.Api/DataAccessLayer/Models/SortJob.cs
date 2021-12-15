namespace JobSorting.Api.DataAccessLayer.Models
{
    using JobSorting.Api.Models.Class;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SortJobs")]
    public class SortJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string JobId { get; set; }

        public string JobInput { get; set; }

        public string JobOutput { get; set; }

        public string JobStatus { get; set; }

        public long JobDuration { get; set; }


        public SortJob()
        {
            JobId = default!;
            JobInput = default!;
            JobOutput = default!;
            JobStatus = default!;
            JobDuration = JobDuration!;
        }

        public SortJob(Job sortjob)
        {
            JobId = sortjob.JobId.ToString();

            JobInput = string.Join(',', sortjob.JobInput);

            if (sortjob.JobOutput != null)
                JobOutput = string.Join(',', sortjob.JobOutput);
            else
                JobOutput = string.Empty;

            JobStatus = sortjob.JobStatus.ToString();

            if (sortjob.JobDuration.HasValue)
                JobDuration = sortjob.JobDuration.Value.Ticks;
        }
    }
}
