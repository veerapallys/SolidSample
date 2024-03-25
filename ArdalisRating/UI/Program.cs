using System;
using System.Threading.Tasks;

namespace ArdalisRating
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            var logger = new Logger();
            var engine = new RatingEngine(logger,new PolicyRepository(),new PolicySerializers(),new PolicyRatingFactory(logger));
            await engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
