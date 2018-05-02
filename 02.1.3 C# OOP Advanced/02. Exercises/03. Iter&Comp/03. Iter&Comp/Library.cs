using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>
{
    public SortedSet<Book> books { get; set; }

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        public Book Current => this.Books[currentIndex];

        object IEnumerator.Current => this.Current;

        public int currentIndex { get; set; }

        public  List<Book> Books { get; set; }

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Books = new List<Book>(books);
            this.Reset();
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            return ++currentIndex < this.Books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }

}