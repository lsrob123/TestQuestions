using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleApp1.Codes
{
    /// <summary>
    ///     Implement a function FolderNames, which accepts a string containing an XML file
    ///     that specifies folder structure and returns all folder names that start with startingLetter.
    ///     The XML format is given in the example below.
    ///     For example, for the letter 'u' and XML file:
    ///     <? xml version="1.0" encoding="UTF-8"?>
    ///     <folder name="c">
    ///         < folder name="program files">
    ///             <folder name="uninstall information" />
    ///         </folder>
    ///         < folder name="users" />
    ///     </folder>
    ///     the function should return "uninstall information" and "users" (in any order).
    /// </summary>
    public class XmlProcess
    {
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            var xdoc = XDocument.Parse(xml);
            if (xdoc.Root == null)
                return new List<string>();

            //var x = xdoc.Root.Descendants("folder").ToList(); // Not useful

            var folderNames = new List<string>();
            GetFolderNames(xdoc.Root, folderNames, startingLetter);
            return folderNames;
        }

        private static void GetFolderNames(XElement x, ICollection<string> folderNames, char startingLetter)
        {
            if (x == null)
                return;

            if (x.Name.LocalName == "folder")
            {
                var folderName = x.Attribute("name")?.Value;
                if (folderName != null && folderName[0] == startingLetter)
                    folderNames.Add(folderName);
            }
            var children = x.Elements("folder");
            foreach (var child in children)
                GetFolderNames(child, folderNames, startingLetter);
        }

        public static void Run()
        {
            var xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
                "</folder>";

            foreach (var name in FolderNames(xml, 'u'))
                Console.WriteLine(name);
        }
    }
}