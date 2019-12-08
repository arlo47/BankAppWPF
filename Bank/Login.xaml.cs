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
using System.Windows.Shapes;
using Bank.Model;

namespace Bank {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {

        BankViewModel repo;
        private User loggedInUser;
        
        public Login() {
            InitializeComponent();
            repo = new BankViewModel();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public User LoggedInUser {
            get { return loggedInUser; }
            set { loggedInUser = value; }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e) {

            if (int.TryParse(txtId.Text, out int theId) && !(string.IsNullOrEmpty(pwPassword.Password))) {
                
                LoggedInUser = repo.Login(theId, pwPassword.Password);

                if (loggedInUser != null) {
                    this.DialogResult = true;
                    this.Close();
                }
                else {
                    MessageBox.Show($"User not found. Are you sure the Id/Password are correct?",
                                    "Invalid Login Credentials", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
            else {
                MessageBox.Show("Id can only be numeric.\nId and Password fields cannot be empty.", 
                                "Invalid Id or Password", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
