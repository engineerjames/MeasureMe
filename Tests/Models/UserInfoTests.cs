namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WebApplication.Models;

    [TestClass]
    public class UserInfoTests
    {
        [TestMethod]
        public void CanConstruct()
        {
            UserInfo p = new UserInfo();

            Assert.AreNotEqual(p, null);
        }

        [TestMethod]
        public void CanCalculateMaleTDEE()
        {
            UserInfo newMale = new UserInfo() { 
                Age = 32, 
                HeightInInches = 72, 
                Sex = SexType.Male, 
                WeightInPounds = 185, 
                ActivityFactor = ActivityFactor.GetActivityFactor(ActivityFactor.ActivityType.LittleToNoExercise) 
            };

            uint expectedBMR = 1827;
            uint actualBMR = newMale.GetBasalMetabolicRate();

            Assert.AreEqual(expectedBMR, actualBMR);

            uint expectedTDEE = 2192;
            uint actualTDEE = newMale.GetTotalDailyEnergyExpenditure();

            Assert.AreEqual(expectedTDEE, actualTDEE);
        }

        [TestMethod]
        public void CanCalculateFemaleTDEE()
        {
            UserInfo newMale = new UserInfo() { 
                Age = 43, 
                HeightInInches = 56, 
                Sex = SexType.Female, 
                WeightInPounds = 125, 
                ActivityFactor = ActivityFactor.GetActivityFactor(ActivityFactor.ActivityType.HardExercise) 
            };

            uint expectedBMR = 1079;
            uint actualBMR = newMale.GetBasalMetabolicRate();

            Assert.AreEqual(expectedBMR, actualBMR);

            uint expectedTDEE = 1861;
            uint actualTDEE = newMale.GetTotalDailyEnergyExpenditure();

            Assert.AreEqual(expectedTDEE, actualTDEE);
        }
    }
}
