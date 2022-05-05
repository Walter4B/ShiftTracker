using Microsoft.EntityFrameworkCore;

namespace ShiftTrackerAPI.Models
{
    public class ShiftContext : DbContext
    {
        public ShiftContext(DbContextOptions<ShiftContext> options) : base(options) { }

        public DbSet<Shift> Shifts { get; set; } = null!;
    }
}
