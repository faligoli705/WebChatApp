using ChatApp.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.WebFramwork
{
    public static class ConfigurationExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {

 
            services.AddSignalR();

            services.AddSingleton<IChatRoomService, MemoryChatRoomService>(); 
        }
    }
}
