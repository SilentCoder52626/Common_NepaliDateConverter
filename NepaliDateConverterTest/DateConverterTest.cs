using NepaliDateConverter;
using System.Runtime.CompilerServices;

namespace NepaliDateConverterTest
{
    public class DateConverterFixture : IDisposable
    {
        public IDateConverterService DateConverterService { get; private set; }

        public DateConverterFixture()
        {
            DateConverterService = new DateConverterService();
        }

        public void Dispose()
        {
            DateConverterService = null;
        }
    }
    public class DateConverterTest : IClassFixture<DateConverterFixture>
    {
        private readonly IDateConverterService _dateConverter;

        public DateConverterTest(DateConverterFixture fixture)
        {
            _dateConverter = fixture.DateConverterService;
        }

        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange
            string nepaliDate = "2081/03/08";
            DateTime expectedDate = new DateTime(2024, 6, 22);
            // Act
            DateTime result = _dateConverter.ToAD(nepaliDate);

            // Assert
            Assert.Equal(expectedDate, result);
        }
    }
}