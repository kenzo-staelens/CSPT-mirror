using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums {
    public enum Gender {
        MALE,
        FEMALE
    }

    public enum Level {
        INITIATOR,
        INSTRUCTOR,
        TRAINER_A,
        TRAINER_B
    }

    public enum WorkoutType {
        ENDURANCE,
        POWER,
        INTERVAL
    }

    public enum LaneLength {
        SHORT,
        LONG
    }

    public enum Stroke {
        FREESTYLE,
        BACKSTROKE,
        BREASTSTROKE,
        BUTTERFLY,
        MEDLEY,
    }

    public enum AgeCategory {
        A9_10,
        A11_12,
        A13_14,
        A15_16,
        A17_18,
        MASTERS,
    }
}
