namespace ArdalisRating
{
    public abstract class Rater(ILogger logger)
    {
       
       protected readonly ILogger logger = logger;
        public abstract decimal Rate(Policy policy);
    }
}