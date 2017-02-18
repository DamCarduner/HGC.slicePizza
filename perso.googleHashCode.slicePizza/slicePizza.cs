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
        public static string path = @"..\..\..\material\";

        public static string dataPath = path + @"data\";
        public static string[] inFiles = Directory.GetFiles(dataPath);

        public static string outPath = path + @"out\";

        public static void Main(string[] args)
        {
            foreach (string file in inFiles)
            {
                Console.WriteLine(string.Format("Read file : {0}", file));
                
                InputObject inputObject = null;
                OutputObject outputObject = null;

                // Now we want to execute all known algorithm
                List<IAlgorithm> algorithms = new List<IAlgorithm>();
                algorithms.Add(new BasicAlgorithm());
                algorithms.Add(new MoreComplexAlgorithm());

                foreach (IAlgorithm algorithm in algorithms)
                {
                    string fileOutName = file.Split('\\').Last().Split('.').First() + ".out";
                    // Read file an read and put them inside c# object
                    using (var streamReader = new StreamReader(@file))
                    {
                        inputObject = new InputObject(streamReader);
                    }

                    Console.WriteLine(string.Format("Apply algorithm : {0} on this file", algorithm.GetName()));
                    outputObject = algorithm.Execute(inputObject);
                    Console.WriteLine(string.Format("{0} point with this algorithm", SlicingTools.GetNbPoint(outputObject)));

                    if (!Directory.Exists(outPath + algorithm.GetName()))
                    {
                        Directory.CreateDirectory(outPath + algorithm.GetName());
                    }
                    // Write file from c# object
                    using (var streamWriter = new StreamWriter(outPath + algorithm.GetName() + "\\" + fileOutName))
                    {
                        outputObject.Write(streamWriter);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
