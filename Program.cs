internal class Program
{
    private static void Main(string[] args)
    {
        int?[] args2 = new int?[5];

        Console.WriteLine(args2[0]);
        LinqQueries queries = new LinqQueries();
        
        ImprimirValores(queries.publish2005());
        // Console.WriteLine(queries.TrueStatus() ? "Todos los libros tienen Status" : "Almenos uno de los libros no tiene Status");
    }

    private static void ImprimirValores(IEnumerable<Book> books)
    {
        int registros = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("{0, -70} {1,7} {2,20}", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (Book book in books)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            registros += 1;
            Console.WriteLine("{0, -70} {1,7} {2,20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
    enum Color {
        Rojo,
        Verde
    }

    private static void ImprimirGrupos(IEnumerable<IGrouping<int, Book>> books)
    {
        foreach (var grp in books)
        {
            Console.WriteLine("");
            Console.WriteLine($"Grupo Nro : {grp.Key}");
            Console.WriteLine("{0, -70} {1,7} {2,20}", "Titulo", "N. Paginas", "Fecha Publicacion");
            foreach (var grpo in grp)
            {
            }
        }
    }
}