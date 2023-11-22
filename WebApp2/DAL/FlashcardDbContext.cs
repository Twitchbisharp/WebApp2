using Microsoft.EntityFrameworkCore;
using WebApp2.Models;

namespace WebApp2.DAL;

public class FlashcardDbContext : DbContext
{
    public FlashcardDbContext(DbContextOptions<FlashcardDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }
    // Creates tables in the Database
    public DbSet<Flashcard> Flashcards { get; set; }
    public DbSet<Contributer> Contributers { get; set; }
    public DbSet<Collection> Collections{ get; set; }
    public DbSet<CollectionFlashcard> CollectionFlashcards{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}
