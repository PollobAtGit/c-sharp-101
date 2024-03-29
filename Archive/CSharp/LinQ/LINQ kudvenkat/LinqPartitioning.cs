using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPartitioning
{
    delegate string OverrideOfObject();

    //Poi: Delegate instances contain a 'Target' property for the registered methods. This 'Target' property is generated by invoking
    //'ToString()' on that instance

    internal class Book
    {
        public override string ToString() => "Book";
        public new string GetHashCode() => "";
        public string Equals() => "";
    }

    internal class Author
    {
        public override string ToString() => "Author";
        public new string GetHashCode() => "";
        public string Equals() => "";
    }

    public class Client
    {
        private static readonly Book _book;
        private static readonly Author _author;

        static Client()
        {
            _book = new Book();
            _author = new Author();
        }

        public static void Main()
        {
            Book _book = new Book();
            Author _author = new Author();

            OverrideOfObject[] delegates = new OverrideOfObject[]
            {
                _book.ToString,
                _book.GetHashCode,
                _author.ToString,
                _author.GetHashCode,
                _book.Equals,
                _author.Equals
            };

            //Poi: 'Target' returns object not string
            //Poi: ToString() on Delegate.Target works properly but not cast as follows: (del.Target as string)
            //Poi: Target property of Delegate returns Object

            IEnumerable<OverrideOfObject> firstThreeDelegates = delegates.Take<OverrideOfObject>(3);
            IEnumerable<OverrideOfObject> lastThreeDelegates = delegates.Skip<OverrideOfObject>(3);
            IEnumerable<OverrideOfObject> authorDelegates = delegates.Where<OverrideOfObject>(del => del.Target.ToString() == "Author");
            var bookDelegates = delegates.Where<OverrideOfObject>(del => del.Target.ToString() == "Book");
            IEnumerable<OverrideOfObject> firstBookDelegates = delegates.TakeWhile<OverrideOfObject>(del => del.Target.ToString() == "Book");
            var skipFirstBookDelegates = delegates.SkipWhile<OverrideOfObject>(del => del.Target.ToString() == "Book");
            var skipFirstAuthorDelegates = delegates.SkipWhile<OverrideOfObject>(del => del.Target.ToString() == "Author");

            //Poi: Note this resultset. 'firstAuthorDelegates' contains EMPTY
            var firstAuthorDelegates = delegates.TakeWhile<OverrideOfObject>(del => del.Target.ToString() == "Author");

            IterateOverSequence("firstThreeDelegates", firstThreeDelegates);
            IterateOverSequence("lastThreeDelegates", lastThreeDelegates);
            IterateOverSequence("bookDelegates", bookDelegates);
            IterateOverSequence("authorDelegates", authorDelegates);
            IterateOverSequence("firstBookDelegates", firstBookDelegates);
            IterateOverSequence("firstAuthorDelegates", firstAuthorDelegates);
            IterateOverSequence("skipFirstBookDelegates", skipFirstBookDelegates);
            IterateOverSequence("skipFirstAuthorDelegates", skipFirstAuthorDelegates);
        }

        static void IterateOverSequence(string msg, IEnumerable<Delegate> source)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            foreach(Delegate item in source)
            {
                Console.WriteLine(item.Method + "\t" + item.Target);
            }
        }
    }
}