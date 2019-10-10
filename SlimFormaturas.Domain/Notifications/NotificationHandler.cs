using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlimFormaturas.Domain.Notifications {
    public class NotificationHandler{
        private List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationHandler() {
            _notifications = new List<Notification>();
        }


        public void AddNotification(string errorCode, string propertyName, string message){
            _notifications.Add(new Notification(errorCode, propertyName, message));
        }

        public void AddNotification(Notification notification){
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications){
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications){
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications){
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult){
            foreach (var error in validationResult.Errors) {
                AddNotification(error.ErrorCode, error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
