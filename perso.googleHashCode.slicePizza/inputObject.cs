using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public class inputObject
    {

        public int nbRow;
        public int nbCol;

        public int minIngredient;
        public int maxCell;

        public char[][] pizza;

        public inputObject()
        {

        }

        public inputObject(StreamReader file)
        {
            String line = string.Empty;
            bool firstLine = true;
            int currentRow = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (firstLine)
                {
                    string[] infos = line.Split(' ');
                    nbRow = int.Parse(infos[0]);
                    nbCol = int.Parse(infos[1]);
                    minIngredient = int.Parse(infos[2]);
                    maxCell = int.Parse(infos[3]);

                    pizza = new char[nbRow][];
                    for (int i = 0; i < nbRow; i++)
                    {
                        pizza[i] = new char[nbCol];
                    }
                    firstLine = false;
                }
                else
                {
                    pizza[currentRow] = line.ToCharArray();
                    currentRow++;
                }
            }
        }

        public outputObject executeAlgorithm()
        {
            outputObject result = new outputObject();
            int minCell = 2 * minIngredient;

            // we want to find all rectangle whose area is between mincell and 
            List<int[]> allRectangles = getAllRectangles(minCell, maxCell);

            // now we cross pizza, we start at the left top

            for (int i = 0; i < nbRow; i++)
            {
                for (int j = 0; j < nbCol; j++)
                {
                    bool hasOneValidSlice = false;
                    foreach(int[] rectangle in allRectangles)
                    {
                        if (isValidSlice(i, j, rectangle))
                        {
                            hasOneValidSlice = true;
                            for (int x = i; x < i + rectangle[0]; x++)
                            {
                                for (int y = j; y < j + rectangle[1]; y++)
                                {
                                    pizza[x][y] = 'X';
                                }
                            }
                            result.nbSlices++;
                            int[] coordonne = { i, j, i + rectangle[0] - 1, j + rectangle[1] - 1 };
                            result.slices.Add(coordonne);
                        }
                    }
                    if (!hasOneValidSlice)
                    {
                        pizza[i][j] = 'X';
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Allow to find all rectangle whose area is between minCell and maxCell
        /// </summary>
        /// <param name="minCell"></param>
        /// <param name="maxCell"></param>
        /// <returns></returns>
        private List<int[]> getAllRectangles(int minCell, int maxCell)
        {
            List<int[]> rectangles = new List<int[]>();
            for (int i = 0; i <= maxCell; i++)
            {
                for (int j = 0; j <= maxCell; j++)
                {
                    if (i * j >= minCell && i * j <= maxCell)
                    {
                        int[] rectangle = { i, j };
                        rectangles.Add(rectangle);
                    }
                }
            }
            return rectangles;
        }

        /// <summary>
        /// determine if a slice is a valid one !
        /// </summary>
        /// <param name="originAbsicsse"></param>
        /// <param name="origineOrdonne"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        private bool isValidSlice(int originAbsicsse, int origineOrdonne, int[] rectangle)
        {
            bool valid = true;
            int nbTomate = 0;
            int nbMush = 0;

            for(int i = originAbsicsse; i < originAbsicsse + rectangle[0]; i++)
            {
                for (int j = origineOrdonne; j < origineOrdonne + rectangle[1]; j++)
                {
                    if (i >= nbRow || j >= nbCol || (pizza[i][j] != 'T' && pizza[i][j] != 'M'))
                    {
                        valid = false;
                    }
                    else if (pizza[i][j] == 'M')
                    {
                        nbMush++;
                    }
                    else if (pizza[i][j] == 'T')
                    {
                        nbTomate++;
                    }
                }
            }

            if (nbMush < minIngredient || nbTomate < minIngredient)
            {
                valid = false;
            }

            return valid;
        }
    }
}
