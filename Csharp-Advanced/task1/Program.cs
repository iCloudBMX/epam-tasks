using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystemVisitor = new FileSystemVisitor("C:\\temp", 
                entry => entry.EndsWith(".txt"));
            
            fileSystemVisitor.OnFileEntryFound += OnFileFound;
            fileSystemVisitor.OnFilteredFileEntryFound += OnFilteredFileFound;

            foreach(var file in fileSystemVisitor.FilterEntries())
            {
                Console.WriteLine(file);
            }
        }

        private static void OnFilteredFileFound(object sender, NotificationEventArgs notificationEventArgs)
        {
            Console.WriteLine("Filtered file found: {0}", notificationEventArgs.FilePath);
        }

        private static void OnFileFound(object sender, NotificationEventArgs notificationEventArgs)
        {
            Console.WriteLine("File found: {0}", notificationEventArgs.FilePath);
        }
    }
}
