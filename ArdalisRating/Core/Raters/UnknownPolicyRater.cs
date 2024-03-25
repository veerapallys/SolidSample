namespace ArdalisRating
{
    public class UnknownPolicyRater(ILogger logger) : Rater(logger)
    {
       public override decimal Rate(Policy policy)
       {
             logger.Log("Unknown AUTO policy...");
             return 0m;              
       }
    }
}

