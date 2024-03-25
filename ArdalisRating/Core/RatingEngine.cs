using System.Text.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine(ILogger logger,IPolicyRepository policyRepository,IPolicySerializer policySerializer, PolicyRatingFactory policyRatingFactory)
    {
        private readonly ILogger logger = logger;
        private readonly IPolicyRepository policyRepository = policyRepository;
        private readonly IPolicySerializer policySerializer = policySerializer;
        private readonly PolicyRatingFactory policyRatingFactory = policyRatingFactory;

        public decimal Rating { get; set; }
        public async Task Rate()
        {
            logger.Log("Starting rate.");
            logger.Log("Loading policy.");
            
            // load policy - open file policy.json          
              string policyJson = await policyRepository.GetPolicy();
              var policy =  await policySerializer.GetPolicyfromJsonString(policyJson);
              var rater = policyRatingFactory.Create(policy);  
              this.Rating = rater.Rate(policy);  
             logger.Log("Rating completed.");
        }
    }
}

/*
   1. Validation
   2. Different policies
   3. Tight coupling
   4. Loose cohesion.
   5. Violation of SRP.
   6. Logging
   7. Persistence
   8. Deserialization

*/