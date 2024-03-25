using System;

namespace ArdalisRating
{
    public interface IPolicyRatingFactory
    {
        Rater Create(Policy policy,RatingEngine ratingEngine);
    }
    public class PolicyRatingFactory(ILogger logger)
    {
        private readonly ILogger logger = logger;
        public Rater Create(Policy policy){
            /*
            switch (policy.Type)
                {
                    case PolicyType.Auto:
                        return new AutoPolicyRater(ratingEngine,logger);
                    case PolicyType.Land:
                       return new LandPolicyRater(ratingEngine,logger);
                    case PolicyType.Life:
                        return new LifePolicyRater(ratingEngine,logger);
                    default:
                        logger.Log("Unknown policy type");
                        return null;
                }
                */
                try
                {
                    return (Rater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),new object[]{logger});
                }
                catch (System.Exception)
                {
                    
                    return new UnknownPolicyRater(logger);
                }
        }
    }
}