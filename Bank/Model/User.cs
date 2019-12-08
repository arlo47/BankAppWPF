using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Bank.Model {
    public class User {

        private int id;
        private string name;
        private string password;
        private bool isAdmin;
        private Account userAccount;

        [Required]
        public int Id {
            get { return id; }
            set { id = value; }
        }

        [Required]
        [MaxLength(100)]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        [Required]
        [MaxLength(20)]
        public string Password {
            get { return password; }
            set { password = value; }
        }

        [Required]
        public bool IsAdmin {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public Account UserAccount {
            get { return userAccount; }
            set { userAccount = value; }
        }

        public override string ToString() {
            return $"[#{Id}, {Name} Admin: {IsAdmin}| #{UserAccount.AccountNumber}, {UserAccount.Balance.ToString()}]";
        }
    }
}
