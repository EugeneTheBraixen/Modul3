using System;

class NotificationEventArgs : EventArgs
{
    public string Message { get; }

    public NotificationEventArgs(string message)
    {
        Message = message;
    }
}

class Notification
{
    public event EventHandler<NotificationEventArgs> MessageSent;
    public event EventHandler<NotificationEventArgs> CallMade;
    public event EventHandler<NotificationEventArgs> EmailSent;

    public void SendNotificationMessage(string message)
    {
        OnMessageSent(new NotificationEventArgs(message));
    }

    public void MakeCall(string message)
    {
        OnCallMade(new NotificationEventArgs(message));
    }

    public void SendEmail(string message)
    {
        OnEmailSent(new NotificationEventArgs(message));
    }

    protected virtual void OnMessageSent(NotificationEventArgs e)
    {
        MessageSent?.Invoke(this, e);
    }

    protected virtual void OnCallMade(NotificationEventArgs e)
    {
        CallMade?.Invoke(this, e);
    }

    protected virtual void OnEmailSent(NotificationEventArgs e)
    {
        EmailSent?.Invoke(this, e);
    }
}

class Program
{
    static void Main()
    {
        Notification notification = new Notification();

        notification.MessageSent += (sender, e) =>
        {
            Console.WriteLine($"Отправлено сообщение: {e.Message}");
        };

        notification.CallMade += (sender, e) =>
        {
            Console.WriteLine($"Сделан звонок: {e.Message}");
        };

        notification.EmailSent += (sender, e) =>
        {
            Console.WriteLine($"Отправлено электронное письмо: {e.Message}");
        };

        Console.WriteLine("Введите сообщение:");
        string message = Console.ReadLine();
        notification.SendNotificationMessage(message);

        Console.WriteLine("Введите сообщение для звонка:");
        string callMessage = Console.ReadLine();
        notification.MakeCall(callMessage);

        Console.WriteLine("Введите сообщение для электронного письма:");
        string emailMessage = Console.ReadLine();
        notification.SendEmail(emailMessage);

        Console.ReadLine();
    }
}
    