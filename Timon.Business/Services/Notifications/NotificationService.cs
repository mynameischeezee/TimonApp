using Plugin.LocalNotification;
using INotificationService = Timon.Abstract.Services.Notifications.INotificationService;

namespace Timon.Business.Services.Notifications;

public class NotificationService : INotificationService
{
    public NotificationRequest CreateWelcomeNotificationForNewUser(string nickName)
    {
        throw new NotImplementedException();
    }

    public NotificationRequest CreateScheduleNotificationReminder(string nickName)
    {
        throw new NotImplementedException();
    }

    public NotificationRequest CreateRecommendationsNotification(string nickName)
    {
        throw new NotImplementedException();
    }
}