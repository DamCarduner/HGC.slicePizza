using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public static class SlicingAlgorithm
    {

        /// <summary>
        /// One possible algorithm to execute. It crosse pizza from top left to bottom right
        /// Result depend of the order of given rectangles
        /// </summary>
        /// <param name="inputObject"></param>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public static OutputObject Execute(InputObject inputObject, List<int[]> rectangles)
        {

            OutputObject result = new OutputObject();
            // now we cross pizza, we start at the left top
            for (int i = 0; i < inputObject.NbRow; i++)
            {
                for (int j = 0; j < inputObject.NbCol; j++)
                {
                    bool hasOneValidSlice = false;
                    foreach (int[] rectangle in rectangles)
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
