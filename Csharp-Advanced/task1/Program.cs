using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystemVisitor = new FileSystemVisitor("C:\\Users\\User\\Desktop\\test", 
                entry => entry.EndsWith(".txt"));
            
            foreach(var entry in fileSystemVisitor.FilterEntries()) 
            {
                Console.WriteLine(entry);
            }
        }
    }
}
