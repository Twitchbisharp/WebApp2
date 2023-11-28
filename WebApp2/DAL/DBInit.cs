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
            var flashcards = new List<Flashcard>
                {
                    new Flashcard
                    {
                        Name = "Hus",
                        Description = "House",

                    },
                    new Flashcard
                    {
                        Name = "Bil",
                        Description = "Car",

                    },
                    new Flashcard
                    {
                        Name = "Sol",
                        Description = "Sun",

                    },
                    new Flashcard
                    {
                        Name = "Måne",
                        Description = "Moon",

                    },
                    new Flashcard
                    {
                        Name = "Kake",
                        Description = "Cake",

                    },
                    new Flashcard
                    {
                        Name = "Bok",
                        Description = "Book",

                    },
                    new Flashcard
                    {
                        Name = "Fisk",
                        Description = "Fish",

                    },
                    new Flashcard
                    {
                        Name = "Snø",
                        Description = "Snow",

                    },
                    new Flashcard
                    {
                        Name = "Regn",
                        Description = "Rain",

                    },
                    new Flashcard
                    {
                        Name = "Hund",
                        Description = "Dog",

                    },
                    new Flashcard
                    {
                        Name = "Katt",
                        Description = "Cat",

                    },
                    new Flashcard
                    {
                        Name = "Skole",
                        Description = "School",

                    },
                    new Flashcard
                    {
                        Name = "Tog",
                        Description = "Train",

                    },
                    new Flashcard
                    {
                        Name = "Blomst",
                        Description = "Flower",

                    },
                    new Flashcard
                    {
                        Name = "Seng",
                        Description = "Bed",

                    },
                    new Flashcard
                    {
                        Name = "Fugl",
                        Description = "Bird",

                    },
                    new Flashcard
                    {
                        Name = "By",
                        Description = "City",

                    },
                    new Flashcard
                    {
                        Name = "Menneske",
                        Description = "Human",

                    },
                    new Flashcard
                    {
                        Name = "Foreldre",
                        Description = "Parents",

                    },
                    new Flashcard
                    {
                        Name = "Land",
                        Description = "Country",

                    },
                    new Flashcard
                    {
                        Name = "Fader",
                        Description = "Vater",

                    },
                    new Flashcard
                    {
                        Name = "Moder",
                        Description = "Mutter",

                    },
                    new Flashcard
                    {
                        Name = "Broder",
                        Description = "Bruder",

                    },
                    new Flashcard
                    {
                        Name = "Snø",
                        Description = "Schnee",

                    },
                    new Flashcard
                    {
                        Name = "Bok",
                        Description = "Buch",

                    },
                    new Flashcard
                    {
                        Name = "Fugl",
                        Description = "Vogel",

                    },
                    new Flashcard
                    {
                        Name = "Tog",
                        Description = "Zug",

                    },
                    new Flashcard
                    {
                        Name = "Ambulanse",
                        Description = "Krankenwagen",

                    },
                    new Flashcard
                    {
                        Name = "By",
                        Description = "Stadt",

                    },
                    new Flashcard
                    {
                        Name = "Menneske",
                        Description = "Menschlich",

                    },
                    new Flashcard
                    {
                        Name = "Fisk",
                        Description = "Fisch",

                    },
                    new Flashcard
                    {
                        Name = "Katt",
                        Description = "Katze",

                    },
                    new Flashcard
                    {
                        Name = "Hund",
                        Description = "Hund",

                    },
                    new Flashcard
                    {
                        Name = "Regn",
                        Description = "Regen",

                    },
                    new Flashcard
                    {
                        Name = "Ungdomskole",
                        Description = "Mittelschule",

                    },
                    new Flashcard
                    {
                        Name = "Sol",
                        Description = "Sonne",

                    },
                    new Flashcard
                    {
                        Name = "Kylling",
                        Description = "Huhn",

                    },
                    new Flashcard
                    {
                        Name = "Fly",
                        Description = "Flugzeug",

                    },
                    new Flashcard
                    {
                        Name = "Blomst",
                        Description = "Blume",

                    },
                    new Flashcard
                    {
                        Name = "Vannflaske",
                        Description = "Waaserflasche",

                    },
                    new Flashcard
                    {
                        Name = "Østlandet",
                        Description = "Akershus",
                        ImageUrl = "/assets/images/Akershus.jpg"
                    },
                    new Flashcard
                    {
                        Name = "Østlandet",
                        Description = "Oslo",
                        ImageUrl = "/assets/images/Oslo.gif"
                    },
                    new Flashcard
                    {
                        Name = "Vestlandet",
                        Description = "Vestland",
                        ImageUrl = "/assets/images/Vestland.png"
                    },
                    new Flashcard
                    {
                        Name = "Vestlandet",
                        Description = "Rogaland",
                        ImageUrl = "/assets/images/Rogaland.jpg"
                    },
                    new Flashcard
                    {
                        Name = "Midt-Norge",
                        Description = "Trøndelag",
                        ImageUrl = "/assets/images/Trøndelag.svg"
                    },
                    new Flashcard
                    {
                        Name = "Østlandet",
                        Description = "Innlandet",
                        ImageUrl = "/assets/images/Innlandet.svg"
                    },
                    new Flashcard
                    {
                        Name = "Sørlandet",
                        Description = "Agder",
                        ImageUrl = "/assets/images/Agder.png"
                    },
                    new Flashcard
                    {
                        Name = "Østlandet",
                        Description = "Østfold",
                        ImageUrl = "/assets/images/Østfold.svg"
                    },
                    new Flashcard
                    {
                        Name = "Vestlandet",
                        Description = "Møre og Romsdal",
                        ImageUrl = "/assets/images/Møre og Romsdal.png"
                    },
                    new Flashcard
                    {
                        Name = "Østlandet",
                        Description = "Buskerud",
                        ImageUrl = "/assets/images/Buskerud.svg"
                    },
                    new Flashcard
                    {
                        Name = "Østlandet",
                        Description = "Vestfold",
                        ImageUrl = "/assets/images/Vestfold.jpg"
                    },
                    new Flashcard
                    {
                        Name = "Nord-Norge",
                        Description = "Nordland",
                        ImageUrl = "/assets/images/Nordland.png"
                    },
                    new Flashcard
                    {
                        Name = "Sørlandet",
                        Description = "Telemark",
                        ImageUrl = "/assets/images/Telemark.jpg"
                    },
                    new Flashcard
                    {
                        Name = "Nord-Norge",
                        Description = "Troms",
                        ImageUrl = "/assets/images/Troms.svg"
                    },
                    new Flashcard
                    {
                        Name = "Nord-Norge",
                        Description = "Finnmark",
                        ImageUrl = "/assets/images/Finnmark.svg"
                    },
                    new Flashcard
                    {
                        Name = "West Coast",
                        Description = "California",
                        ImageUrl = "/assets/images/California.png"
                    },
                    new Flashcard
                    {
                        Name = "Southwest",
                        Description = "Texas",
                        ImageUrl = "/assets/images/Texas.png"
                    },
                    new Flashcard
                    {
                        Name = "Northeast",
                        Description = "New York",
                        ImageUrl = "/assets/images/New York.png"
                    },
                    new Flashcard
                    {
                        Name = "Southeast",
                        Description = "Florida",
                        ImageUrl = "/assets/images/Florida.png"
                    },
                    new Flashcard
                    {
                        Name = "Midwest",
                        Description = "Illinois",
                        ImageUrl = "/assets/images/Illinois.png"
                    },
                    new Flashcard
                    {
                        Name = "Northeast",
                        Description = "Pennsylvania",
                        ImageUrl = "/assets/images/Pennsylvania.png"
                    },
                    new Flashcard
                    {
                        Name = "Midwest",
                        Description = "Ohio",
                        ImageUrl = "/assets/images/Ohio.png"
                    },
                    new Flashcard
                    {
                        Name = "Southeast",
                        Description = "Georgia",
                        ImageUrl = "/assets/images/Georgia.png"
                    },
                    new Flashcard
                    {
                        Name = "Southeast",
                        Description = "North Carolina",
                        ImageUrl = "/assets/images/North Carolina.png"
                    },
                    new Flashcard
                    {
                        Name = "Midwest",
                        Description = "Michigan",
                        ImageUrl = "/assets/images/Michigan.png"
                    },
                    new Flashcard
                    {
                        Name = "Southwest",
                        Description = "Arizona",
                        ImageUrl = "/assets/images/Arizona.png"
                    },
                    new Flashcard
                    {
                        Name = "Northeast",
                        Description = "New Jersey",
                        ImageUrl = "/assets/images/New Jersey.png"
                    },
                    new Flashcard
                    {
                        Name = "Southeast",
                        Description = "Virginia",
                        ImageUrl = "/assets/images/Virginia.png"
                    },
                    new Flashcard
                    {
                        Name = "West Coast",
                        Description = "Washington",
                        ImageUrl = "/assets/images/Washington.png"
                    },
                    new Flashcard
                    {
                        Name = "Rocky Mountain region",
                        Description = "Colorado",
                        ImageUrl = "/assets/images/Colorado.png"
                    },
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
                    CollectionId = 1,
                    CollectionDate = "17.11.2023",
                    CollectionName = "English",
                    ContributerId = 2
                },
                new Collection() {
                    CollectionId = 2,
                    CollectionDate = "17.11.2023",
                    CollectionName = "German",
                    ContributerId = 1,
                },
                new Collection() {
                    CollectionId = 3,
                    CollectionDate = "16.11.2023",
                    CollectionName = "somethignelse",
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
                new CollectionFlashcard() { CollectionId = 1, FlashcardId = 2 },
            };
            context.AddRange(collectionFlashcards);
            context.SaveChanges();
        }

        // Updating Collection.TotalFlashcards to represent the number of collectionFlashcard attached
        //var collectionsToUpdate = context.Collections.Include(o => o.CollectionFlashcard);
        //foreach (var collection in collectionsToUpdate)
        //{
        //    collection.TotalFlashcards += collection.CollectionFlashcard.Count;
        //}
        //context.SaveChanges();
    }
}
