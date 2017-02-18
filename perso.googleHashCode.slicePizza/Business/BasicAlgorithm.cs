using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public class BasicAlgorithm : IAlgorithm
    {
        /// <summary>
        /// basic algorithm name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "basicAlgorithm";
        }

        /// <summary>
        /// One simple algorithm
        /// </summary>
        /// <param name="inputObject"></param>
        /// <returns></returns>
        public OutputObject Execute(InputObject inputObject)
        {

            OutputObject result = new OutputObject();
            int minCell = 2 * inputObject.MinIngredient;

            // we want to find all rectangle whose area is between mincell and 
            List<int[]> allRectangles = SlicingTools.getAllRectangles(minCell, inputObject.MaxCell);

            // now we cross pizza, we start at the left top

            for (int i = 0; i < inputObject.NbRow; i++)
            {
                for (int j = 0; j < inputObject.NbCol; j++)
                {
                    bool hasOneValidSlice = false;
                    foreach(int[] rectangle in allRectangles)
                    {
                        if (SlicingTools.IsValidSlice(i, j, rectangle, inputObject) && !hasOneValidSlice)
                        {
                            hasOneValidSlice = true;
                            for (int x = i; x < i + rectangle[0]; x++)
                            {
                                for (int y = j; y < j + rectangle[1]; y++)
                                {
                                    inputObject.Pizza[x][y] = 'O';
                                }
                            }
                            result.NbSlices++;
                            int[] coordonne = { i, j, i + rectangle[0] - 1, j + rectangle[1] - 1 };
                            result.Slices.Add(coordonne);
                        }
                    }
                    if (!hasOneValidSlice)
                    {
                        inputObject.Pizza[i][j] = 'X';
                    }
                }
            }

            return result;
        }
    }
}
