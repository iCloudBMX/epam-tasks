using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FileSystemVisitor
{
    private string filePath = string.Empty;

    private Func<string, bool> filter;

    private Notification notification;

    public FileSystemVisitor(string filePath)
    {
        this.filePath = filePath;
        this.notification = new Notification();
        this.notification.OnFileEntryFound += OnFileEntryFound;
        this.notification.OnFilteredFileEntryFound += OnFilteredFileEntryFound;
    }

    public FileSystemVisitor(string filePath, Func<string, bool> filter)
        : this(filePath)
    {
        this.filter = filter;
        this.filePath = filePath;

    }

    private void OnFileEntryFound(
        object sender, 
        NotificationEventArgs notificationEventArgument)
    {
        Console.WriteLine($"{notificationEventArgument.FilePath} file entry found");
    }

    private void OnFilteredFileEntryFound(
        object sender, 
        NotificationEventArgs notificationEventArgument)
    {
        Console.WriteLine($"{notificationEventArgument.FilePath} filtered file entry found");
    }

    public IEnumerable<string> GetAllEntries()
    {
        var allEntries = Directory.EnumerateFileSystemEntries(filePath);

        for(int i = 0; i < allEntries.Count(); i++)
        {

            OnFileEntryFound(
                sender: this, 
                notificationEventArgument: new NotificationEventArgs
                {
                    FilePath = allEntries.ElementAt(i)
                });

            yield return allEntries.ElementAt(i);
        }
    }

    public IEnumerable<string> FilterEntries()
    {
        var allEntries = Directory.EnumerateFileSystemEntries(filePath);

        foreach(var entry in allEntries)
        {
            if(filter(entry))
            {
                
                OnFilteredFileEntryFound(
                sender: this, 
                notificationEventArgument: new NotificationEventArgs
                {
                    FilePath = entry
                });

                yield return entry;
            }
        }
    }
}
