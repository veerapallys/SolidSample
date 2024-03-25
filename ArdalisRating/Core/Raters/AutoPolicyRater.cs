using System;

namespace ArdalisRating
{
    public class AutoPolicyRater(ILogger logger) : Rater(logger)
    {
       public override decimal Rate(Policy policy)
       {
            logger.Log("Rating AUTO policy...");
            logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                logger.Log("Auto policy must specify Make");
                return 0m;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    
                    return 1000m;
                }
                return 900m;
            }
            return 0m;
         }
    }
}

