using DemoAPI.Helpers;
using System;
using Xunit;

namespace DemoAPI.UnitTests
{
    public class DateTimeHelpersTests
    {
        [Fact]
        public void DateTimeHelpers_MondayIs4thOfJanuary_AssertEqual()
        {
            var firstMonday = DateTimeHelpers.GetFirstMondayOfYear();
            var assumedMonday = new DateTime(2021, 01, 04);

            Assert.Equal(firstMonday, assumedMonday);
        }

        [Fact]
        public void DateTimeHelpers_DateIsWithinWeek_AssertTrue()
        {
            var date = new DateTime(2021, 01, 05);

            var result = DateTimeHelpers.IsWithinWeekNumber(date, date, 1);

            Assert.True(result);
        }

        [Fact]
        public void DateTimeHelpers_DateIsFirstMondayOfWeek_AssertEqual()
        {
            var date = new DateTime(2021, 01, 18);

            var result = DateTimeHelpers.GetFirstMondayOfWeek(3);

            Assert.Equal(date, result);
        }


    }
}
