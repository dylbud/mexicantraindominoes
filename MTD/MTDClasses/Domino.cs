using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Domino
    {

        public Domino()
        {
        }

        public Domino(int p1, int p2)
        {
            this.Side1 = p1;
            this.Side2 = p2;

        }

        // don't use an auto implemented property because of the validation in the setter - p 390
        public int Side1
        {
            get
            {
                return Side1;
            }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentException("The value of aside must be greater than 0 and less than 12");
                }
                Side1 = value;
            }
        }


        public int Side2
        {
            get
            {
                return Side2;
            }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentException("The value of aside must be greater than 0 and less than 12");
                }
                Side2 = value;
            }
        }

        public void Flip() //flips the values of sides ex. flipping the domino around
        {
        }

        /// This is how I would have done this in 233N
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
        public bool IsDouble()
        {
            
            if (Side1 == Side2)
            {
                return true;
            }
        }

        // could you do this one using a lambda expression?
        public string Filename
        {
            get
            {
                return String.Format("d{0}{1}.png", Side1, Side2);
            }
        }

        //public bool IsDouble() => (side1 == side2) ? true : false;

        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", Side1, Side2);
        }

        // could you overload the == and != operators?
        public override bool Equals(object obj)
        {
            if  (obj == null)
            {
                return false;
            }
            if (obj != null)
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
