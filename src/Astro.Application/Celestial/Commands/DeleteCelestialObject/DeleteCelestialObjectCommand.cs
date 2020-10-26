namespace Astro.Application.Celestial.Commands.DeleteCelestialObject
{
    public class DeleteCelestialObjectCommand : ICommand
    {
        public DeleteCelestialObjectCommand(int id)
        {
            CelestialObjectId = id;
        }

        public int CelestialObjectId { get; }
    }
}
