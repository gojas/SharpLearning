using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Set<User>().Any() && context.Set<Company>().Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Email="admin@gmail.com",Password="123!"},
                new User{Email="gojas90@gmail.com",Password="mrvica"}
            };
            foreach (User u in users)
            {
                context.Set<User>().Add(u);
            }
            context.SaveChanges();

            var companies = new Company[]
            {
                new Company{Name="jaje"},
                new Company{Name="tebra"}
            };
            foreach (Company c in companies)
            {
                context.Set<Company>().Add(c);
            }
            context.SaveChanges();
        }
    }
}
