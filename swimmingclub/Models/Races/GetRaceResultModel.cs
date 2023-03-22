using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Results;

namespace Models.Races {
    public class GetRaceResultModel{
        public String SwimmingPoolName { get; set; }
        public List<RaceResultSubModel> Results { get; set; }
    }
}
