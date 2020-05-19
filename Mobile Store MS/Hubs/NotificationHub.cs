using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.ViewModel.MessagesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        public UserManager<ApplicationUser> UserManager;
        utilities util;
        static HashSet<string> CurrentConnections = new HashSet<string>();
        public NotificationHub(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            util = new utilities(context);
        }
        public async Task SendNotificationsToUser(NotificationsViewModel notification)
        {
            var user = await UserManager.FindByIdAsync(notification.UserId);
            //string userid = Context.UserIdentifier;
            //var claims = new Claim(ClaimTypes.NameIdentifier, userid).Value;
            var claimss = new Claim(ClaimTypes.NameIdentifier, user.Id).Value;
            //await Clients.User(claims).SendAsync("ReceiveMessage", message.UserName, message);
            await Clients.User(claimss).SendAsync("RecieveNotification", notification);
        }
        public async Task SendNotificationsToAll(NotificationsViewModel notification)
        {
            await Clients.All.SendAsync("RecieveNotification", notification);
        }
        public override async Task OnConnectedAsync()
        {
            //string loggedInAdminId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user = UserManager.Users.FirstOrDefault(x => x.Id == Context.UserIdentifier);
            if (user.store_id != null)
            {
                string StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == user.store_id).StoreName;
                await Groups.AddToGroupAsync(Context.ConnectionId, StoreName);
            }
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //var id = Context.ConnectionId;
            var user = UserManager.Users.FirstOrDefault(x => x.Id == Context.UserIdentifier);
            if (user.store_id != null)
            {
                string StoreName = util.GetAllStores().FirstOrDefault(x => x.store_id == user.store_id).StoreName;
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, StoreName);
            }
            await base.OnDisconnectedAsync(exception);
        }
        public async Task JoinGroup(string groupName)
        {

            await Groups.AddToGroupAsync(Context.UserIdentifier, groupName);
        }
        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.UserIdentifier, groupName);
        }
        public Task sendNotificationToGroup(string groupName, NotificationsViewModel notification)
        {
            return Clients.Group(groupName).SendAsync("RecieveNotification", notification);
        }
    }
}
