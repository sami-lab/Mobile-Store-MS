using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Mobile_Store_MS.Data;
using Mobile_Store_MS.ViewModel;

namespace Mobile_Store_MS.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public UserManager<ApplicationUser> UserManager;
        static HashSet<string> CurrentConnections = new HashSet<string>();
        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }
        public async Task SendMessage(MessageViewModel message)
        {
            var user = await UserManager.FindByNameAsync(message.UserName);
            string userid = Context.UserIdentifier;
            var claims = new Claim(ClaimTypes.NameIdentifier, userid).Value;
            var claimss = new Claim(ClaimTypes.NameIdentifier, user.Id).Value;
            await Clients.User(claims).SendAsync("ReceiveMessage", message.UserName, message);
            await Clients.User(claimss).SendAsync("ReceiveMessage", message.UserName, message);
           
        }

        public override async Task OnConnectedAsync()
        {
            //var id = Context.ConnectionId;
            string userid = Context.UserIdentifier;
            CurrentConnections.Add(userid);
            await Clients.All.SendAsync("UserConnected", GetAllActiveConnections());
            await base.OnConnectedAsync();
        }     
         

       
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //var id = Context.ConnectionId;
            string userid = Context.UserIdentifier;
            var connection = CurrentConnections.FirstOrDefault(x => x == userid);

            if (connection != null)
            {
                CurrentConnections.Remove(connection);                          
                await Clients.All.SendAsync("UserDisconnected", userid);
            }
            await base.OnDisconnectedAsync(exception);
        }
        //return list of all active connections
        public List<string> GetAllActiveConnections()
        {
            return CurrentConnections.ToList();
        }
      
    }
}
