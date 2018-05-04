using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Data;
using BookShopSystem.Models;

namespace BookShopSystem
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();

            // 1. Book title by age restriction
            BookTitleByAge(context);

            // 2. Golden Books
            //GoldenBooks(context);

            // 3. Books by price
            //BooksByPrice(context);

            // 4. Not released book
            //NotReleasedBook(context);

            // 5. Book titles by category
            //BookTitleByCategory(context);

            // 6. Books released before date
            //ReleasedBookBeforeDate(context);

            // 7. Authors search
            //AuthorsSearch(context);

            // 8. Books search
            //BookSearch(context);

            // 9. Book title search
            //BooksTitleSearch(context);

            // 10. Count books
            //CountBooks(context);

            // 11. Total book copies
            //TotalBookCopies(context);

            // 12. Find profit
            //FindProfit(context);

            // 13. Most recent Books
            //MostRecentBooks(context);

            // 14. Increase books copies
            //IncreseCopiesOfBooks(context);

            // 15. Remove books
            //RemoveBooks(context);

            // 16. Stored procedure
            //GetBooksCount(context);

            
        }

        private static void GetBooksCount(BookShopContext context)
        {
            string[] name = Console.ReadLine().Split(' ');
            string firstName = name[0];
            string lastName = name[1];
            var result = context.Database.SqlQuery<int>("exec dbo.usp_GetBooksCount {0}, {1}", firstName, lastName).First();

            Console.WriteLine(result);
        }

        private static void RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();
            Console.WriteLine($"{books.Count} books were deleted");
            foreach (var b in books)
            {
                context.Books.Remove(b);
                context.SaveChanges();
            }
        }

        private static void IncreseCopiesOfBooks(BookShopContext context)
        {
            var released = new DateTime(2013, 6, 6);
            var books = context.Books.Where(b => b.ReleaseDate > released).ToList();
            var count = 0;
            foreach (var b in books)
            {
                b.Copies += 44;
                count += 44;
                context.SaveChanges();
            }
            Console.WriteLine($"{count}");
        }

        private static void MostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.Where(b => b.Books.Count > 35).Select(c => new
            {
                categoryName = c.Name,
                bookCount = c.Books.Count,
                books = c.Books.OrderByDescending(b => b.ReleaseDate).ThenBy(b => b.Title).Take(3),
            }).OrderByDescending(b => b.bookCount).ToList();

            foreach (var c in categories)
            {
                Console.WriteLine($"--{c.categoryName}: {c.bookCount} books");
                foreach (var b in c.books)
                {
                    Console.WriteLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }

            }
        }

        private static void FindProfit(BookShopContext context)
        {
            var categories = context.Categories.Select(a => new
            {
                categoryName = a.Name,
                profit = a.Books.Sum(b => b.Copies * b.Price)
            }).OrderByDescending(b => b.profit).ThenBy(b => b.categoryName).ToList();

            foreach (var c in categories)
            {
                Console.WriteLine($"{c.categoryName} {c.profit}");
            }
        }

        private static void TotalBookCopies(BookShopContext context)
        {
            var books = context.Books.GroupBy(a => a.Author).OrderByDescending(a => a.Key.Books.Sum(c => c.Copies)).ToList();
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Key.FirstName} {b.Key.LastName} {b.Key.Books.Sum(s => s.Copies)}");
            }
        }

        private static void CountBooks(BookShopContext context)
        {
            var num = int.Parse(Console.ReadLine());

            var books = context.Books.Count(b => b.Title.Length > num);
            Console.WriteLine(books);
        }

        private static void BooksTitleSearch(BookShopContext context)
        {
            var input = Console.ReadLine();
            var books = context.Books.Where(b => b.Author.LastName.StartsWith(input)).OrderBy(b => b.Id).ToList();
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Title} ({b.Author.FirstName} {b.Author.LastName})");
            }
        }

        private static void BookSearch(BookShopContext context)
        {
            var input = Console.ReadLine().ToLower();
            var books = context.Books.Where(b => b.Title.ToLower().Contains(input)).ToList();

            foreach (var b in books)
            {
                Console.WriteLine(b.Title);
            }
        }

        private static void AuthorsSearch(BookShopContext context)
        {
            var input = Console.ReadLine();

            var author = context.Authors.Where(c => c.FirstName.EndsWith(input)).ToList();
            foreach (var a in author)
            {
                Console.WriteLine($"{a.FirstName} {a.LastName}");
            }
        }

        private static void ReleasedBookBeforeDate(BookShopContext context)
        {
            var inputDate = DateTime.Parse(Console.ReadLine());
            var book = context.Books.Where(b => b.ReleaseDate < inputDate).ToList();
            foreach (var b in book)
            {
                Console.WriteLine($"{b.Title} - {b.EditionType} - {b.Price}");
            }
        }

        private static void BookTitleByCategory(BookShopContext context)
        {
            var categories =
                            Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var books = context.Books.Where(b => b.Categories.Any(c => categories.Contains(c.Name))).OrderBy(b => b.Id).ToList();
            foreach (var b in books)
            {
                Console.WriteLine(b.Title);
            }
        }

        private static void NotReleasedBook(BookShopContext context)
        {
            var yearOfRelease = int.Parse(Console.ReadLine());
            var book = context.Books.Where(b => b.ReleaseDate.Value.Year != yearOfRelease).ToList();
            foreach (var b in book)
            {
                Console.WriteLine(b.Title);
            }
        }

        private static void BooksByPrice(BookShopContext context)
        {
            var book = context.Books.Where(b => b.Price < 5 || b.Price > 40).OrderBy(b => b.Id).ToList();
            foreach (var b in book)
            {
                Console.WriteLine($"{b.Title} - ${b.Price}");
            }
        }

        private static void GoldenBooks(BookShopContext context)
        {
            var book = context.Books.Where(b => b.EditionType == Models.EditionType.Gold && b.Copies < 5000).OrderBy(b => b.Id).ToList();
            foreach (var b in book)
            {
                Console.WriteLine(b.Title);
            }
        }

        private static void BookTitleByAge(BookShopContext context)
        {
            var input = Console.ReadLine().ToLower();
            var book = context.Books.Where(b => b.AgeRestriction.ToString().ToLower() == input).ToList();

            foreach (var b in book)
            {
                Console.WriteLine(b.Title);
            }
        }
    }
}
