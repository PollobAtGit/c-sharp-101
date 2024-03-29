using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LinqToTextFiles
{
    internal static class Client
    {
        private static string[] LinesFromTxt;

        static Client()
        {
            LinesFromTxt = File.ReadAllLines("DummyData.csv");
        }

        public static void Main()
        {

            //Poi: Note the 'TSource' in 2nd 'Select' where 'Book' objects are being created. Here input is IEnumerable<string> which is
            //the output from 1st Select where TResult is generated by '.Split'

            IEnumerable<Book> filteredLines = LinesFromTxt
                .Where<string>(line => !line.StartsWith("#"))
                .Select<string, IEnumerable<string>>(line => line.Split(','))
                .Select<IEnumerable<string>, Book>(info =>
                    new Book
                    {
                        Isbn = (info as string[])[0],
                        Title = (info as string[])[1],
                        Authors = (info as string[])[2].Split(';')
                    });

            filteredLines.IterateOverSequence<Book>();
            filteredLines.ForEach<Book>(book => Console.WriteLine(book));
        }

        private static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            if(source == null) return;

            Console.WriteLine();
            try
            {
                foreach(T item in source)
                    func(item);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void IterateOverSequence<T>(this IEnumerable<T> source)
        {
            if(source == null) return;
            try
            {
                Console.WriteLine();
                foreach(T item in source)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private class Book
        {
            public String Isbn {get; set;}
            public String Title {get; set;}
            public string[] Authors { get; set; }

            public override string ToString() => "Isbn => " + Isbn + "\tTitle => " + Title + "\tAuthors => " + string.Join(", ", Authors);
        }
    }
}