using SharpRepository.EfCoreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SharpRepository.Repository;
using Mysqlx.Crud;
using SharpRepository.Repository.FetchStrategies;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace Data {
    public class DataLoader {
        private EfCoreRepository<Swimmer> swimmerRepo;
        private EfCoreRepository<Workout> workoutRepo;
        private EfCoreRepository<Coach> coachRepo;
        private EfCoreRepository<SwimmingPool> poolRepo;
        private WorkoutContext dbContext;
        public DataLoader() {
            var optionsBuilder = new DbContextOptionsBuilder<WorkoutContext>();
            optionsBuilder.UseMySQL("server=localhost;database=test;user=root;password=Kids2506#");
            dbContext = new WorkoutContext(optionsBuilder.Options);

            swimmerRepo = new EfCoreRepository<Swimmer>(dbContext);
            workoutRepo = new EfCoreRepository<Workout>(dbContext);
            coachRepo = new EfCoreRepository<Coach>(dbContext);
            poolRepo = new EfCoreRepository<SwimmingPool>(dbContext);
        }

        public List<Swimmer> GetSwimmers() {
            var strategy = new GenericFetchStrategy<Swimmer>();
            strategy.Include(x => x.Workouts.Select(y=>y.Coach));
            strategy.Include(x => x.Workouts.Select(y => y.Swimmingpool));
            return swimmerRepo.GetAll(strategy).ToList();
        }

        public List<Coach> GetCoaches() {
            return coachRepo.GetAll().ToList();
        }

        public List<Workout> GetWorkouts() {
            return workoutRepo.GetAll().ToList();
        }

        public List<SwimmingPool> GetSwimmingPools() {
            return poolRepo.GetAll().ToList();
        }

        public void AddSwimmer(Swimmer swimmer) {
            swimmerRepo.Add(swimmer);
        }

        public void AddWorkout(Workout workout) {
            workoutRepo.Add(workout);
        }

        public void Save() {
            dbContext.SaveChanges();
        }
    }
}
