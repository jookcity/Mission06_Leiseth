using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base (options)
    {
    }

    public DbSet<Movie> Applications { get; set; }
}
