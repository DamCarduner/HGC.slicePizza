using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public class OutputObject
    {
        public int NbSlices { get; set; }
        public List<int[]> Slices { get; set; }

        public int NbPoint { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public OutputObject()
        {
            NbSlices = 0;
            NbPoint = 0;
            Slices = new List<int[]>();
        }

        /// <summary>
        /// Write file from output object
        /// </summary>
        /// <param name="file"></param>
        public void Write(StreamWriter file)
        {
            file.WriteLine(NbSlices);
            foreach (int[] slice in Slices)
            {
                file.WriteLine(string.Format("{0} {1} {2} {3}", slice[0], slice[1], slice[2], slice[3]));
            }
        }
    }
}
