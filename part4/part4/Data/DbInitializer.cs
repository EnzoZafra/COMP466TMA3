using System;
using System.Linq;
using part4.Models;

namespace part4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Username="enzo", Password="zafra", Question="Whats your fathers maiden name", Answer="santos"}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            // Add parts
            // Add computer

        }
    }
}
