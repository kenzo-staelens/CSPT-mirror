using Globals;
using Logica;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Ado {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataPreProcessor dpp = new DataPreProcessor("database-csharp-kenzo-staelens.mysql.database.azure.com", "test", "kenzo", "Azerty123");
            DataSet ds = new DataSet();
            List<SwimmingPool> pools = dpp.GetSwimmingPools(ds);
            List<Swimmer> swimmers = dpp.GetSwimmers(ds);
            List<Coach> coaches = dpp.GetCoaches(ds);
            List<Workout> workouts = dpp.GetWorkouts(ds, pools);
            dpp.SetMemberWorkouts(coaches, swimmers, workouts);
            dpp.SetWorkoutCoaches(coaches);

            //set comboboxes
            CBCoach.ItemsSource = coaches;
            CBSwimmer.ItemsSource = swimmers;
        }

        private void handleCB1(object sender, SelectionChangedEventArgs e) {
            LBCoach.ItemsSource = ((Coach)CBCoach.SelectedItem).Workouts;
        }

        private void handleCB2(object sender, SelectionChangedEventArgs e) {
            LBSwimmer.ItemsSource = ((Swimmer)CBSwimmer.SelectedItem).Workouts;
        }
    }
}
