using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perso.googleHashCode.slicePizza
{
    public class slicePizza
    {
        public static string path = @"C:\Users\CARDUNER\Desktop\hashcode\";

        public static string dataPath = path + @"data\";
        public static string[] inFiles = Directory.GetFiles(dataPath);

        public static string outPath = path + @"out\";

        public static void Main(string[] args)
        {
            foreach (string file in inFiles)
            {
                string fileOutName = file.Split('\\').Last().Split('.').First() + ".out";
                inputObject inputObject = null;
                outputObject outputObject = null;
                // Read file an read and put them inside c# object
                using(var streamReader = new StreamReader(@file)) 
                {
                    inputObject = new inputObject(streamReader);
                }

                outputObject = inputObject.executeAlgorithm();

                // Write file from c# object
                using (var streamWriter = new StreamWriter(outPath + fileOutName))
                {
                    outputObject.write(streamWriter);
                }
            }
        }
    }
}
