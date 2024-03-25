using Xunit;
using ArdalisRating;

namespace ArdalisRating.Tests
{
    public class PolicySerializerTest
    {
        [Fact]
        public async void ReturnsDefaultPolicyFromEmptyJson(){
            //Arrange
            var input="{}";
            var serializer = new PolicySerializers();
            
            //Act
            var result = await serializer.GetPolicyfromJsonString(input);

            //Assert

            var policy = new Policy();
            Assert.Equal<Policy>(policy,result);
        }
    }
}
