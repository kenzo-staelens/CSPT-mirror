using Globals;
using Logica;
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

namespace EF_Core {
    /// <summary>
    /// Interaction logic for AddSwimmerWindow.xaml
    /// </summary>
    public partial class AddSwimmerWindow : Window {
        public DataPreProcessor dpp;
        public MainWindow parent;
        public AddSwimmerWindow() {
            InitializeComponent();
            genders.ItemsSource = new char[] { 'M', 'F' };
        }

        private void clickOk(object sender, RoutedEventArgs e) {
            try {
                Swimmer swimmer = new Swimmer();
                var dt = date.SelectedDate;
                if (firstname.Text.Equals("") || lastname.Text.Equals("")) throw new Exception("name was not filled in");
                if (genders.SelectedItem == null) throw new Exception("no gender was selected");
                if (dt == null) throw new Exception("no date was selected");
                
                swimmer.FirstName = firstname.Text;
                swimmer.LastName = lastname.Text;
                swimmer.Gender = ((char)genders.SelectedItem);
                swimmer.DateOfBirth = (DateTime)dt;

                dpp.AddSwimmer(swimmer);
                parent.updateSwimmers();
                this.Close();
            }
            catch (Exception ex) {
                errorlabel.Content = ex.Message;
            }
        }
    }
}
