namespace Bank.Migrations
{
    using Bank.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bank.Model.BankDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bank.Model.BankDbContext context)
        {

            context.Users.RemoveRange(context.Users);
            context.Accounts.RemoveRange(context.Accounts);

            List<User> users = new List<User>();

            users.Add(new User() {
                Id = 1,
                Name = "Johnny Bravo",
                Password = "123",
                UserAccount = new Account() {
                    AccountNumber = 1213,
                    Balance = 1000
                }
            });

            users.Add(new User() {
                Id = 3,
                Name = "Administrator",
                Password = "admin",
                IsAdmin = true,
                UserAccount = new Account() {
                    AccountNumber = 9090,
                    Balance = 0
                }
            });


            context.Users.AddRange(users);
            base.Seed(context);

        }
    }
}
