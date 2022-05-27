using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Shared.Mediator;
using NerdStore.Shared.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("02ce96fa-aa2a-4668-91df-0cb0155651cc");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications,
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool IsOperationValid()
        {
            return !_notifications.HasNotification();
        }

        protected IEnumerable<string> GetErrorsMessage()
        {
            return _notifications.GetNotifications().Select(x => x.Value).ToList();
        }

        protected void NotifyError(string code, string message)
        {
            _mediatorHandler.PublicarNotification(new DomainNotification(code, message));
        }
    }
}
