using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class WeatherDbContext : DbContext
    {

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {

        }
    }
}
