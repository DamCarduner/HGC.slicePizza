using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public class InputObject
    {

        public int NbRow { get; private set; }
        public int NbCol { get; private set; }

        public int MinIngredient { get; private set; }
        public int MaxCell { get; private set; }

        public char[][] Pizza  { get; set; }

        public InputObject()
        {

        }

        public InputObject(StreamReader file)
        {
            String line = string.Empty;
            bool firstLine = true;
            int currentRow = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (firstLine)
                {
                    string[] infos = line.Split(' ');
                    NbRow = int.Parse(infos[0]);
                    NbCol = int.Parse(infos[1]);
                    MinIngredient = int.Parse(infos[2]);
                    MaxCell = int.Parse(infos[3]);

                    Pizza = new char[NbRow][];
                    for (int i = 0; i < NbRow; i++)
                    {
                        Pizza[i] = new char[NbCol];
                    }
                    firstLine = false;
                }
                else
                {
                    Pizza[currentRow] = line.ToCharArray();
                    currentRow++;
                }
            }
        }
    }
}
