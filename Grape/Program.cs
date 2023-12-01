using CameraInteraction;
using Cherry;
using System;
using System.Collections.Generic;

namespace Grape
{
    // Program.cs
    class Program
    {
        static void Main()
        {
            // Instantiate the HealthCalculatorModule
            var healthCalculator = new HealthProTechLibrary.HealthCalculatorModule();
            var gender = new HealthProTechLibrary.Gender();

            // Calculate BMR
            double bmr = healthCalculator.CalculateBMR(weight: 70, height: 170, age: 25,);
            Console.WriteLine($"Basal Metabolic Rate (BMR): {bmr} calories");

            // Calculate TDEE
            double tdee = healthCalculator.CalculateTDEE(ActivityLevel.ModeratelyActive);
            Console.WriteLine($"Total Daily Energy Expenditure (TDEE): {tdee} calories");

            // Calculate Daily Caloric Intake for Weight Loss
            double dailyCaloricIntake = healthCalculator.CalculateDailyCaloricIntake(UserGoal.WeightLoss);
            Console.WriteLine($"Daily Caloric Intake for Weight Loss: {dailyCaloricIntake} calories");

            // Record Glucose Level for a User
            string userId = "User123";
            double glucoseLevel = 120;
            healthCalculator.RecordGlucoseLevel(userId, glucoseLevel);

            // Get Stored Glucose Levels for a User
            List<double> storedGlucoseLevels = healthCalculator.GetStoredGlucoseLevels(userId);

            // Display the stored glucose levels
            Console.WriteLine($"Stored Glucose Levels for User {userId}:");
            foreach (var level in storedGlucoseLevels)
            {
                Console.WriteLine(level);
            }
        }
    }

}

