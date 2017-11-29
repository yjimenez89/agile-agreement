using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amsystem.Data.Entities;

namespace Amsystem.Data.SqlServer.Context
{
    public class AmsystemDbInitializer : DropCreateDatabaseIfModelChanges<AmsystemDbContext>
    {
        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context"> The context to seed. </param>
        protected override void Seed(AmsystemDbContext context)
        {
            List<User> users = new List<User>
            {
                new User { Name = "Jorge", LastName = "Betancourt", Email = "jbetancourt@gmail.com", Address = "Street 9B, #2021", UserName = "jbetancourt", Password = "develop1.com"},
                new User { Name = "Yurian", LastName = "Jimenez", Email = "yjimenez@gmail.com", Address = "Street 9B, #2022", UserName = "yjimenez", Password = "develop2.com"},
                new User { Name = "Jose", LastName = "Perez", Email = "jperez@gmail.com", Address = "Street 9B, #2023", UserName = "jperez", Password = "develop3.com"}
            };

            users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();

            List<Status> statuses = new List<Status>
            {
                new Status { Name = "Accomplished" },
                new Status { Name = "Overdue" },
                new Status { Name = "Approved" }
            };

            statuses.ForEach(status => context.Statuses.Add(status));
            context.SaveChanges();

            List<Agreement> agreements = new List<Agreement>
            {
                new Agreement { Description = "Description1", DueDate = DateTime.Now, Observation = "Observation1", Status = statuses[0], Responsibles = new List<User> { users[0] } },
                new Agreement { Description = "Description2", DueDate = DateTime.Now, Observation = "Observation2", Status = statuses[1], Responsibles = new List<User> { users[1] } },
                new Agreement { Description = "Description3", DueDate = DateTime.Now, Observation = "Observation3", Status = statuses[2], Responsibles = new List<User> { users[2] } }
            };

            agreements.ForEach(agreement => context.Agreements.Add(agreement));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
