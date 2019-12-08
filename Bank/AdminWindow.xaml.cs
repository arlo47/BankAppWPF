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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window {

        BankViewModel repo;

        public AdminWindow() {
            InitializeComponent();
            repo = new BankViewModel();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PopulateDataGrid();
        }

        private void PopulateDataGrid() {
            dgUsers.ItemsSource = repo.GetAllUsers();
            dgUsers.Items.Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) {

            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();

            if ((bool)userWindow.DialogResult) {
                repo.AddNewUser(userWindow.NewUser);
                PopulateDataGrid();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) {

            if (dgUsers.SelectedItem == null) {
                MessageBox.Show("You must select a record first.", "Null selection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
                    

            if (MessageBox.Show("A deleted record cannot be recovered. Are you sure?", 
                                "Delete Warning", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) {

                User userToDelete = dgUsers.SelectedItem as User;
                repo.DeleteUser(userToDelete.Id);
                PopulateDataGrid();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e) {

            if (dgUsers.SelectedIndex >= 0 && dgUsers.SelectedIndex < dgUsers.Items.Count) {
                User userToUpdate = dgUsers.SelectedItem as User;

                UpdateUserWindow updateUserWindow = new UpdateUserWindow(userToUpdate);
                updateUserWindow.ShowDialog();

                PopulateDataGrid();
            }
            else {
                MessageBox.Show("You must select a user to edit.", "Null Selection", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
