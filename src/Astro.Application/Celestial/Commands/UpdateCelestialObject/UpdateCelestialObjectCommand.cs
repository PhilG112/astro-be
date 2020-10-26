using Astro.Application.Celestial.Dtos;
using NJsonSchema.Annotations;

namespace Astro.Application.Celestial.Commands.UpdateCelestialObject
{
    public class UpdateCelestialObjectCommand : ICommand
    {
        [JsonSchemaIgnore]
        public int Id { get; set; }

        public ObjectTypeDto ObjectType { get; set; }

        public double Magnitude { get; set; }

        public double AbsoluteMagnitude { get; set; }

        public string Name { get; set; }

        public string Designation1 { get; set; }

        public string Designation2 { get; set; }

        public string Designation3 { get; set; }

        public string Designation4 { get; set; }

        public string Description { get; set; }

        public double Distance { get; set; }

        public double DistanceTolerance { get; set; }
    }
}
