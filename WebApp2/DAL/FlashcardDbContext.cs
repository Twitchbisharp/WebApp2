using Microsoft.EntityFrameworkCore;
using WebApp2.Models;

namespace WebApp2.DAL;

public class FlashcardDbContext : DbContext
{
    public FlashcardDbContext(DbContextOptions<FlashcardDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }
    
    public DbSet<Flashcard> Flashcards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}
