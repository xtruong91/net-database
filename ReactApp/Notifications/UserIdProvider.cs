using Microsoft.AspNetCore.SignalR;

namespace ReactApp.Notifications
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User.Identity.Name;
        }
    }
}
