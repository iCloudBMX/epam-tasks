using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FileSystemVisitor
{
    private string filePath = string.Empty;

    private Func<string, bool> filter;

    public event EventHandler<NotificationEventArgs> OnFileEntryFound = delegate{};
    public event EventHandler<NotificationEventArgs> OnFilteredFileEntryFound = delegate{};

    public FileSystemVisitor(string filePath)
    {
        this.filePath = filePath;
    }

    public FileSystemVisitor(string filePath, Func<string, bool> filter)
        : this(filePath)
    {
        this.filter = filter;
        this.filePath = filePath;

    }

    public IEnumerable<string> GetAllEntries()
    {
        var allEntries = Directory.EnumerateFileSystemEntries(filePath);

        foreach(var entry in allEntries)
        {
            OnFileEntryFound(this, new NotificationEventArgs { FilePath = entry });

            yield return entry;
        }
    }

    public IEnumerable<string> FilterEntries()
    {
        var allEntries = Directory.EnumerateFileSystemEntries(filePath);

        foreach(var entry in allEntries)
        {
            if(filter(entry))
            {
                this.OnFileEntryFound(this, new NotificationEventArgs { FilePath = entry });

                yield return entry;
            }
        }
    }
}
