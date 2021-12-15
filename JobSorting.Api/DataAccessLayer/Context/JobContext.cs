namespace JobSorting.Api.DataAccessLayer.Context
{
    using Microsoft.EntityFrameworkCore;
    using JobSorting.Api.DataAccessLayer.Models;

    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<SortJob> SortJobs { get; set; }
    }
}
