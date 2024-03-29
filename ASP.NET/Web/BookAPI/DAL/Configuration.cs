﻿using System.Data.Entity.Migrations;
using BookAPI.Models;

namespace BookAPI.DAL
{
    public class Configuration : DbMigrationsConfiguration<BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BooksContext context)
        {
            context.Reviews.AddOrUpdate(new Review { BookId = 1, Id = 1, Rating = 4, Description = "Enjoyed book a lot!" });
            context.Reviews.AddOrUpdate(new Review { BookId = 1, Id = 2, Rating = 4, Description = "Great book, bit short." });
            context.Reviews.AddOrUpdate(new Review { BookId = 1, Id = 3, Rating = 3, Description = "Good book, wouldn't read twice." });

            context.Reviews.AddOrUpdate(new Review { BookId = 2, Id = 4, Rating = 5, Description = "Stunning!" });
            context.Reviews.AddOrUpdate(new Review { BookId = 2, Id = 5, Rating = 5, Description = "Best book ever?" });
            context.Reviews.AddOrUpdate(new Review { BookId = 2, Id = 6, Rating = 5, Description = "My favourite book of all time." });

            context.Reviews.AddOrUpdate(new Review { BookId = 3, Id = 7, Rating = 4, Description = "Fun read." });
            context.Reviews.AddOrUpdate(new Review { BookId = 3, Id = 8, Rating = 4, Description = "Good casual read." });
            context.Reviews.AddOrUpdate(new Review { BookId = 3, Id = 9, Rating = 5, Description = "Good but not a serious self help book." });

            context.Reviews.AddOrUpdate(new Review { BookId = 4, Id = 10, Rating = 3, Description = "Great for newbies" });
            context.Reviews.AddOrUpdate(new Review { BookId = 4, Id = 11, Rating = 4, Description = "Good, some points are common sense though" });
            context.Reviews.AddOrUpdate(new Review { BookId = 4, Id = 12, Rating = 3, Description = "Not great for experienced investors" });

            context.Reviews.AddOrUpdate(new Review { BookId = 5, Id = 13, Rating = 3, Description = "1st half of the book awesome, 2nd half..terrible" });
            context.Reviews.AddOrUpdate(new Review { BookId = 5, Id = 14, Rating = 4, Description = "Found the book a bit monotonous after a while" });
            context.Reviews.AddOrUpdate(new Review { BookId = 5, Id = 15, Rating = 5, Description = "Enjoyed would fully recommend! Don't have to be a maths whizz to appreciate this" });

            context.Reviews.AddOrUpdate(new Review { BookId = 6, Id = 16, Rating = 5, Description = "Much better than the film" });
            context.Reviews.AddOrUpdate(new Review { BookId = 6, Id = 17, Rating = 4, Description = "Educational" });
            context.Reviews.AddOrUpdate(new Review { BookId = 6, Id = 18, Rating = 3, Description = "Very long" });


            context.Books.AddOrUpdate(new Book
            {
                Id = 1,
                Title = "Millionnaire Fastlane",
                Description = "Is the financial plan of mediocrity -- a dream-stealing, soul-sucking dogma known as \"The Slowlane\" your plan for creating wealth? You know how it goes; it sounds a little something like this: \"Go to school, get a good job, save 10 % of your paycheck, buy a used car, cancel the movie channels, quit drinking expensive Starbucks lattes, save and penny - pinch your life away, trust your life - savings to the stock market, and one day, when you are oh, say, 65 years old, you can retire rich.\"",
                Price = 14.51m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/514kBeGrXDL._SX331_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = 2,
                Title = "The Martian",
                Description = "I’m stranded on Mars.  I have no way to communicate with Earth.  I’m in a Habitat designed to last 31 days.",
                Price = 4m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/51xjFVB0AkL._SX312_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = 3,
                Title = "Richest Man in Babylon",
                Description = "This timeless book holds that the key to success lies in the secrets of the ancients. Based on the famous \"Babylonian principles,\" it's been hailed as the greatest of all inspirational works on the subject of thrift and financial planning.",
                Price = 0.99m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/41JGlyCt5NL._SX326_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = 4,
                Title = "100 Property Investment Tips",
                Description = "Rob Dix and Rob Bence are the founders of The Property Hub community, and hosts of The Property Podcast - the UK’s most popular business podcast. They’ve compiled advice from 30 experts and added their own insights to cover a huge range of property-related topics.",
                Price = 3.58m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/41hi2zpZ1uL._SX311_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = 5,
                Title = "Why Does E=mc2?",
                Description = "The most accessible, entertaining, and enlightening explanation of the best-known physics equation in the world, as rendered by two of today’s leading scientists.",
                Price = 5.98m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/3148zK20NuL._SX327_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = 6,
                Title = "A Beautiful Mind",
                Description = "A Beautiful Mind is Sylvia Nasar's award-winning biography about the mystery of the human mind, the triumph over incredible adversity, and the healing power of love.",
                Price = 6.99m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/41pmjXYdOHL._SX309_BO1,204,203,200_.jpg"
            });

            context.SaveChanges();
        }
    }
}