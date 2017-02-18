using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public class outputObject
    {
        public int nbSlices;
        public List<int[]> slices;

        public outputObject()
        {
            nbSlices = 0;
            slices = new List<int[]>();
        }

        public void write(StreamWriter file)
        {
            file.WriteLine(nbSlices);
            foreach (int[] slice in slices)
            {
                file.WriteLine(string.Format("{0} {1} {2} {3}", slice[0], slice[1], slice[2], slice[3]));
            }
        }
    }
}
