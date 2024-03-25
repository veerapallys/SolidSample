using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        
[Fact]
public async void ReturnsRatingOf10000For200000LandPolicy()
{
    var logger = new Logger();
    var policyRepository = new PolicyRepository();
    var policySerializer = new PolicySerializers();
    var policyRatingFactory = new PolicyRatingFactory(logger);
    var policy = new Policy
    {
        Type = PolicyType.Land,
        BondAmount = 200000,
        Valuation = 200000
    };
    string json = JsonConvert.SerializeObject(policy);
    File.WriteAllText("policy.json", json);

    var engine = new RatingEngine(logger,policyRepository,policySerializer,policyRatingFactory);
    await engine.Rate();
    var result = engine.Rating;

    Assert.Equal(10000, result);
}

        [Fact]
        public async void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            
    var logger = new Logger();
    var policyRepository = new PolicyRepository();
    var policySerializer = new PolicySerializers();
    var policyRatingFactory = new PolicyRatingFactory(logger);
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine(logger,policyRepository,policySerializer,policyRatingFactory);
            await engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }
    }
}
