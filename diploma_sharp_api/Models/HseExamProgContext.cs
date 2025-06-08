using Microsoft.EntityFrameworkCore;

namespace diploma_sharp_api.Models;

public partial class HseExamProgContext : DbContext
{
    public HseExamProgContext()
    {
    }

    public HseExamProgContext(DbContextOptions<HseExamProgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExamTask> ExamTasks { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Variant> Variants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.Development.json")
                        .Build();
        optionsBuilder.UseNpgsql(config.GetConnectionString("HSEDBConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExamTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_pkey");

            entity.ToTable("exam_task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TaskNum).HasColumnName("task_num");
            entity.Property(e => e.TaskText).HasColumnName("task_text");
            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity.HasOne(d => d.Variant).WithMany(p => p.ExamTasks)
                .HasForeignKey(d => d.VariantId)
                .HasConstraintName("variant_fkey");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_pkey");

            entity.ToTable("group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("result_pkey");

            entity.ToTable("result");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnalysisRes).HasColumnName("analysis_res");
            entity.Property(e => e.CheckDate).HasColumnName("check_date");
            entity.Property(e => e.RecognizedCode).HasColumnName("recognized_code");
            entity.Property(e => e.ScanPath).HasColumnName("scan_path");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Results)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("student_fkey");

            entity.HasOne(d => d.Task).WithMany(p => p.Results)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("task_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Results)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("teacher_fkey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("group_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        modelBuilder.Entity<Variant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("variant_pkey");

            entity.ToTable("variant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InitialYear).HasColumnName("initial_year");
            entity.Property(e => e.Module).HasColumnName("module");
            entity.Property(e => e.VariantNum).HasColumnName("variant_num");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
