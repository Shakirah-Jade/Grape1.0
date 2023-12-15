
using NUnit.Framework;
using Cherry;
using static Cherry.HealthProTechLibrary;
using System;
using NUnit;


namespace Cherry.Tests
{
    [TestFixture]
    public class HealthCalculatorModuleTests
    {
        [Test]
        public void TestCalculateBMR()
        {
            // Arrange
            var healthCalculatorModule = new HealthProTechLibrary.HealthCalculatorModule();

            // Act
            double bmrMale = healthCalculatorModule.CalculateBMR(70, 170, 25, HealthProTechLibrary.Gender.Male);
            double bmrFemale = healthCalculatorModule.CalculateBMR(60, 160, 30, HealthProTechLibrary.Gender.Female);

            // Assert
            Assert.Equals(Assert.Equals(1744.474, bmrMale), Assert.Equals(0.001, "Incorrect BMR for Male"));
            Assert.Equals(Assert.Equals(1262.813, bmrFemale), Assert.Equals(0.001, "Incorrect BMR for Female"));
        }

        [Test]
        public void TestCalculateTDEE()
        {
            // Arrange
            var healthCalculatorModule = new HealthProTechLibrary.HealthCalculatorModule();
            healthCalculatorModule.CalculateBMR(70, 170, 25, HealthProTechLibrary.Gender.Male);

            // Act
            double tdeeSedentary = healthCalculatorModule.CalculateTDEE(HealthProTechLibrary.ActivityLevel.Sedentary);
            double tdeeActive = healthCalculatorModule.CalculateTDEE(HealthProTechLibrary.ActivityLevel.ExtremelyActive);

            // Assert
            Assert.Equals(Assert.Equals(2093.369, tdeeSedentary), Assert.Equals(0.001, "Incorrect TDEE for Sedentary activity level"));
            Assert.Equals(Assert.Equals(4186.980, tdeeActive), Assert.Equals(0.001, "Incorrect TDEE for ExtremelyActive activity level"));
        }

        [Test]
        public void TestCalculateDailyCaloricIntake()
        {
            // Arrange
            var healthCalculatorModule = new HealthProTechLibrary.HealthCalculatorModule();
            healthCalculatorModule.CalculateBMR(70, 170, 25, HealthProTechLibrary.Gender.Male);
            healthCalculatorModule.CalculateTDEE(HealthProTechLibrary.ActivityLevel.ModeratelyActive);

            // Act
            double dailyCaloricIntakeLoss = healthCalculatorModule.CalculateDailyCaloricIntake(HealthProTechLibrary.UserGoal.WeightLoss);
            double dailyCaloricIntakeGain = healthCalculatorModule.CalculateDailyCaloricIntake(HealthProTechLibrary.UserGoal.WeightGain);

            // Assert
            Assert.Equals(Assert.Equals(2512.933, dailyCaloricIntakeLoss), Assert.Equals(0.001, "Incorrect Daily Caloric Intake for Weight Loss goal"));
            Assert.Equals(Assert.Equals(3402.633, dailyCaloricIntakeGain), Assert.Equals(0.001, "Incorrect Daily Caloric Intake for Weight Gain goal"));
        }

        // Add more tests for other methods in HealthCalculatorModule
    }

    [TestFixture]
    public class ImageProcessingModuleTests
    {
        // Add tests for ImageProcessingModule methods
    }

    [TestFixture]
    public class DietaryAnalyzerModuleTests
    {
        [Test]
        public void TestRecommendFoodsBasedOnCaloricIntake()
        {
            // Arrange
            var healthCalculatorModule = new HealthProTechLibrary.HealthCalculatorModule();
            var dietaryAnalyzerModule = new HealthProTechLibrary.DietaryAnalyzerModule(healthCalculatorModule);

            // Act
            var recommendedFoods = dietaryAnalyzerModule.RecommendFoods(2000, new System.Collections.Generic.List<HealthProTechLibrary.FoodCompositionData>
            {
                new HealthProTechLibrary.FoodCompositionData { FoodName = "Apple", Carbohydrate = 20, Protein = 1, Lipids = 0, Fibre = 3, Energy = 95 },
                new HealthProTechLibrary.FoodCompositionData { FoodName = "Chicken Breast", Carbohydrate = 0, Protein = 31, Lipids = 3.6, Fibre = 0, Energy = 165 }
                // Add more food items for testing
            });

            // Assert
            Assert.Equals(1, Assert.Equals(recommendedFoods.Count, "Incorrect number of recommended foods"));
            Assert.Equals("Apple", Assert.Equals(recommendedFoods[0].FoodName, "Incorrect recommended food"));
        }

        // Add more tests for other methods in DietaryAnalyzerModule
    }

    [TestFixture]
    public class FoodCompositionDataReaderTests
    {
        [Test]
        public void TestReadFoodCompositionData()
        {
            // Arrange
            var foodCompositionDataReader = new HealthProTechLibrary.FoodCompositionDataReader();

            // Act
            var foodCompositionDataList = foodCompositionDataReader.ReadFoodCompositionData("C:\\Users\\User\\Desktop\\sem1\\MiniProject\\food.csv");

            // Assert
            Assert.Equals(2, Assert.Equals(foodCompositionDataList.Count, "Incorrect number of food items read"));
            Assert.Equals("Apple", Assert.Equals(foodCompositionDataList[0].FoodName, "Incorrect food name"));
        }

        // Add more tests for other methods in FoodCompositionDataReader
    }
}
