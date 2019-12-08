using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Bank.Model {
    public class Account {
        
        private int accountNumber;
        private double balance;

        public Account() {
            Balance = 0;
        }

        [Key]
        [Required]
        public int AccountNumber {
            get { return accountNumber; }
            set { accountNumber = value;  }
        }

        [Required]
        public double Balance {
            get { return balance; }
            set { balance = value; }
        }

        /**
         * Deposit and Withdraw are seperate methods from the property Balance because Entity Framework occasionally calls 
         * the properties in the background. Since everytime a transaction is made, a log is written to a file, I had to 
         * Create seperate methods for deposit and withdraw. A second reason is so I can throw an exception if there is an
         * attempt to withdraw more than the balance. The logic for this would be much more difficult if withdraw/deposit
         * where both done from the same property.
         */
        public void Deposit(double amount) {
            LogTransaction("D", amount);
            Balance += amount;
        }

        //See comment above deposit
        public void Withdraw(double amount) {
            if (Balance >= amount) {
                LogTransaction("W", amount);
                Balance -= amount;
            }
            else
                throw new ArgumentException("Balance cannot be below 0.");
        }

        //Writes transaction information in a file each time a transaction is successful
        public void LogTransaction(string transactionType, double amount) {

            StreamWriter sw = null;
            string pathToFile = "../../transactions.txt";

            string transaction = $"[{DateTime.Now.ToString("yy/MM/dd")}|" +
                                 $"{DateTime.Now.ToString("HH:mm:ss")}] " +
                                 $"#{AccountNumber} | " +
                                 $"{transactionType} | " +
                                 $"{(Balance - amount)} | " +
                                 $"{Balance}\n";

            try {
                using (sw = new StreamWriter(pathToFile, true)) {
                    sw.WriteLine(transaction);
                }
            }
            catch (Exception ex) {
                throw new IOException($"Unable to write to transactions.txt \n\n{ex.Message}");
            }
        }

        public override string ToString() {
            return $"[#{AccountNumber}, {Balance.ToString("c")}]";
        }
    }
}
