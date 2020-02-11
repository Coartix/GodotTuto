using System;

namespace YouAndCthulhu
{
    public class Program
    {
        public static void CthulhuSlaver(string path)
        // Read a file, fills a function table and execute it, thus running a Cthulhu program.
        {
            if (!System.IO.File.Exists(path))
                throw new Exception("File does not exist");

            string[] fichier = System.IO.File.ReadAllLines(path);
            FunctionTable listFunction = new FunctionTable();

            foreach (string line in fichier)
            {
                if (line != "")
                    listFunction.Add(LexerParser.LineToFunction(line, listFunction));
            }
            listFunction.Execute();
        }

        static void Main()
        {
            CthulhuSlaver("D:/GitHub/Godot Tuto/GodotTuto/skeleton/YouAndCthulhu/TestYouAndCthulhu/Test1");
        }
    }
}
