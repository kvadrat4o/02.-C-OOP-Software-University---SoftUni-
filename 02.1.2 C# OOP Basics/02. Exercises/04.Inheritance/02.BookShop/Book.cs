using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book()
    {

    }

    public Book(string author, string title, decimal price)
    {
        this.Price = price;
        this.Author = author;
        this.Title = title;
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    protected string Author
    {
        get { return author; }
        set
        {

            var tokens = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 1)
            {
                if (Char.IsDigit(tokens[1].First()))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }

    protected string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }


    public override string ToString()
    {
        return $"Type: {this.GetType()}\nTitle: {this.Title}\nAuthor: {this.Author}\nPrice: {this.Price:f2}";
    }
}
