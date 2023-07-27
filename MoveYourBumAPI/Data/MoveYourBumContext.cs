using Microsoft.EntityFrameworkCore;

namespace MoveYourBumAPI.Data
{
    public class MoveYourBumContext : DbContext
    {
        public MoveYourBumContext (DbContextOptions<MoveYourBumContext> options)
            : base(options)
        {
        }

        public DbSet<MoveYourBumAPI.Models.Day> Day { get; set; } = default!;
        
        public DbSet<MoveYourBumAPI.Models.DaySchedule>? DaySchedule { get; set; }

        public DbSet<MoveYourBumAPI.Models.Exercise>? Exercise { get; set; }

        public DbSet<MoveYourBumAPI.Models.ExercisePhoto>? ExercisePhoto { get; set; }

        public DbSet<MoveYourBumAPI.Models.ExerciseType>? ExerciseType { get; set; }
        
        public DbSet<MoveYourBumAPI.Models.Schedule>? Schedule { get; set; }

        public DbSet<MoveYourBumAPI.Models.ScheduleExercise>? ScheduleExercise { get; set; }

        public DbSet<MoveYourBumAPI.Models.ScheduleExerciseSet>? ScheduleExerciseSet { get; set; }

    }
}
