using Bank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


/**
 *  - hide password column in admin panel
 *  - reset IDs everytime a migration is made
 */

namespace Bank {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        BankViewModel repo;
        User loggedInUser;

        public MainWindow() {
            InitializeComponent();
            repo = new BankViewModel();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        //Checks if id/password exists in database, if it does, returns that user object
        private void BtnLogin_Click(object sender, RoutedEventArgs e) {
            Login loginWindow = new Login();

            if (loginWindow.ShowDialog().Value) {
                try {
                    loggedInUser = loginWindow.LoggedInUser;

                    //Admin window is open if the user has admin rights
                    if (loggedInUser.IsAdmin) {
                        AdminWindow adminWindow = new AdminWindow();
                        MessageBox.Show("Welcome admin!");
                        adminWindow.ShowDialog();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"No user is logged in.\n{ex.Message}");
                }

                //user data is populated in window + previously disabled fields are enabled
                txtbId.Text = loggedInUser.Id.ToString();
                txtbName.Text = loggedInUser.Name;
                txtBalance.Text = loggedInUser.UserAccount.Balance.ToString("c");
                txtAmount.IsEnabled = true;
                btnDeposit.IsEnabled = true;
                btnWithdraw.IsEnabled = true;
            }
        }

        //if amount entered is valid, amount is added to balance
        private void BtnDeposit_Click(object sender, RoutedEventArgs e) {

            if (double.TryParse(txtAmount.Text, out double amount)) {
                loggedInUser.UserAccount.Deposit(amount);
                repo.UpdateAccount(loggedInUser.UserAccount);

                txtBalance.Text = loggedInUser.UserAccount.Balance.ToString("c");
                txtAmount.Clear();
            }
            else {
                MessageBox.Show("Not a valid amount", "Invalid dollar value", MessageBoxButton.OK, MessageBoxImage.Error);
                txtAmount.Clear();
            }
        }

        //if amount is valid, amount is subtracted from balance
        private void BtnWithdraw_Click(object sender, RoutedEventArgs e) {

          
            if (double.TryParse(txtAmount.Text, out double amount)) {

                try {
                    loggedInUser.UserAccount.Withdraw(amount);
                    repo.UpdateAccount(loggedInUser.UserAccount);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

                txtBalance.Text = loggedInUser.UserAccount.Balance.ToString("c");
                txtAmount.Clear();
            }
            else {
                MessageBox.Show("Not a valid amount", "Invalid dollar value", MessageBoxButton.OK, MessageBoxImage.Error);
                txtAmount.Clear();
            }

        }
    }
}
