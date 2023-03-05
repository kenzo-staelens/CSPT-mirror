using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
using Globals;
using Logica;

namespace EF_Core {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DataPreProcessor dpp;
        List<Workout> workouts;
        public MainWindow() {
            InitializeComponent();
            dpp = new DataPreProcessor();
            workouts = dpp.GetWorkouts();
            updateSwimmers();
        }

        public void updateSwimmers() {
            SwimmerCombo.ItemsSource = dpp.GetSwimmers();
            DG.IsReadOnly = true;
            workoutList.ItemsSource = workouts;
            btnAdd.IsEnabled = false;
            eswimmer.IsEnabled = false;
            eworkout.IsEnabled = false;
        }

        public void updateWorkouts() {
            workouts = dpp.GetWorkouts();
            eworkout.IsEnabled = false;
            btnAdd.IsEnabled = false;
        }

        private void handleCB(object sender, SelectionChangedEventArgs e) {
            var swimmer = ((Swimmer)SwimmerCombo.SelectedItem);
            DG.ItemsSource = ((Swimmer)SwimmerCombo.SelectedItem).Workouts;
            workoutList.ItemsSource = dpp.GetWorkouts(workouts,swimmer);
            btnAdd.IsEnabled = false;
            eswimmer.IsEnabled = true;
            eworkout.IsEnabled = false;
            //workoutList.SelectedItem = null;
        }

        private void selectEnable(object sender, SelectionChangedEventArgs e) {
            eworkout.IsEnabled = true;
            if (SwimmerCombo.SelectedItem == null) return;
            btnAdd.IsEnabled = true;
        }

        private void btnAddFunc(object sender, RoutedEventArgs e) {
            var workout = ((Workout)workoutList.SelectedItem);
            var swimmer = ((Swimmer)SwimmerCombo.SelectedItem);
            swimmer.addWorkout(workout);
            workoutList.ItemsSource = dpp.GetWorkouts(workouts, swimmer);
            dpp.Save();
        }

        private void editSwimmer(object sender, RoutedEventArgs e) {
            AddSwimmerWindow swimmerwindow = new AddSwimmerWindow();
            swimmerwindow.SetSwimmer(((Swimmer)SwimmerCombo.SelectedItem));
            swimmerwindow.Show();
            swimmerwindow.dpp = dpp;
            swimmerwindow.parent = this;
            swimmerwindow.Title = swimmerwindow.swimmer.ToString();
        }

        private void addSwimmer(object sender, RoutedEventArgs e) {
            AddSwimmerWindow swimmerwindow = new AddSwimmerWindow();
            swimmerwindow.Show();
            swimmerwindow.dpp = dpp;
            swimmerwindow.parent = this;
        }

        private void editWorkout(object sender, RoutedEventArgs e) {
            AddWorkoutWindow workoutwindow = new AddWorkoutWindow();
            workoutwindow.SetWorkout(((Workout)workoutList.SelectedItem));
            workoutwindow.Show();
            workoutwindow.dpp = dpp;
            workoutwindow.parent = this;
            workoutwindow.type.ItemsSource = Enum.GetValues(typeof(WorkoutType));
            workoutwindow.pools.ItemsSource = dpp.GetPools();
            workoutwindow.coaches.ItemsSource = dpp.GetCoaches();
            workoutwindow.Title = workoutwindow.workout.ToString();
        }

        private void addWorkout(object sender, RoutedEventArgs e) {
            AddWorkoutWindow workoutwindow = new AddWorkoutWindow();
            workoutwindow.Show();
            workoutwindow.dpp = dpp;
            workoutwindow.parent = this;
            workoutwindow.type.ItemsSource = Enum.GetValues(typeof(WorkoutType));
            workoutwindow.pools.ItemsSource = dpp.GetPools();
            workoutwindow.coaches.ItemsSource = dpp.GetCoaches();
        }
    }
}
