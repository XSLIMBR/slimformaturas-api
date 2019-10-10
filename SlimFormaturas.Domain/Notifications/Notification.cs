using MediatR;

namespace SlimFormaturas.Domain.Notifications {
    public class Notification {
        public string ErrorCode { get; set; }
        public string PropertyName { get; set; }
        public string Message { get; set; }
        public Notification(string errorCode, string propertyName, string message) {
            ErrorCode = errorCode;
            PropertyName = propertyName;
            Message = message;
        }
    }
}
