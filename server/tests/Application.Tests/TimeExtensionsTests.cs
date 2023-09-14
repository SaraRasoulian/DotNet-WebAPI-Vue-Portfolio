using Application.Extentions;

namespace Application.Tests
{
    public class TimeExtensionsTests
    {
        [Fact]
        public void TimeAgo_Returns_SecondsAgo_When_Time_Span_Is_Within_One_Minute()
        {
            //Arrange
            var now = DateTime.UtcNow;
            var dateTime = now.AddSeconds(-30);

            //Act
            var result = dateTime.TimeAgo();

            //Assert
            Assert.Equal("30 seconds ago", result);
        }

        [Fact]
        public void TimeAgo_Returns_About_A_Minute_Ago_When_Time_Span_Is_One_Minute()
        {
            //Arrange
            var now = DateTime.UtcNow;
            var dateTime = now.AddMinutes(-1);

            //Act
            var result = dateTime.TimeAgo();

            //Assert
            Assert.Equal("about a minute ago", result);
        }

        [Fact]
        public void TimeAgo_Returns_HoursAgo_When_Time_Span_Is_Within_One_Day()
        {
            //Arrange
            var now = DateTime.UtcNow;
            var dateTime = now.AddHours(-6);

            //Act
            var result = dateTime.TimeAgo();

            //Assert
            Assert.Equal("6 hours ago", result);
        }

        [Fact]
        public void TimeAgo_Returns_DaysAgo_When_Time_Span_Is_Within_One_Month()
        {
            //Arrange
            var now = DateTime.UtcNow;
            var dateTime = now.AddDays(-12);

            //Act
            var result = dateTime.TimeAgo();

            //Assert
            Assert.Equal("12 days ago", result);
        }

        [Fact]
        public void TimeAgo_Returns_YearsAgo_When_Time_Span_Is_Years_Ago()
        {
            //Arrange
            var now = DateTime.UtcNow;
            var dateTime = now.AddYears(-2);

            //Act
            var result = dateTime.TimeAgo();

            //Assert
            Assert.Equal("2 years ago", result);
        }
    }
}
