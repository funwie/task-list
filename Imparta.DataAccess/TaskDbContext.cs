using Imparta.Domain.Task;
using Microsoft.EntityFrameworkCore;

namespace Imparta.DataAccess
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.ToTable("TaskList");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("TaskListId");

                entity.HasIndex(e => e.Title);

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .IsRequired();

                entity.Property(e => e.OwnerId)
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                   .HasDefaultValueSql("GETDATE()");

                entity.HasMany(e => e.Tasks)
                    .WithOne(t => t.TaskList)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.ToTable("Task");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("TaskId");

                entity.HasIndex(e => e.Description);

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(1000)")
                    .IsRequired();

                entity.Property(e => e.Start)
                    .IsRequired();

                entity.Property(e => e.End)
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                   .HasDefaultValueSql("GETDATE()");
            });

        }
    }
}