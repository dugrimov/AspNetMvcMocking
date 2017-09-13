using System;

namespace AspNetMvcMocking.WebApp.Persistence
{
    public class User
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}