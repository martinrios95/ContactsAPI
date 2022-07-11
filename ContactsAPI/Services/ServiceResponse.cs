using ContactsAPI.Services.Enums;

namespace ContactsAPI.Services
{
    public class ServiceResponse<T>
    {
        public T Response { get; set; }
        public ResponseTypes ResponseType { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }
}
