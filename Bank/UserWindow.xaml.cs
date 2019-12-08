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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window {

        private User newUser;
        
        public UserWindow() {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public User NewUser {
            get { return newUser; } 
            set { newUser = value; }
        }

        //Creates a new user object, stores data in class variable newUser, which has a get prop
        private void BtnAddUser_Click(object sender, RoutedEventArgs e) {

            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(pwPassword.Password)) {
                NewUser = new User();
                NewUser.Name = txtName.Text;
                NewUser.Password = pwPassword.Password;

                NewUser.UserAccount = new Account();

                this.DialogResult = true;
                this.Close();
            }
            else {
                MessageBox.Show("Name and Password field cannot be empty", "Empty Field Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
