using Microsoft.EntityFrameworkCore;
using BioStack.Models;

namespace BioStack.Data;

public class BioStackDbContext : DbContext
{
    public BioStackDbContext(DbContextOptions<BioStackDbContext> options) : base(options)
    {
    }

    public DbSet<Supplement> Supplements { get; set; } = null!;
    public DbSet<IntakeLog> IntakeLogs { get; set; } = null!;
    public DbSet<Workout> Workouts { get; set; } = null!;
    public DbSet<ExerciseSet> ExerciseSets { get; set; } = null!;
    public DbSet<HealthMetric> HealthMetrics { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<IntakeLog>()
            .HasOne(il => il.Supplement)
            .WithMany(s => s.IntakeLogs)
            .HasForeignKey(il => il.SupplementId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExerciseSet>()
            .HasOne(es => es.Workout)
            .WithMany(w => w.ExerciseSets)
            .HasForeignKey(es => es.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
