using System;

public class Notification
{
    public event EventHandler<NotificationEventArgs> OnFileEntryFound;
    public event EventHandler<NotificationEventArgs> OnFilteredFileEntryFound;
}