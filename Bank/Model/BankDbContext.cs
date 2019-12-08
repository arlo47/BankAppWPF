using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bank.Model;

namespace Bank.Model {
    class BankDbContext : DbContext {

        private DbSet<User> users;
        private DbSet<Account> accounts;

        public DbSet<User> Users {
            get { return users; }
            set { users = value; }
        }
        public DbSet<Account> Accounts {
            get { return accounts; }
            set { accounts = value; }
        }

    }
}
