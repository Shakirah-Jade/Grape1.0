using Cherry;
using System;
using System.Collections.Generic;
using static Cherry.HealthProTechLibrary;

namespace Grape
{
    class Program
    {
        static void Main()
        {
            // Instantiate the HealthCalculatorModule
            var healthCalculator = new HealthProTechLibrary.HealthCalculatorModule();

            // Calculate BMR
            double bmr = healthCalculator.CalculateBMR(weight: 70, height: 170, age: 25, Gender.Male);
            Console.WriteLine($"Basal Metabolic Rate (BMR): {bmr} calories");

            // Calculate TDEE
            double tdee = healthCalculator.CalculateTDEE(ActivityLevel.ModeratelyActive);
            Console.WriteLine($"Total Daily Energy Expenditure (TDEE): {tdee} calories");

            // Calculate Daily Caloric Intake for Weight Loss
            double dailyCaloricIntake = healthCalculator.CalculateDailyCaloricIntake(UserGoal.WeightLoss);
            Console.WriteLine($"Daily Caloric Intake for Weight Loss: {dailyCaloricIntake} calories");

            // Record Glucose Level for a User
            string userId = "User123";
            double glucoseLevel = 7; //in mmol/L
            healthCalculator.RecordGlucoseLevel(userId, glucoseLevel);

            // Get Stored Glucose Levels for a User
            List<double> storedGlucoseLevels = healthCalculator.GetStoredGlucoseLevels(userId);

            // Display the stored glucose levels
            Console.WriteLine($"Stored Glucose Levels for User {userId}:");
            foreach (var level in storedGlucoseLevels)
            {
                Console.WriteLine(level);
            }



/*
            // Create an instance of the ImageProcessingModule
            var imageProcessor = new HealthProTechLibrary.ImageProcessingModule();

            // Start the camera and capture an image
            imageProcessor.StartCamera();*/

            string csvFilePath = "C:\\Users\\User\\Desktop\\sem1\\MiniProject\\food.csv";

            // Create an instance of the DietaryAnalyzerModule
             var dietaryAnalyzerModule = new HealthProTechLibrary.DietaryAnalyzerModule(healthCalculator);

            // Load food composition data from the CSV file
            var foodCompositionData = dietaryAnalyzerModule.LoadFoodCompositionData(csvFilePath);

            // Print the loaded data to the terminal
            /*PrintFoodCompositionData(foodCompositionData);*/
            dietaryAnalyzerModule.RecommendFoodsBasedOnCaloricIntake(csvFilePath, userId,UserGoal.WeightLoss);
        }
        
        static void PrintFoodCompositionData(List<FoodCompositionData> foodCompositionData)
        {
            Console.WriteLine("Food Composition Data:");
            foreach (var foodData in foodCompositionData)
            {
                Console.WriteLine($"FoodName: {foodData.FoodName}");
                Console.WriteLine($"Country: {foodData.Country}");
                Console.WriteLine($"Protein: {foodData.Protein}");
                Console.WriteLine($"Carbohydrate: {foodData.Carbohydrate}");
                Console.WriteLine($"Lipids: {foodData.Lipids}");
                Console.WriteLine($"Fibre: {foodData.Fibre}");
                Console.WriteLine($"Energy: {foodData.Energy}");

                // Add additional properties as needed
                Console.WriteLine("------------------------");
            }
        }

    }

}

