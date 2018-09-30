using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// The Domino class
    /// </summary>
    [Serializable()]
    public class Domino
    {

        /// <summary>
        /// Domino constructor
        /// </summary>
        public Domino()
        {
        }

        /// <summary>
        /// Domino constructor with sides
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Domino(int p1, int p2)
        {
            this.Side1 = p1;
            this.Side2 = p2;

        }

        private int side1;
        private int side2;

        // don't use an auto implemented property because of the validation in the setter - p 390
        /// <summary>
        /// checks the value of side 1 not a negative number or greater than 12
        /// </summary>
        public int Side1 
        {
            get
            {
                return side1;
            }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentException("The value of aside must be greater than 0 and less than 12");
                }
                side1 = value;
            }
        }

        /// <summary>
        /// checks the value of side 2 not a negative number or greater than 12
        /// </summary>
        public int Side2 
        {
            get
            {
                return side2;
            }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentException("The value of aside must be greater than 0 and less than 12");
                }
                side2 = value;
            }
        }

        /// <summary>
        /// flips the values of sides ex. flipping the domino around
        /// </summary>
        public void Flip() 
        {
            int valueHolder;

            valueHolder = side1;

            side1 = side2;

            side2 = valueHolder;
        }

       /// <summary>
       /// gets the score 
       /// </summary>

        public int Score
        {
            get
            {
                return Side1 + Side2;
            }

        }

        // because it's a read only property, I can use the "expression bodied syntax" or a lamdba expression - p 393
        //public int Score => Side1 + Side2;

        //ditto for the first version of this method and the next one
        /// <summary>
        /// checks to see if the domino is a double
        /// </summary>
        /// <returns>bool</returns>
        public bool IsDouble()
        {

            if (Side1 == Side2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // could you do this one using a lambda expression?
        /// <summary>
        /// Gets the filename of the domino images
        /// </summary>
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", Side1, Side2);
            }
        }

        //public bool IsDouble() => (side1 == side2) ? true : false;

        
        /// <summary>
        /// returns a string of the value of the domino sides
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", Side1, Side2);
        }

        // could you overload the == and != operators?

        /// <summary>
        /// overrides the Equals method to check if the sides are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Domino d = (Domino)obj;
            if (Side1 == d.Side1 && Side2 == d.Side2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the Hash code
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
