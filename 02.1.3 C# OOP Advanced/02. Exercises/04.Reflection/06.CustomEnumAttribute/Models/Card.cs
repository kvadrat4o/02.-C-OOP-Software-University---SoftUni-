using System;
using System.Collections.Generic;
using System.Text;

public class Card : IComparable<Card>
{
    private CardSuit cardSuit { get; set; }

    private CardRank cardRank { get; set; }

    public int cardPower => (int)this.cardSuit + (int)this.cardRank;

    public Card(CardSuit suit, CardRank rank)
    {
        this.cardRank = rank;
        this.cardSuit = suit;
    }

    public override string ToString()
    {
        return $"Card name: {this.cardRank} of {this.cardSuit}; Card power: {this.cardPower}";
    }

    

    public int CompareTo(Card other)
    {
        return this.cardPower.CompareTo(other.cardPower);
    }
}