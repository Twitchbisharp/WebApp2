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
                new Contributer() {Name = "Hans Schwanz"}, 
                new Contributer() {Name = "John Smith"},
                new Contributer() {Name = "Ola Normann"},
                new Contributer() {Name = "Sean Pierce"}
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
                    CollectionDate = "28.11.2023",
                    CollectionName = "Norway",
                    ContributerId = 3,
                },
                new Collection() {
                    CollectionId = 4,
                    CollectionDate = "28.11.2023",
                    CollectionName = "USA",
                    ContributerId = 4,
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
                // English
                new CollectionFlashcard {FlashcardId = 1, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 2, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 3, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 4, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 5, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 6, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 7, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 8, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 9, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 10, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 11, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 12, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 13, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 14, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 15, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 16, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 17, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 18, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 19, CollectionId = 1 },
                new CollectionFlashcard {FlashcardId = 20, CollectionId = 1 },

                //German
                new CollectionFlashcard { FlashcardId = 21, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 22, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 23, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 24, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 25, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 26, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 27, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 28, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 29, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 30, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 31, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 32, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 33, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 34, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 35, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 36, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 37, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 38, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 39, CollectionId = 2 },
                new CollectionFlashcard { FlashcardId = 40, CollectionId = 2 },

                //Norway
                new CollectionFlashcard { FlashcardId = 41, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 42, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 43, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 44, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 45, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 46, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 47, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 48, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 49, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 50, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 51, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 52, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 53, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 54, CollectionId = 3 },
                new CollectionFlashcard { FlashcardId = 55, CollectionId = 3 },
                
                //USA
                new CollectionFlashcard { FlashcardId = 56, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 57, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 58, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 59, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 60, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 61, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 62, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 63, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 64, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 65, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 66, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 67, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 68, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 69, CollectionId = 4 },
                new CollectionFlashcard { FlashcardId = 70, CollectionId = 4 },
            };
            context.AddRange(collectionFlashcards);
            context.SaveChanges();
        }

        //Updating Collection.TotalFlashcards to represent the number of collectionFlashcard attached
        var collectionsToUpdate = context.Collections.Include(o => o.CollectionFlashcard);
        foreach (var collection in collectionsToUpdate)
        {
            collection.TotalFlashcards += collection.CollectionFlashcard.Count;
        }
        context.SaveChanges();
    }
}
