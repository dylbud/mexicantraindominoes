using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MTDClasses
{
    public class BoneYard
    {
       private List<Domino> listOfDominoes = new List<Domino>(); 

        public BoneYard(int maxDots) //populates the list of all possible combinations from double blank to double maxDots
        { 
                      
            for ( int i = 0; i<= maxDots; i++)
            {
              
                for (int j = 0; j<= maxDots; j++)
                {
                    Domino domino = new Domino(i, j);
                    listOfDominoes.Add(domino);
                }
            }
            Shuffle(); //Shuffles each time a new instance is started
        }

        public void Shuffle() //Shuffles the boneYard list
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


        public bool IsEmpty() //Checks to see if the list is empty
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

        public int DominosRemaining // Counts all the dominoes in the boneyard at any point
        {
            get
            {
                return listOfDominoes.Count;
            }
        }

        public Domino Draw() //Draws a Domino from the boneYard.
        {
            
            //write random number generator between 0 and dominoes remaining -1
            Random rnd = new Random();
            int index = rnd.Next(DominosRemaining);
            
            Domino domino;
            domino = this[index];
            listOfDominoes.Remove(domino);
            return domino;
        }

        public Domino this[int index] // gets and sets the domino in the list at a specific index
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

        public override string ToString() //Return a string list of what is in the boneyard
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
