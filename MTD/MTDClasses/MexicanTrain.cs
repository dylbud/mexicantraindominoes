using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class MexicanTrain : Train 
    {
      

        /// <summary>
        /// Constructor
        /// </summary>
        public MexicanTrain() : base()//***call base class constructor***
        {

        }

        /// <summary>
        /// Constructor takes an int parameter
        /// </summary>
        /// <param name="engineValue"></param>
        public MexicanTrain(int engineValue) : base()//***call base class constructor***
        {

        }

        /// <summary>
        ///****overrides abstract IsPlayable***
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            return IsPlayable(d, out mustFlip);
            
                    
        }
    }




}

