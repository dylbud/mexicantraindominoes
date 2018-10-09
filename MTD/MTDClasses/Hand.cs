using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Represents a hand of dominos
    /// </summary>
    public class Hand
    {

        /// <summary>
        /// The list of dominos in the hand
        /// </summary>
        private List<Domino> handOfDominos = new List<Domino>();

        /// <summary>
        /// Creates an empty hand
        /// </summary>
        public Hand()
        {
        }

        /// <summary>
        /// Creates a hand of dominos from the boneyard.-switch statement and a for loop
        /// The number of dominos is based on the number of players
        /// 2–4 players: 10 dominoes each
        /// 5–6 players: 9 dominoes each
        /// 7–8 players: 7 dominoes each
        /// </summary>
        /// <param name="by"></param>
        /// <param name="numPlayers"></param>
        public Hand(BoneYard by, int numPlayers)
        {
            int numDominoes = 0;
            switch (numPlayers)
            {
                case 2:
                case 3:
                case 4:
                    numDominoes = 10;                   
                    break;
                case 5:
                case 6:
                    numDominoes = 9;
                    break;
                case 7:
                case 8:
                    numDominoes = 7;
                    break;
            }
            for (int i = 0; i< numDominoes; i++)
            {
                this.Add(by.Draw());
            }
        }

        public void Add(Domino d)
        {
            handOfDominos.Add(d);
        }
        
        
        /// <summary>
        /// Returns the count of the list of dominoes
        /// </summary>
        public int Count
        {
            get
            {
                return handOfDominos.Count;
            }
         
        }

        public bool IsEmpty
        {
            get
            {
                if (Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Sum of the score of each domino in the hand
        /// </summary>
        public int Score
        {
            get
            {
                int score = 0;
                for (int i = 0; i < Count; i++)
                {
                    score = score + this[i].Score;
                }
                return score;
            }
        }

        /// <summary>
        /// Does the hand contain a domino with value in side 1 or side 2?
        /// </summary>
        /// <param name="value">The number of dots on one side of the domino that you're looking for</param>
        public bool HasDomino(int value)
        {
            for (int i = 0; i< Count; i++)
            {
                if (this[i].Side1 == value || this[i].Side2 == value)
                {
                    return true;
                }
            }             
            return false;            
        }

        /// <summary>
        ///  DOes the hand contain a double of a certain value?
        ///  for loop goes through the hand and checks with an if statement
        /// </summary>
        /// <param name="value">The number of (double) dots that you're looking for</param>
        public bool HasDoubleDomino(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Side1 == value && this[i].Side2 == value)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// The index of a domino with a value in the hand
        /// </summary>
        /// <param name="value">The number of dots on one side of the domino that you're looking for</param>
        /// <returns>-1 if the domino doesn't exist in the hand</returns>
        /// <remarks>What if there is more than one that matches the value? Return the first one?</remarks>
        public int IndexOfDomino(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Side1 == value || this[i].Side2 == value)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// The index of the do
        /// </summary>
        /// <param name="value">The number of (double) dots that you're looking for</param>
        /// <returns>-1 if the domino doesn't exist in the hand</returns>
        public int IndexOfDoubleDomino(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Side1 == value && this[i].Side2 == value)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// The index of the highest double domino in the hand
        /// </summary>
        /// <returns>-1 if there isn't a double in the hand</returns>
        public int IndexOfHighDouble()
        {        
            int highDouble = -1;
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (this[i].IsDouble())
                {
                    if (this[i].Side1 > highDouble)
                    {
                        highDouble = this[i].Side1;
                        index = i;
                    }
                }
            }
            return index;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Domino this[int index]
        {
            get
            {
                return handOfDominos[index];
            }
        }

        /// <summary>
        /// Remove at list 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            Domino domino;
            domino = this[index];
            handOfDominos.Remove(domino);
            
        }

        /// <summary>
        /// Finds a domino with a certain number of dots in the hand.
        /// If it can find the domino, it removes it from the hand and returns it.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Domino GetDomino(int value)
        {
            Domino domino;

            if (HasDomino(value))
            {
                int index = IndexOfDomino(value);
                domino = this[index];
                RemoveAt(index);
                return domino;
            }
            return null;
        }

        /// <summary>
        /// Finds a domino with a certain number of double dots in the hand.
        /// If it can find the domino, it removes it from the hand and returns it.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Domino GetDoubleDomino(int value)
        {
            Domino domino;

            if (HasDoubleDomino(value))
            {
                int index = IndexOfDomino(value);
                domino = this[index];
                RemoveAt(index);
                return domino;
            }
            return null;
        }

        /// <summary>
        /// Draws a domino from the boneyard and adds it to the hand
        /// </summary>
        /// <param name="by"></param>
        public void Draw(BoneYard by)
        {
            Domino d = by.Draw(); 
            handOfDominos.Add(d);
        }

        /// <summary>
        /// Plays the domino at the index on the train.
        /// Flips the domino if necessary before playing.
        /// Removes the domino from the hand.
        /// Throws an exception if the domino at the index
        /// is not playable.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="t"></param>
        private void Play(int index, Train t)
        {
            Domino d = this[index];
            if (d.Side1 != t.PlayableValue)
            {
                d.Flip();
            }
            if (d.Side1 == t.PlayableValue)
            {
                RemoveAt(index);
                t.Play(this, d);
            }
            else
            {
                throw new ArgumentException("Cannot be played!");
            }
        }

        /// <summary>
        /// Plays the domino from the hand on the train.
        /// Flips the domino if necessary before playing.
        /// Removes the domino from the hand.
        /// Throws an exception if the domino is not in the hand
        /// or is not playable.
        /// </summary>
        public void Play(Domino d, Train t)
        {
            for (int i = 0; i < Count; i ++)
            {
                if (this[i].Score == d.Score)
                {
                   if (this[i].Side1 == d.Side1 || this[i].Side1 == d.Side2)
                    {
                        Play(i, t);
                        return;
                    }
                }
            }
            throw new ArgumentException("Domino is not in hand");
        }

        /// <summary>
        /// Plays the first playable domino in the hand on the train
        /// Removes the domino from the hand. -getDOmino method??
        /// Returns the domino.
        /// Throws an exception if no dominos in the hand are playable.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Domino Play(Train t)
        {
            bool mustFlip;
            for (int i = 0; i < Count; i++)
            {
                if (t.IsPlayable(this, this[i], out mustFlip))
                {
                    if (mustFlip)
                    {
                        this[i].Flip();
                    }
                    Play(i, t);
                    return this[i];
                }
            }
            throw new ArgumentException("You have nothing to play");
        }
        /// <summary>
        /// returns a string listing the hand of dominoes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            foreach (Domino d in handOfDominos)
            {
                output += d.ToString() + "\n";
            }

            return output;
        }
        
    }
}
