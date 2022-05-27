using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Shared.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifications.GetNotifications());
            notifications.ForEach(notification => ViewData.ModelState.AddModelError(string.Empty, notification.Value));

            return View();
        }
    }
}
