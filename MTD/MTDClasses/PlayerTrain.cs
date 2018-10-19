﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Constructor using Train class
    /// </summary>
    public class PlayerTrain : Train
    {
        private Hand hand;

        private bool isOpen;

        /// <summary>
        /// Constructor with 1 Hand parameter
        /// </summary>
        /// <param name="h"></param>
        public PlayerTrain(Hand h): base()
        {
            hand = h;
        }

        /// <summary>
        /// This is the most appropriate constructor for the class.
        /// </summary>
        /// <param name="h">Represents the Hand object to which the train belongs</param>
        /// <param name="engineValue">Represents the first playable value on the train</param>
        public PlayerTrain(Hand h, int engineValue) : base (engineValue)
        {
            hand = h;
        }

        ///<summary>
        /// Returns whether or not the train is open.  An open train
        /// can be played upon by any player.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            
        }

        /// <summary>
        /// Open the train
        /// </summary>
        public void Open()
        {
            isOpen = true;
        }

        /// <summary>
        /// Close the train
        /// </summary>
        public void Close()
        {
            isOpen = false;
        }

        /// <summary>
        /// Can the domino d be played by the hand h on this train?
        /// If it can be played, must it be flipped to do so?
        /// </summary>
        ///<param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if (h == hand || isOpen)

            {
                return IsPlayable(d, out mustFlip);

            }
            mustFlip = false;
            return false;

           
        }

    }
}
