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
            int minCell = 2 * inputObject.MinIngredient;

            // we want to find all rectangle whose area is between mincell and 
            List<int[]> allRectangles = SlicingTools.GetAllRectangles(minCell, inputObject.MaxCell);

            // Execute algorithm
            return SlicingAlgorithm.Execute(inputObject, allRectangles);
        }
    }
}
