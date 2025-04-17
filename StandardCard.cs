/*
*   Copyright (c) 2025 Alan Larimer
*   MIT License
*   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED ...
*/

namespace AwFuL.PlayingCard;

public enum StandardRank : int
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}
public enum StandardSuit
{
    Hearts,
    Clubs,
    Diamonds,
    Spades
}

public class StandardCard : IEquatable<StandardCard>
{
    public StandardRank Rank { get; }
    public StandardSuit Suit { get; }

    public StandardCard(StandardRank rank, StandardSuit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }

    public bool Equals(StandardCard? other)
    {
        return other != null && Rank == other.Rank && Suit == other.Suit;
    }

    #region overrides IEquatable
    // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1067
    public override bool Equals(object? obj)
    {
        return obj is StandardCard objCard && Equals(objCard);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    #endregion
}
