using ChatApp.DomainClass.Entities;
using Microsoft.EntityFrameworkCore; 

namespace ChatApp.DataAccessLayer
{
  public  class ChatAppContext : DbContext
    {
        public ChatAppContext(DbContextOptions<ChatAppContext> options) : base(options)
        {

        } 
        #region Table
        public DbSet<ChatMessage> Customers { get; set; }
        public DbSet<ChatRoom> Products { get; set; } 
        #endregion
    }
}

