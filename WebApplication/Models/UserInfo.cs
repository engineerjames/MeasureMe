namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ActivityFactor
    {
        public enum ActivityType
        {
            LittleToNoExercise,
            LightExercise,
            ModerateExercise,
            HardExercise,
            ProfessionalAthlete
        };

        private static Dictionary<ActivityType, ActivityFactor> ActivityFactorDictionary = new Dictionary<ActivityType, ActivityFactor>() 
        {
            { ActivityType.LittleToNoExercise  , new ActivityFactor(1.2,   "Little to no exercise (sedentary)") },
            { ActivityType.LightExercise       , new ActivityFactor(1.375, "Light exercise (1 - 3 times/week)") },
            { ActivityType.ModerateExercise    , new ActivityFactor(1.55,  "Moderate exercise (3 - 5 times/week)") },
            { ActivityType.HardExercise        , new ActivityFactor(1.725, "Physical job or hard exercise (6 - 7 times/week)") },
            { ActivityType.ProfessionalAthlete , new ActivityFactor(1.9,   "Professional athlete") }
        };

        public double Multiplier { get; }
        public string Description { get; }

        public ActivityFactor(double multiplier, string description)
        {
            Multiplier = multiplier;
            Description = description;
        }

        public static ActivityFactor GetActivityFactor(ActivityType activityType)
        {
            return ActivityFactorDictionary[activityType];
        }
    }

    public enum SexType { Male, Female }

    public class UserInfo
    {
        public SexType Sex { get; set; }
        public int Age { get; set; }
        public int HeightInInches { get; set; }
        public int WeightInPounds { get; set; }
        public ActivityFactor ActivityFactor { get; set; }

        public uint GetBasalMetabolicRate()
        {
            int offset = Sex == SexType.Female ? -161 : 5;

            const double POUNDS_TO_KILOGRAMS = 0.45359237;
            const double INCHES_TO_CENTIMETERS = 2.54;

            // Formula provided by: https://www.omnicalculator.com/health/tdee
            // 10 * weight (kg) + 6.25 * height (cm) - 5 * age (y) + offset (+5 for men, -161 for women)
            return (uint)(10 * WeightInPounds * POUNDS_TO_KILOGRAMS + 6.25 * HeightInInches * INCHES_TO_CENTIMETERS -
                5 * Age + offset);
        }

        public uint GetTotalDailyEnergyExpenditure()
        {
            return (uint)(GetBasalMetabolicRate() * ActivityFactor.Multiplier);
        }

    }
}
