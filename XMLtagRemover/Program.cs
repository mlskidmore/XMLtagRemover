using System;

namespace XMLtagRemover
{
    class Program
    {
        static int Main(string[] args)
        {

            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter a directory path.");
                    return -1;
                }

                Console.WriteLine("Directory: " + args[0]);

                XMLtagRemover xmlTagRemover = new XMLtagRemover(args[0]);
                xmlTagRemover.UpdateFiles();

                Console.WriteLine("\nProgram complete.");

                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in processing files: " + e.Message);
            }
            
            return 0;
        }
    }
}
