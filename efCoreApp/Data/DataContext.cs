using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Kurs> Kurslar => Set<Kurs>();
    }
}