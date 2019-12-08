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
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window {

        BankViewModel repo;
        private User userToUpdate;

        //user to update is passed in on initialization 
        public UpdateUserWindow(User theUser) {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            repo = new BankViewModel();
            UserToUpdate = theUser;
            PopulateFields();
        }

        public User UserToUpdate {
            get { return userToUpdate; } 
            set { userToUpdate = value; }
        }

        //fill fields with data from passed in user
        private void PopulateFields() {
            txtbId.Text = userToUpdate.Id.ToString();
            txtbAccountNumber.Text = userToUpdate.UserAccount.AccountNumber.ToString();
            txtName.Text = userToUpdate.Name;
            pwPassword.Password = userToUpdate.Password;
        }

        //fields are compared against user object, and passed to ViewModel to update if necessary
        private void BtnUpdateUser_Click(object sender, RoutedEventArgs e) {

            UserToUpdate.Name = txtName.Text;
            UserToUpdate.Password = pwPassword.Password;

            repo.UpdateUser(UserToUpdate);
            this.Close();
        }
    }
}
