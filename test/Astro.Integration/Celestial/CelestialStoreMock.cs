using Astro.API.Application.Stores.Celestial;
using Astro.API.Application.Stores.EntityModels;
using Moq;

namespace Astro.Integration.Celestial
{
    public class CelestialStoreMock
    {
        public static ICelestialStore GetStoreMock()
        {
            var mockStore = new Mock<ICelestialStore>();

            var model = new CelestialEntityModel
            {
                Id = 1,
                Name = "Omega Centauri",
                AbsoluteMagnitude = 4.3m,
                Magnitude = 2.5m,
                Designation1 = "NGC5139",
                Designation2 = null,
                Designation3 = null,
                Designation4 = null
            };

            mockStore.Setup(x => x.GetCelestialObject()).ReturnsAsync(model);

            return mockStore.Object;
        }
    }
}
