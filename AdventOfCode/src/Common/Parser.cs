using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public static class Parser
    {
        public static IEnumerable<string> Load(string fileName = "input.txt")
        {
            return File
                .ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory())
                    .Parent.Parent.FullName + "/" + fileName);
        }
        
        public static string LoadText(string fileName = "input.txt")
        {
            return File
                .ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory())
                    .Parent.Parent.FullName + "/" + fileName);
        }

        public static IEnumerable<int> AsInt32s(this IEnumerable<string> contents)
            => contents.Select(int.Parse);
    }
}