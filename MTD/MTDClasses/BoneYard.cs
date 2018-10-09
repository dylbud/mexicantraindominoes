using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MTDClasses
{
    /// <summary>
    /// Boneyard Class
    /// </summary>
    public class BoneYard
    {
        private List<Domino> listOfDominoes = new List<Domino>();

        /// <summary>
        /// Constructor populates the list of all possible combinations from double blank to double maxDots
        /// </summary>
        /// <param name="maxDots"></param>
        public BoneYard(int maxDots) 
        { 
                      
            for ( int i = 0; i<= maxDots; i++)
            {
              
                for (int j = i; j<= maxDots; j++) //increments without duplicates?
                {
                    Domino domino = new Domino(i, j);
                    listOfDominoes.Add(domino);
                }
            }
            Shuffle(); //Shuffles each time a new instance is started
        }

        /// <summary>
        /// Shuffles the boneYard list
        /// </summary>
        public void Shuffle() 
        {
            List<Domino> randomList = new List<Domino>();
            Random r = new Random();
            int randomIndex = 0;
            while (listOfDominoes.Count > 0)
            {
                randomIndex = r.Next(0, listOfDominoes.Count);
                randomList.Add(listOfDominoes[randomIndex]);
                listOfDominoes.RemoveAt(randomIndex);
            }
            listOfDominoes = randomList;
        }

        /// <summary>
        /// Checks to see if the list is empty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty() 
        {
            if (DominosRemaining == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Counts all the dominoes in the boneyard at any point
        /// </summary>
        public int DominosRemaining 
        {
            get
            {
                return listOfDominoes.Count;
            }
        }

        /// <summary>
        /// Draws a Domino from the boneYard.
        /// </summary>
        /// <returns>Domino</returns>
        public Domino Draw() 
        {
            
            //write random number generator between 0 and dominoes remaining -1
            Random rnd = new Random();
            int index = rnd.Next(DominosRemaining);
            
            Domino domino;
            domino = this[index];
            listOfDominoes.Remove(domino);
            return domino;
        }

        /// <summary>
        ///  gets and sets the domino in the list at a specific index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Domino</returns>
        public Domino this[int index] 
        {
            get
            {
               
                return listOfDominoes[index];
            }
            set
            {
                 listOfDominoes[index] = value;

            }
        }

        /// <summary>
        /// Return a string list of what is in the boneyard
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() 
        {
            if (this.IsEmpty())
            {
                return ("The boneYard is empty!");
            }
            else 
            {
                string output = "";
                foreach (Domino d in listOfDominoes)
                {
                    output += d.ToString() + "\n";
                }
                return output;
            }
        }

    }
}
