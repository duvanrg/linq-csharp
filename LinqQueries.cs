
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
    public IEnumerable<Book> containPy()
    {
        if (lstBooks.Any(book => book.Categories.Contains("Python")))
        {
            return from book in lstBooks where book.Categories.Contains("Python") select book;
        }
        Console.WriteLine("No Existen libros de la categoria python");
        Console.ReadKey();
        return new List<Book>();
    }

    public IEnumerable<Book> orderJava()
    {
        if (lstBooks.Any(book => book.Categories.Contains("Java")))
        {
            var java = from book in lstBooks where book.Categories.Contains("Java") select book;
            return java.OrderBy(book => book.Title);
        }
        Console.WriteLine("No Existen libros de la categoria Java");
        Console.ReadKey();
        return new List<Book>();
    }
    public IEnumerable<Book> orderDescending450()
    {
        return lstBooks.Where(book => book.PageCount > 450).OrderByDescending(book => book.PageCount);
    }
    public IEnumerable<Book> first3books()
    {
        return lstBooks.Where(
            book => book.Categories.Contains("Java") 
        ).OrderByDescending(book => book.PublishedDate).Take(3);
    }
    public IEnumerable<Book> books4and5()
    {
        return lstBooks.Where(
            book => book.PageCount > 400
        ).Take(4).Skip(2);
    }
    public IEnumerable<Book> selectTitleAndPages()
    {
        return lstBooks.Take(3).Select(book => new Book{Title = book.Title, PageCount = book.PageCount});
    }

    public int GetBookCounts( )
    {
        return lstBooks.Where(book => book.PageCount >= 200 && book.PageCount <= 500).Count();
    }
    public long GetBookLongCounts( )
    {
        return lstBooks.Where(book => book.PageCount >= 200 && book.PageCount <= 500).LongCount();
    }
    public DateTime selectMinDate()
    {
        return lstBooks.Min(book => book.publishedDate);
        //return lstBooks.where(book => book.Min(book.publishedDate));
    }

    public int selectMaxPage()
    {
        return lstBooks.Max(book => book.PageCount);
        //return lstBooks.where(book => book.Max(book.PageCount));
    }

    public Book selectBetweenMore0 ()
    {
        return lstBooks.Where(book => book.PageCount > 0).MinBy(myBook => myBook.PageCount);
    }

    public Book selectMaxDate()
    {
        return lstBooks.MaxBy(book => book.PublishedDate);
    }

    public int selectSumPages()
    {
        return lstBooks.where(book => book.pageCount >= 0 && book.pageCount <= 500).Sum(myBook => myBook.pageCount);
    }

    public IEnumerable<Book> getDateUp2015()
    {
        //return lstBooks.Where(book => new book {if(book.publishedDate.Year > 2015) Title = book.Title});
        return lstBooks.Where(book => book.publishedDate.Year > 2015).Agreggate(myBook => myBook.Title);
    }

    public bool Truepublish2005()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        return lstBooks.Any(book => book.PublishedDate.Year == 2005);
        
    }

}