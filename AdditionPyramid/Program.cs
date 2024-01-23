using System;
using System.IO;
using System.Linq;

namespace AdditionPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Below block of code reads a number pyramid from a text file expecting
             * each line to have x many numbers where x is the line number e.g the
             * third line would have three numbers and so on.
             * This is then stored in an array of integer arrays, with
             * each integer array representing a line of the input file.
             */
            Console.Write("Enter name of text file: ");
            string fileName = Console.ReadLine() + ".txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File does not exist!\nPress any key to exit");
                Console.ReadKey();
                return;
            }
            int lineCount = File.ReadLines(fileName).Count();
            StreamReader inputStream = new StreamReader(fileName);
            int[][] numberLines = new int[lineCount][];
            for (int lineNumber = 0; lineNumber < lineCount; lineNumber++)
            {
                string[] inputLineNumbers = inputStream.ReadLine().Split();
                int[] numberLine = new int[inputLineNumbers.Length];
                for (int inputLineNumber = 0; inputLineNumber < inputLineNumbers.Length; inputLineNumber++)
                {
                    numberLine[inputLineNumber] = Int32.Parse(inputLineNumbers[inputLineNumber]);
                }
                numberLines[lineNumber] = numberLine;
            }

            /* 
             * Visualise the input text file as a pyramid and/or tree, with each number connected to the two below it either side - the same and the next index
             * This loop calculates the largest number that can be gained from a path in this pyramid/tree
             * This is done by iteratively summing the larger of the leaf node pairs value to the branch node,
             * then treating those branch nodes as leaves, until the last branch has its larger leaf value summed
             */
            for (int leafLine = lineCount - 1; leafLine > 0; leafLine--)
            {
                for (int branch = 0; branch < leafLine; branch++)
                {
                    numberLines[leafLine - 1][branch] += (numberLines[leafLine][branch] > numberLines[leafLine][branch + 1]) ? numberLines[leafLine][branch] : numberLines[leafLine][branch + 1];
                }
            }

            //Output total
            Console.WriteLine(numberLines[0][0]);
            Console.ReadLine();
        }
    }
}
