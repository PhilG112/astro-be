using System.Threading;
using System.Threading.Tasks;
using Astro.Abstractions.Data;
using Astro.Application.Celestial.Commands.CreateCelestialObject;
using Astro.Application.Celestial.Dtos;
using FluentAssertions;
using Moq;
using Xunit;

namespace Astro.Facts.Commands.Celestial
{
    public class CreateCelestialObjectTests
    {
        [Fact]
        public async Task GivenValidObject_WhenHandling_ThenReturnCorrectResult()
        {
            var handler = GetHandler();

            var result = await handler.Handle(GetCommand(), CancellationToken.None);

            result.Should().Be(1);
        }

        private CreateCelestialObjectCommandHandler GetHandler(
            Mock<ISqlDataRepository> dataRepoMock = null)
        {
            if (dataRepoMock is null)
            {
                dataRepoMock = new Mock<ISqlDataRepository>();

                dataRepoMock.Setup(x => x.QueryFirstAsync<int>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(1);
            }

            return new CreateCelestialObjectCommandHandler(dataRepoMock.Object);
        }

        private CreateCelestialObjectCommand GetCommand()
        {
            return new CreateCelestialObjectCommand
            {
                Name = "name",
                AbsoluteMagnitude = 10,
                Description = "description",
                Designation1 = "d1",
                Designation2 = "d2",
                Designation3 = "d3",
                Designation4 = "d4",
                Distance = 11,
                DistanceTolerance = 1,
                Magnitude = 20,
                ObjectType = ObjectTypeDto.Galaxy
            };
        }
    }
}
