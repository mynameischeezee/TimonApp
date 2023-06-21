using Plugin.LocalNotification;

namespace Timon.Abstract.Services.Notifications;

public interface INotificationService
{
    NotificationRequest CreateWelcomeNotificationForNewUser(string nickName);
    NotificationRequest CreateScheduleNotificationReminder(string nickName);

    NotificationRequest CreateRecommendationsNotification(string nickName);

}