
public class LinqQueries
{
#nullable disable
    List<Book> lstBooks = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.lstBooks = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? new List<Book>();
        }
    }

    public IEnumerable<Book> AllCollection()
    {
        return lstBooks;
    }

    public IEnumerable<Book> LibrosDespues2000()
    {
        return from book in lstBooks where book.PublishedDate.Year > 2000 select book;
    }
    public IEnumerable<Book> OnlyAndroid()
    {
        return from book in lstBooks where book.Title.Contains("Android") select book;
    }
    public IEnumerable<Book> OnlyAndroid2005()
    {
        return from book in lstBooks where book.Title.Contains("Android") && book.PublishedDate.Year > 2005 select book;
    }
    public IEnumerable<Book> page250Action()
    {
        return from book in lstBooks where book.Title.Contains("Action") && book.PageCount > 250 select book;
    }
    public bool TrueStatus()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        return lstBooks.All(book => book.Status != null);
    }
    public IEnumerable<Book> publish2005()
    {
        if (Truepublish2005())
            return from book in lstBooks where book.PublishedDate.Year == 2005 select book;
        Console.WriteLine("No Existen libros publicados en el 2005");
        Console.ReadKey();
        return new List<Book>();

    }
    public bool Truepublish2005()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        return lstBooks.Any(book => book.PublishedDate.Year == 2005);
    }

}