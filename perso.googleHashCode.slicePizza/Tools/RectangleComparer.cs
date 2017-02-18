using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    /// <summary>
    /// Class allowing to sort rectangles
    /// </summary>
    public class RectangleComparer : Comparer<int[]>
    {
        //Compare by area
        public override int Compare(int[] first, int[] second)
        {
            if ((first[0] * first[1]).CompareTo(second[0] * second[1]) != 0)
            {
                return (first[0] * first[1]).CompareTo(second[0] * second[1]);
            }
            else
            {
                return 0;
            }
        }
    }
}
