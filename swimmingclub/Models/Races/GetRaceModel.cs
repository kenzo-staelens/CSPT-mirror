﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Races {
    public class GetRaceModel : BaseRaceModel{
        public Guid Id { get; set; }
        public string SwimmingPoolName { get; set; }
    }
}
