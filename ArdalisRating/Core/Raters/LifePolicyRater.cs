using System;

namespace ArdalisRating
{
    public class LifePolicyRater( ILogger logger) : Rater(logger)
    {
        public override decimal Rate(Policy policy){
            logger.Log("Rating LIFE policy...");
                        logger.Log("Validating policy.");
                        if (policy.DateOfBirth == DateTime.MinValue)
                        {
                            logger.Log("Life policy must include Date of Birth.");
                            return 0m;
                        }
                        if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                        {
                            logger.Log("Centenarians are not eligible for coverage.");
                            return 0m;
                        }
                        if (policy.Amount == 0)
                        {
                            logger.Log("Life policy must include an Amount.");
                            return 0m;
                        }
                        int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                        if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                            DateTime.Today.Day < policy.DateOfBirth.Day ||
                            DateTime.Today.Month < policy.DateOfBirth.Month)
                        {
                            age--;
                        }
                        decimal baseRate = policy.Amount * age / 200;
                        if (policy.IsSmoker)
                        {
                            return baseRate * 2;
                            
                        }
                        return baseRate;
       }

    }
}