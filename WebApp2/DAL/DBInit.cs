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
        if (!context.Flashcards.Any());
 }
}
