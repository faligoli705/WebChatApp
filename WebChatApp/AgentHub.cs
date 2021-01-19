using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebChatApp
{

    [Authorize]
    public class AgentHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;

        public AgentHub(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());
        }

    }
}
