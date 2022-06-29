using GlobalSharesRocketLib;

namespace GlobalSharesRocket
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var landingArea = new LandingArea();
            landingArea.ChangePlatformSize(10, 10);
            landingArea.ChangePlatformPosition(5, 5);

            // Act
            //Rocket 1
            var result1 = landingArea.RocketRequest(1, 5, 5);
            var result1_1 = landingArea.RocketRequest(1, 5, 6);
            var result2 = landingArea.RocketRequest(2, 16, 15);
            var result3 = landingArea.RocketRequest(3, 7, 7);
            var result4 = landingArea.RocketRequest(4, 7, 6);
            var result5 = landingArea.RocketRequest(5, 6, 6);
            var result6 = landingArea.RocketRequest(6, 14, 14);

            // Assert
            Assert.Equal("ok for landing", result1);
            Assert.Equal("ok for landing", result1_1);
            Assert.Equal("out of platform", result2);
            Assert.Equal("ok for landing", result3);
            Assert.Equal("clash", result4);
            Assert.Equal("clash", result5);
            Assert.Equal("ok for landing", result6);
        }
    }
}