using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikamoozChatRoom.Hubs
{
    public class ChatroomHub:Hub
    {

        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, "Test");
            
            return base.OnConnectedAsync();
        }

        public async Task StartMessage(string user)
        {                        
            await Clients.All.SendAsync("JoinedRoom", user);            
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
