using System;
using System.Text;

namespace ConsoleApp1.Codes
{
    public class Path
    {
        public Path(string path)
        {
            CurrentPath = path;
        }

        public string CurrentPath { get; private set; }

        public void Cd(string newPath)
        {
            var start = CurrentPath[0].ToString();
            if (start != "/")
                start = string.Empty;

            var folders = CurrentPath.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
            var folderIndex = folders.Length - 1;
            var newPathElements = newPath.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (newPathElements.Length == 0)
                return;

            var newPathElementIndex = -1;
            for (var j = 0; j < newPathElements.Length; j++)
            {
                var newPathElement = newPathElements[j];
                if (newPathElement == ".")
                    continue;

                if (newPathElement == "..")
                {
                    folderIndex--;
                }
                else
                {
                    newPathElementIndex = j;
                    break;
                }
            }

            var outputBuilder = new StringBuilder(start);
            for (var i = 0; i <= folderIndex; i++)
            {
                outputBuilder.Append(folders[i]);
                outputBuilder.Append('/');
            }

            if (newPathElementIndex >= 0)
                for (var i = newPathElementIndex; i < newPathElements.Length; i++)
                {
                    outputBuilder.Append(newPathElements[i]);
                    outputBuilder.Append('/');
                }

            CurrentPath = outputBuilder.ToString().TrimEnd('/');
        }

        public static void Run()
        {
            while (true)
            {
                var path = new Path("/a/b/c/d");
                //path.Cd("x");
                path.Cd(Console.ReadLine());
                Console.WriteLine(path.CurrentPath);
            }
        }
    }
}