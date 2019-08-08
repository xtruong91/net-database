using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ReactApp.Notifications
{
    [Authorize]
    public class NotificationsHub : Hub
    {
    }
}
