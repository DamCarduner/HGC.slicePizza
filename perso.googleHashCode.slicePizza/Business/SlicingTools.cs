using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public static class SlicingTools
    {
        /// <summary>
        /// Allow to find all rectangle whose area is between minCell and maxCell
        /// </summary>
        /// <param name="minCell"></param>
        /// <param name="maxCell"></param>
        /// <returns></returns>
        public static List<int[]> getAllRectangles(int minCell, int maxCell)
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
        public static bool IsValidSlice(int originAbsicsse, int origineOrdonne, int[] rectangle, InputObject inputObject)
        {
            bool valid = true;
            int nbTomate = 0;
            int nbMush = 0;

            for (int i = originAbsicsse; i < originAbsicsse + rectangle[0]; i++)
            {
                for (int j = origineOrdonne; j < origineOrdonne + rectangle[1]; j++)
                {
                    if (i >= inputObject.NbRow || j >= inputObject.NbCol || (inputObject.Pizza[i][j] != 'T' && inputObject.Pizza[i][j] != 'M'))
                    {
                        valid = false;
                    }
                    else if (inputObject.Pizza[i][j] == 'M')
                    {
                        nbMush++;
                    }
                    else if (inputObject.Pizza[i][j] == 'T')
                    {
                        nbTomate++;
                    }
                }
            }

            if (nbMush < 2 * inputObject.MinIngredient || nbTomate < 2 * inputObject.MinIngredient)
            {
                valid = false;
            }

            return valid;
        }
    }
}
