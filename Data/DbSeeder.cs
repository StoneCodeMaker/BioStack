using BioStack.Models;
using Microsoft.EntityFrameworkCore;

namespace BioStack.Data;

public static class DbSeeder
{
    public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BioStackDbContext>();

        // Apply migrations
        await dbContext.Database.MigrateAsync();

        // Seed data only if the database is empty
        if (!await dbContext.UserProfiles.AnyAsync())
        {
            await SeedUserProfileAsync(dbContext);
        }

        if (!await dbContext.Supplements.AnyAsync())
        {
            await SeedSupplementsAsync(dbContext);
        }

        if (!await dbContext.Workouts.AnyAsync())
        {
            await SeedWorkoutsAsync(dbContext);
        }

        if (!await dbContext.HealthMetrics.AnyAsync())
        {
            await SeedHealthMetricsAsync(dbContext);
        }

        await dbContext.SaveChangesAsync();
    }

    private static async Task SeedUserProfileAsync(BioStackDbContext dbContext)
    {
        var userProfile = new UserProfile
        {
            FirstName = "John",
            LastName = "Doe",
            Height = 70.5m, // 5'10.5"
            HeightUnit = "in",
            Weight = 180.0m,
            WeightUnit = "lbs",
            DateOfBirth = new DateTime(1990, 1, 15),
            FitnessGoals = "Build muscle mass and improve overall fitness",
            HealthNotes = "No significant health issues"
        };

        await dbContext.UserProfiles.AddAsync(userProfile);
    }

    private static async Task SeedSupplementsAsync(BioStackDbContext dbContext)
    {
        var supplements = new List<Supplement>
        {
            new Supplement
            {
                Name = "Whey Protein",
                Category = "Protein",
                Dosage = "1 scoop (25g)",
                Notes = "Take after workouts",
                IsActive = true
            },
            new Supplement
            {
                Name = "Creatine Monohydrate",
                Category = "Performance",
                Dosage = "5g",
                Notes = "Take daily with water",
                IsActive = true
            },
            new Supplement
            {
                Name = "Multivitamin",
                Category = "Vitamin",
                Dosage = "1 tablet",
                Notes = "Take with breakfast",
                IsActive = true
            },
            new Supplement
            {
                Name = "Fish Oil",
                Category = "Omega-3",
                Dosage = "2 capsules",
                Notes = "Take with meals",
                IsActive = true
            },
            new Supplement
            {
                Name = "Vitamin D3",
                Category = "Vitamin",
                Dosage = "2000 IU",
                Notes = "Take daily with fat-containing meal",
                IsActive = true
            }
        };

        await dbContext.Supplements.AddRangeAsync(supplements);
        await dbContext.SaveChangesAsync();

        // Add some intake logs for the supplements
        var today = DateTime.Today;
        var yesterday = today.AddDays(-1);

        var intakeLogs = new List<IntakeLog>();

        // For each supplement, add some intake logs
        foreach (var supplement in supplements)
        {
            // Today's log
            intakeLogs.Add(new IntakeLog
            {
                SupplementId = supplement.Id,
                IntakeTime = today.AddHours(8), // Morning
                Taken = true,
                Notes = "Taken with breakfast"
            });

            // Yesterday's log
            intakeLogs.Add(new IntakeLog
            {
                SupplementId = supplement.Id,
                IntakeTime = yesterday.AddHours(8), // Morning
                Taken = true,
                Notes = "Taken with breakfast"
            });
        }

        await dbContext.IntakeLogs.AddRangeAsync(intakeLogs);
    }

    private static async Task SeedWorkoutsAsync(BioStackDbContext dbContext)
    {
        var today = DateTime.Today;
        var yesterday = today.AddDays(-1);
        var twoDaysAgo = today.AddDays(-2);

        var workouts = new List<Workout>
        {
            new Workout
            {
                Name = "Chest and Triceps",
                Date = yesterday,
                WorkoutType = "Strength",
                DurationMinutes = 60,
                Notes = "Felt strong today"
            },
            new Workout
            {
                Name = "Back and Biceps",
                Date = twoDaysAgo,
                WorkoutType = "Strength",
                DurationMinutes = 65,
                Notes = "Increased weight on rows"
            },
            new Workout
            {
                Name = "Legs",
                Date = today.AddDays(-4),
                WorkoutType = "Strength",
                DurationMinutes = 70,
                Notes = "Focus on form"
            }
        };

        await dbContext.Workouts.AddRangeAsync(workouts);
        await dbContext.SaveChangesAsync();

        // Add exercise sets for the workouts
        var exerciseSets = new List<ExerciseSet>();

        // Chest and Triceps workout
        var chestWorkout = workouts[0];
        exerciseSets.AddRange(new List<ExerciseSet>
        {
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Bench Press", SetNumber = 1, Reps = 10, Weight = 135 },
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Bench Press", SetNumber = 2, Reps = 8, Weight = 155 },
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Bench Press", SetNumber = 3, Reps = 6, Weight = 175 },
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Incline Dumbbell Press", SetNumber = 1, Reps = 12, Weight = 50 },
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Incline Dumbbell Press", SetNumber = 2, Reps = 10, Weight = 55 },
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Tricep Pushdown", SetNumber = 1, Reps = 15, Weight = 50 },
            new ExerciseSet { WorkoutId = chestWorkout.Id, ExerciseName = "Tricep Pushdown", SetNumber = 2, Reps = 12, Weight = 60 }
        });

        // Back and Biceps workout
        var backWorkout = workouts[1];
        exerciseSets.AddRange(new List<ExerciseSet>
        {
            new ExerciseSet { WorkoutId = backWorkout.Id, ExerciseName = "Pull-ups", SetNumber = 1, Reps = 10, Weight = 0 },
            new ExerciseSet { WorkoutId = backWorkout.Id, ExerciseName = "Pull-ups", SetNumber = 2, Reps = 8, Weight = 0 },
            new ExerciseSet { WorkoutId = backWorkout.Id, ExerciseName = "Barbell Row", SetNumber = 1, Reps = 12, Weight = 135 },
            new ExerciseSet { WorkoutId = backWorkout.Id, ExerciseName = "Barbell Row", SetNumber = 2, Reps = 10, Weight = 155 },
            new ExerciseSet { WorkoutId = backWorkout.Id, ExerciseName = "Dumbbell Curl", SetNumber = 1, Reps = 12, Weight = 30 },
            new ExerciseSet { WorkoutId = backWorkout.Id, ExerciseName = "Dumbbell Curl", SetNumber = 2, Reps = 10, Weight = 35 }
        });

        // Legs workout
        var legsWorkout = workouts[2];
        exerciseSets.AddRange(new List<ExerciseSet>
        {
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Squat", SetNumber = 1, Reps = 10, Weight = 185 },
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Squat", SetNumber = 2, Reps = 8, Weight = 205 },
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Squat", SetNumber = 3, Reps = 6, Weight = 225 },
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Leg Press", SetNumber = 1, Reps = 12, Weight = 270 },
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Leg Press", SetNumber = 2, Reps = 10, Weight = 360 },
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Leg Curl", SetNumber = 1, Reps = 15, Weight = 90 },
            new ExerciseSet { WorkoutId = legsWorkout.Id, ExerciseName = "Leg Curl", SetNumber = 2, Reps = 12, Weight = 100 }
        });

        await dbContext.ExerciseSets.AddRangeAsync(exerciseSets);
    }

    private static async Task SeedHealthMetricsAsync(BioStackDbContext dbContext)
    {
        var today = DateTime.Today;
        
        var healthMetrics = new List<HealthMetric>();
        
        // Add health metrics for the past 7 days
        for (int i = 0; i < 7; i++)
        {
            var date = today.AddDays(-i);
            var random = new Random(date.Day + date.Month + date.Year); // Seed for consistent randomness
            
            healthMetrics.Add(new HealthMetric
            {
                Date = date,
                SleepHours = random.Next(6, 9),
                SleepQuality = random.Next(5, 10),
                EnergyLevel = random.Next(5, 10),
                RecoveryScore = random.Next(5, 10),
                Weight = 180.0m - (i % 3) * 0.2m, // Small fluctuations
                Notes = i % 2 == 0 ? "Feeling good today" : "Slightly tired"
            });
        }
        
        await dbContext.HealthMetrics.AddRangeAsync(healthMetrics);
    }
}
