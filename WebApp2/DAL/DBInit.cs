using Microsoft.EntityFrameworkCore;
using WebApp2.Models;


namespace WebApp2.DAL;

public static class DBInit
{
    public static void Seed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        FlashcardDbContext context = serviceScope.ServiceProvider.GetRequiredService<FlashcardDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Inserting data in DB
        // Adding default flashcards
        if (!context.Flashcards.Any())
        {
            var flashcards = new List<Flashcard>()
            {
                new Flashcard() // bare fjern disse når dummy data legges til
                {
                    FlashcardId = 1,        
                    Name = "Test",
                    Description = "Test",
                    ImageUrl = "test.jpg"
                }
            };
            context.Flashcards.AddRange(flashcards);
            context.SaveChanges();
        }

        // Adding default contributers
        if (!context.Contributers.Any()) 
        {
            var contributers = new List<Contributer>
            {
                new Contributer() {Name = "Test Testesen"}, // Bare fjern disse når dummy data legges til
                new Contributer() {Name = "Test2 Test2sen"},
            };
            context.AddRange(contributers);
            context.SaveChanges();
        }

        // Adding default collections
        if(!context.Collections.Any())
        {
            var collections = new List<Collection>()
            {
                new Collection() {              
                    //CollectionId = 1, 
                    CollectionDate = "17.11.2023",
                    CollectionName = "English",
                    ContributerId = 2
                },
                new Collection() { 
                    //CollectionId = 2, 
                    CollectionDate = "17.11.2023",
                    CollectionName = "German",
                    ContributerId = 1,
                },
            };
            context.AddRange(collections);
            context.SaveChanges();
        }

        // Adding default collectionFlashcard relations
        if (!context.CollectionFlashcards.Any())
        {
            var collectionFlashcards = new List<CollectionFlashcard>()
            {
                new CollectionFlashcard() { CollectionId = 1, FlashcardId = 1},     // Bare fjern denne når dummy data kommer, men behold syntaks
                
            };
            context.AddRange(collectionFlashcards);
            context.SaveChanges();
        }

        // Updating Collection.TotalFlashcards to represent the number of collectionFlashcard attached
        var collectionsToUpdate = context.Collections.Include(o => o.CollectionFlashcard);
        foreach (var collection in collectionsToUpdate)
        {
            collection.TotalFlashcards += collection.CollectionFlashcard.Count;
        }
        context.SaveChanges();
    }
}
