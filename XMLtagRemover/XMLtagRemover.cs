using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XMLtagRemover
{
    public class XMLtagRemover
    {
        private string cmdLineArgs;
        private List<string> htmFiles;
        private List<string> htmlFiles;

        const string XML_TAG = "<?xml ";
        public XMLtagRemover(string args0)
        {
            cmdLineArgs = args0;
            htmFiles = HTMfiles;
            htmlFiles = HTMLfiles;
        }
        public List<string> HTMLfiles
        {
            get
            {
                List<string> HTMLfiles = new List<string>(Directory.GetFiles(cmdLineArgs, "*.html", SearchOption.AllDirectories));
                Console.WriteLine("HTML files count:   " + HTMLfiles.Count);
                return HTMLfiles;
            }
        }
        public List<string> HTMfiles
        {
            get
            {
                List<string> HTMfiles = new List<string>(Directory.GetFiles(cmdLineArgs, "*.htm", SearchOption.AllDirectories));
                Console.WriteLine("\nHTM files count: " + HTMfiles.Count);
                return HTMfiles;
            }
        }
        public void UpdateFiles()
        {
            List<string> AllFiles = new List<string>();

            populateAllFilesList(ref AllFiles, htmFiles, htmlFiles);

            Console.WriteLine("\nStarting file update...\n");

            RemoveXMLtags(AllFiles);
        }
        private void populateAllFilesList(ref List<string> AllFiles, List<string> HTMfiles, List<string> HTMLfiles)
        {
            foreach (string file in HTMfiles)
            {
                AllFiles.Add(file);
            }

            foreach (string file in HTMLfiles)
            {
                AllFiles.Add(file);
            }

            Console.WriteLine("All Files count: " + AllFiles.Count);
        }
        private void RemoveXMLtags(List<string> AllFiles)
        {
            List<string> ChangedFiles = new List<string>();
            List<string> UnchangedFiles = new List<string>();

            // Search through each file and remove XML tag line
            foreach (string file in AllFiles)
            {
                string[] fileLines = File.ReadAllLines(file);

                if (fileLines[0].Length >= 6 && fileLines[0].Substring(0, 6) == XML_TAG)
                {
                    File.WriteAllLines(file, fileLines.Skip(1).Take(fileLines.Count() - 1));
                    ChangedFiles.Add(file);

                    if (ChangedFiles.Count % 500 == 0)
                    {
                        displayFileCount(AllFiles, ChangedFiles, UnchangedFiles);
                    }
                }
                else
                {
                    UnchangedFiles.Add(file);

                    if (UnchangedFiles.Count % 500 == 0)
                    {
                        displayFileCount(AllFiles, ChangedFiles, UnchangedFiles);
                    }
                }
            }

            Console.WriteLine("\nChanged files count:   " + ChangedFiles.Count);
            Console.WriteLine("Unchanged files count: " + UnchangedFiles.Count);
            Console.WriteLine("Total files checked:   " + (ChangedFiles.Count + UnchangedFiles.Count));
        }

        private void displayFileCount(List<string> AllFiles, List<string> ChangedFiles, List<string> UnchangedFiles)
        {
            Console.Write("Changed Files: " + ChangedFiles.Count);
            Console.Write(". Unchanged Files: " + UnchangedFiles.Count);
            Console.WriteLine(". Files to process: " + (AllFiles.Count - ChangedFiles.Count - UnchangedFiles.Count));
        }
    }
}
