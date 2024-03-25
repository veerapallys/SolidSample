using System;

namespace ArdalisRating
{
    public class LandPolicyRater(ILogger logger) :  Rater(logger)
    {
     
       public override decimal Rate(Policy policy){
             logger.Log("Rating LAND policy...");
                        logger.Log("Validating policy.");
                        if (policy.BondAmount == 0 || policy.Valuation == 0)
                        {
                            logger.Log("Land policy must specify Bond Amount and Valuation.");
                            return 0m;
                        }
                        if (policy.BondAmount < 0.8m * policy.Valuation)
                        {
                            logger.Log("Insufficient bond amount.");
                            return 0m;
                        }
                        return policy.BondAmount * 0.05m;
       }

        
    }
}