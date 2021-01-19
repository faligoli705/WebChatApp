using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.DomainClass.Entities;
using ChatApp.Services;
using Microsoft.AspNetCore.SignalR;
using WebChatApp.Models;

namespace WebChatApp
{
    public class ChatHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatHub(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }
        public override async Task OnConnectedAsync()
        {
            var roomId = await _chatRoomService.CreateRoom(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            await Clients.Caller.SendAsync("ReciveMessage",
                "TopLearn Support",
                DateTimeOffset.UtcNow,
                "Hello ! What can we help you with today ?");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var roomId = await _chatRoomService.GetRoomForConnectionId(Context.ConnectionId);
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.Now
            };

            await _chatRoomService.AddMessage(roomId, message);

            await Clients.Group(roomId.ToString()).SendAsync("ReciveMessage", message.SenderName, message.SendAt, message.Text);
        }
        public async Task SetName(string visitorName)
        {
            var roomName = $"Chat With {visitorName} from the web .";

            var roomId = await _chatRoomService.GetRoomForConnectionId(Context.ConnectionId);

            await _chatRoomService.SetRoomName(roomId, roomName);
        }
    }
}
