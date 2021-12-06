using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AdventOfCode.Day4
{
    public class BingoGame
    {
        public List<Card> Cards = new();
        public List<int> Input = new();

        public Card LastCardToWin;
        public int Last;

        public Card Play()
        {
            foreach (var i in Input)
            {
                foreach (var card in Cards)
                {
                    card.Mark(i);
                    if (!card.Won && card.HasWon())
                    {
                        Last = i;
                        LastCardToWin = Card.Clone(card);
                    }
                }

                Log();
            }
            
            return LastCardToWin;
        }

        public void Log()
        {
            foreach (var card in Cards)
            {
                foreach (var row in card.Rows)
                {
                    Console.WriteLine(row.ToString());
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("----------------");
        }

        public static BingoGame Parse(string input)
        {
            var game = new BingoGame();
            var split = input.Split("\n\n");
            game.Input = split[0].Split(',').Select(int.Parse).ToList();
            foreach (var s in split.Skip(1))
            {
                var l = s.Split("\n");
                var rows = l.Select(Row.Parse);
                game.Cards.Add(new Card
                {
                    Rows = rows.ToArray()
                });
            }

            return game;
        }
    }

    public class Card
    {
        public bool Won;
        public Row[] Rows;

        public void Mark(int number)
        {
            foreach (var row in Rows)
            {
                row.Mark(number);
            }
        }

        public bool HasWon()
        {
            if (Rows.Any(row => row.IsComplete()))
            {
                Won = true;
                return Won;
            }

            for (var i = 0; i < Rows.First().Numbers.Length; i++)
            {
                if (Rows.All(row => row.IsMarked(i)))
                {
                    Won = true;
                    return Won;
                }
            }

            return false;
        }
        
        public static Card Clone(Card source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<Card>(serialized);
        }
    }

    public class Row
    {
        public Number[] Numbers;

        public void Mark(int n)
        {
            foreach (var t in Numbers)
            {
                if (t.Value != n) continue;
                t.Marked = true;
                break;
            }
        }

        public bool IsMarked(int index)
            => Numbers[index].Marked;

        public bool IsComplete()
            => Numbers.All(x => x.Marked);


        public override string ToString()
        {
            return Numbers.Aggregate(string.Empty,
                (current, n) => current + " " + n.Value + (n.Marked ? "m " : " "));
        }

        public static Row Parse(string input)
        {
            return new()
            {
                Numbers = input.Split(" ").Where(x => x != "").Select(x => new Number
                {
                    Value = int.Parse(x.Trim())
                }).ToArray()
            };
        }
    }

    public class Number
    {
        public int Value;
        public bool Marked = false;
    }
}