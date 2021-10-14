using NotificationSamples;
using System;
using UnityEngine;

// Notification id enum.
public enum NotificationId
{
    AppBackgrounded = 100,
    ButtonClicked = 200
}

// This script handles sending local notifications using a sample GameNotificationsManager class.
public class NotificationSender : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameNotificationsManager manager = null;

    [Header("Settings")]
    [SerializeField] private string channelId = "LocalNotificationTest";

    // Start is called once when the script is enabled.
    private void Start()
    {
        InitializeNotificationManager();
    }

    // Return whether the manager has been initialized.
    private bool IsInitialized()
    {
        if (manager == null)
        {
            Debug.LogError(name + ": " + "Game Notifications Manager is not initialized!");
            return false;
        }
        return true;
    }

    // Initialize notification manager with a default channel.
    private void InitializeNotificationManager()
    {
        var channel = new GameNotificationChannel(channelId, "Default Game Channel", "Generic notifications");
        manager.Initialize(channel);
    }

    // OnApplicationPause is automatically called when the app is backgrounded or foregrounded.
    // The boolean 'pause' indicates whether the app is backgrounded (true) or foregrounded (false).
    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            ScheduleAppBackgroundedNotification();
        }
    }

    // Schedule app backgrounded notification when app is being backgrounded.
    private void ScheduleAppBackgroundedNotification()
    {
        string title = "The game misses you!";
        string body = "Come back please!";
        int delay = 30;

        CancelNotification((int)NotificationId.AppBackgrounded);
        ScheduleNotification((int)NotificationId.AppBackgrounded, title, body, DateTime.Now.AddSeconds(delay));
    }

    // Schedule button clicked notification when user clicks a certain button.
    public void ScheduleButtonClickedNotification()
    {
        string title = "You clicked a button!";
        string body = "Remember when you did that?";
        int delay = 60;

        CancelNotification((int)NotificationId.ButtonClicked);
        ScheduleNotification((int)NotificationId.ButtonClicked, title, body, DateTime.Now.AddSeconds(delay));
    }

    // Cancel a notification with a given id by using the manager.
    public void CancelNotification(int id)
    {
        if (!IsInitialized()) return;

        manager.CancelNotification(id);

        Debug.Log("NotificationSender: CancelNotification: " + id);
    }

    // Schedule a notification with a given id, title, body and delivery time by using the manager.
    public void ScheduleNotification(int id, string title, string body, DateTime deliveryTime)
    {
        if (!IsInitialized()) return;

        IGameNotification notification = manager.CreateNotification();

        if (notification == null)
        {
            Debug.LogError("Notification is null. Failed to schedule notification!");
            return;
        }

        notification.Id = id;
        notification.Group = channelId;
        notification.Title = title;
        notification.Body = body;
        notification.DeliveryTime = deliveryTime;
        notification.SmallIcon = "icon";
        notification.LargeIcon = "icon_large";

        manager.ScheduleNotification(notification);

        Debug.Log("NotificationSender: ScheduleNotification: " + id + " | " + title + " | " + body);
    }
}