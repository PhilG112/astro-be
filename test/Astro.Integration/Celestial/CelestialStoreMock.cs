using Astro.API.Application.Response.Get;
using Astro.API.Application.Response.Search;
using Astro.API.Application.Stores.Celestial;
using Astro.API.Application.Stores.EntityModels.Enums;
using Moq;
using System.Collections.ObjectModel;

namespace Astro.Integration.Celestial
{
    public class CelestialStoreMock
    {
        public static ICelestialStore GetStoreMock()
        {
            var mockStore = new Mock<ICelestialStore>();

            var getModel = new CelestialGetResponseModel
            {
                Name = "Omega Centauri",
                AbsoluteMagnitude = 4.3,
                Magnitude = 2.5,
                Designation1 = "NGC5139",
                Designation2 = null,
                Designation3 = null,
                Designation4 = null,
                ObjectType = ObjectType.Solar,
                Distances = new Collection<DistanceGetResponseModel>
                {
                    new DistanceGetResponseModel
                    {
                        DistanceType = DistanceType.AU,
                        Tolerance = 4.5,
                        Value = 8.94
                    }
                }
            };

            var getResult = new CelestialGetResult(getModel);

            mockStore.Setup(x => x.GetCelestialObjectAsync(It.IsAny<int>())).ReturnsAsync(getResult);

            return mockStore.Object;
        }
    }
}
