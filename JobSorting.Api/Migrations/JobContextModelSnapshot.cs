// <auto-generated />
using JobSorting.Api.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobSorting.Api.Migrations
{
    [DbContext(typeof(JobContext))]
    partial class JobContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobSorting.Api.DataAccessLayer.Models.SortJob", b =>
                {
                    b.Property<string>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("JobDuration")
                        .HasColumnType("bigint");

                    b.Property<string>("JobInput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobOutput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("SortJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
