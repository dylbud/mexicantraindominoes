using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MTDClasses
{
    /// <summary>
    /// Represents a generic Train for MTD
    /// </summary>
    public abstract class Train : IEnumerable<Domino>
    {
        private List<Domino> dominos = new List<Domino>();

        /// <summary>
        /// The value of the first double domino
        /// </summary>
        private int engineValue;

        /// <summary>
        /// Constructor
        /// </summary>
        public Train()
        {

        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="engValue"></param>
        public Train(int engValue)
        {
            //Domino dom = new Domino(engValue, engValue);
            EngineValue = engValue;

        }

        /// <summary>
        /// Number of dominoes
        /// </summary>
        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }

        /// <summary>
        /// The first domino value that must be played on a train
        /// </summary>
        public int EngineValue
        {
            get
            {
                return engineValue;
            }
            set
            {
                engineValue = value;
            }
        }


        /// <summary>
        /// If the count is zero return true
        /// </summary>
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
        /// Last Domino played from the list
        /// </summary>
        public Domino LastDomino
        {
            get
            {
                Domino d = dominos[Count - 1];
                return d;
                            
            }
            //****if count = 0 return null?****
             
        }

        /// <summary>
        /// Side2 of the last domino in the train.It's the value of the next domino that can be played.
        ///</summary>
        public int PlayableValue
        {
            get
            {
                return LastDomino.Side2;
            }
        }

        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
        }

        /// <summary>
        /// Determines whether a hand can play a specific domino on this train and if the domino must be flipped.
        /// Because the rules for playing are different for Mexican and Player trains, this method is abstract.
        /// </summary>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);


        /// <summary>
        /// A helper method that determines whether a specific domino can be played on this train.
        /// It can be called in the Mexican and Player train class implementations of the abstract method
        /// </summary>
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (PlayableValue == d.Side1)
            {
                mustFlip = false;
                return true;
            }
            else if (PlayableValue == d.Side2)
            {
                mustFlip = true;
                return true;
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }

        /// <summary>
        /// Adds the domino to the train if it is playable 
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        //assumes the domino has already been removed from the hand
        //***needs to use the hand, call isPlayable method using h, defined in each class not base class****
        public void Play(Hand h, Domino d)
        {
            bool mustFlip;
            // remove domino from hand
            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip == true)
                {
                    d.Flip();
                }
                Add(d);
            }
            
        }

        /// <summary>
        /// gets a list of dominoes in the train
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            if (this.IsEmpty)
            {
                return ("There is no train!");
            }
            else
            {
                string output = "";
                foreach (Domino d in dominos)
                {
                    output += d.ToString() + "\n";
                }
                return output;
            }
            
        }
        /// <summary>
        /// Implements IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Domino> GetEnumerator()
        {
            return ((IEnumerable<Domino>)dominos).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Domino>)dominos).GetEnumerator();
        }
    }
}