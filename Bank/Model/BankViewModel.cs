using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model {
    class BankViewModel {

        BankDbContext context = new BankDbContext();

        public User Login(int theId, string thePassword) {

            return (from u in context.Users.Include("UserAccount")
                    where u.Id == theId && u.Password.Equals(thePassword)
                    select u).FirstOrDefault();

        }

        public List<User> GetAllUsers() {
            return context.Users.Include("UserAccount").ToList();
        }

        public void AddNewUser(User newUser) {
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void DeleteUser(int theId) {

            User userToDelete = (from u in context.Users
                                 where u.Id == theId
                                 select u).SingleOrDefault();

            context.Accounts.Remove(userToDelete.UserAccount);
            context.Users.Remove(userToDelete);
            context.SaveChanges();

        }

        public void UpdateUser(User updatedUser) {

            User currentUser = (from u in context.Users
                                where u.Id == updatedUser.Id
                                select u).SingleOrDefault();

            currentUser.Id = updatedUser.Id;
            currentUser.Name = updatedUser.Name;
            currentUser.Password = updatedUser.Password;

            context.SaveChanges();
        }

        public void UpdateAccount(Account updated) {

            Account current = (from a in context.Accounts
                               where a.AccountNumber == updated.AccountNumber
                               select a).SingleOrDefault();

            current.AccountNumber = updated.AccountNumber;
            current.Balance = updated.Balance;

            context.SaveChanges();

        }

    }
}
