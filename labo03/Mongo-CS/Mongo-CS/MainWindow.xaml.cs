using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autofac;
using Globals;
using Logicalaag;
using Mongo_CS;

namespace EF_Core {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        IDataPreProcessor dpp;
        public List<Workout> workouts;
        public List<Swimmer> swimmers;
        public MainWindow() {
            InitializeComponent();
            dpp = new DataPreProcessor();
            workouts = dpp.GetWorkouts();
            swimmers = dpp.GetSwimmers();
            dpp.MergeWorkouts(swimmers, workouts);
            updateSwimmers();
        }

        public void UpdateSwimmerAt(Swimmer swimmer, int idx) {
            swimmers[idx] = swimmer;
            SwimmerCombo.Items.Refresh();
        }

        public void updateSwimmers() {
            SwimmerCombo.ItemsSource = swimmers;
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
            workoutList.ItemsSource = dpp.GetWorkouts(workouts, swimmer);
            btnAdd.IsEnabled = false;
            eswimmer.IsEnabled = true;
            eworkout.IsEnabled = false;
            workoutList.SelectedItem = null;
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
            dpp.UpdateSwimmers(swimmers);
        }

        private void editSwimmer(object sender, RoutedEventArgs e) {
            AddSwimmerWindow swimmerwindow = new AddSwimmerWindow();
            Swimmer swimmer = ((Swimmer)SwimmerCombo.SelectedItem);
            int swindex = swimmers.IndexOf(swimmer);

            swimmerwindow.SetSwimmer(swimmer, swindex);
            swimmerwindow.Show();
            swimmerwindow.dpp = dpp;
            swimmerwindow.parent = this;
            swimmerwindow.Title = swimmer.ToString();
        }

        private void addSwimmer(object sender, RoutedEventArgs e) {
            AddSwimmerWindow swimmerwindow = new AddSwimmerWindow();
            swimmerwindow.Show();
            swimmerwindow.dpp = dpp;
            swimmerwindow.parent = this;
        }

        private void editWorkout(object sender, RoutedEventArgs e) {
            AddWorkoutWindow workoutwindow = new AddWorkoutWindow();
            Workout workout = (Workout)workoutList.SelectedItem;
            workoutwindow.type.ItemsSource = Enum.GetValues(typeof(WorkoutType));
            var pools = dpp.GetPools();
            workoutwindow.pools.ItemsSource = pools;
            var coaches = dpp.GetCoaches();
            workoutwindow.coaches.ItemsSource = coaches;

            //dirty hack wegens niet zelfde objecten
            var rc = (from c in coaches where c.Id == workout.Coach.Id select c).FirstOrDefault(coaches[0]);
            var cindex = coaches.IndexOf(rc);
            workout.Coach = rc;
            var rp = (from p in pools where p.Id == workout.Swimmingpool.Id select p).FirstOrDefault(pools[0]);
            var pindex = pools.IndexOf(rp);
            workout.Swimmingpool = rp;

            workoutwindow.SetWorkout(workout);
            workoutwindow.Show();
            workoutwindow.dpp = dpp;
            workoutwindow.parent = this;
            workoutwindow.Title = workout.ToString();
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
