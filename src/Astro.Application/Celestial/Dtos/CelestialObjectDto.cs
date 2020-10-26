namespace Astro.Application.Celestial.Dtos
{
    public class CelestialObjectDto
    {
        public int Id { get; set; }

        public ObjectTypeDto ObjectType { get; set; }

        public double Magnitude { get; set; }

        public double AbsoluteMagnitude { get; set; }

        public string Name { get; set; }

        public string Designation1 { get; set; }

        public string Designation2 { get; set; }

        public string Designation3 { get; set; }

        public string Designation4 { get; set; }

        public decimal Distance { get; set; }

        public decimal DistanceTolerance { get; set; }
    }
}
