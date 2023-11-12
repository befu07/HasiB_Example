using ClassLibrary;

namespace ReadCSVFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = BookLoader.Books;

            var dreiBuecherAusDerMitte = books.GetRange(books.Count/2, 3);
            foreach (var book in dreiBuecherAusDerMitte) 
            {
                Console.WriteLine(book.Id + " " + book.Titel);
            }
        }
    }
}