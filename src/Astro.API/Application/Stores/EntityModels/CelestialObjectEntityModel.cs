namespace Astro.API.Application.Stores.EntityModels
{
    public class CelestialObjectEntityModel
    {
        public int Id { get; set; }

        public decimal Magnitude { get; set; }

        public decimal AbsoluteMagnitude { get; set; }

        public string Name { get; set; }

        public string Designation1 { get; set; }

        public string Designation2 { get; set; }

        public string Designation3 { get; set; }

        public string Designation4 { get; set; }
    }
}
