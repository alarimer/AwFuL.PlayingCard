/*
*   Copyright (c) 2025 Alan Larimer
*   MIT License
*   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED ...
*/

namespace AwFuL.PlayingCard;

public class CardDeck : IEquatable<CardDeck>
{
    private List<StandardCard> _cards;
    public int CardCount { get => _cards.Count; }

    public CardDeck() => _cards = new();

    public static CardDeck CreateStandard52CardDeck()
    {
        CardDeck newDeck = new();

        foreach (StandardRank r in (StandardRank[])Enum.GetValues(typeof(StandardRank)))
        {
            foreach (StandardSuit s in (StandardSuit[])Enum.GetValues(typeof(StandardSuit)))
            {
                newDeck.AddCard(new StandardCard(r, s));
            }
        }

        return newDeck;
    }

    public void AddCard(StandardCard card) => _cards.Add(card);

    public void Shuffle()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("There are no cards to shuffle.");
        }

        _cards = _cards.OrderBy(c => Random.Shared.Next()).ToList();
    }

    public StandardCard DrawCard()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("There are no cards to draw.");
        }

        StandardCard drawnCard = _cards[0];
        _cards.Remove(drawnCard);
        return drawnCard;
    }

    public bool Equals(CardDeck? other)
    {
        return other != null && _cards.SequenceEqual(other._cards);
    }

    #region overrides IEquatable
    // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1067
    public override bool Equals(object? obj)
    {
        return obj is CardDeck objDeck && Equals(objDeck);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    #endregion
}
