using DemoAPI.Extensions;
using System;
using Xunit;

namespace DemoAPI.UnitTests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void DateTimeExtensions_MondayIs4thOfJanuary_AssertEqual()
        {
            var firstMonday = DateTimeExtensions.GetFirstMondayOfYear();
            var assumedMonday = new DateTime(2021, 01, 04);

            Assert.Equal(firstMonday, assumedMonday);
        }
    }
}
