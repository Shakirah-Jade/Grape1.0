using CameraInteraction;
using Cherry;
using System;

namespace Grape
{
    class Program
    {
        static void Main(string[] args)
        {
           double bmr = BMRCalculator.CalculateBMR("male", 70, 175.0, 30);

          
            /* string activityLevel = "moderately active";
             double dailycaloricintake = BMRCalculator.CalculateDailyCaloricIntake(bmr, activityLevel); // getting the dailycaloric intake
             Console.WriteLine($"The DailyCaloricIntake for a {gender} with age {age} and the {bmr} calories per day is: {dailycaloricintake}");

             double dailyexpenditure = BMRCalculator.CalculateTotalDailyExpenditure(bmr, dailycaloricintake);
             double depletion = BMRCalculator.CalculateGlucoseDepletion(dailyexpenditure);
             double bodyintake = BMRCalculator.CalculateBodyIntakeRate(depletion);
             double foodcomposition = BMRCalculator.CalculateFoodGlucoseComposition(40, bodyintake);*/


            // interaction with the camera.
            /*Interaction cameraInteraction = new Interaction();
            cameraInteraction.StartCamera();
*/
        }
    }
}
