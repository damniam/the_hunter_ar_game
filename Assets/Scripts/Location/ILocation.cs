namespace TheHunter.Unity.Location
{
    using System;

    public interface ILocationProvider
{
    event Action<Location> OnLocationUpdated;
    Location CurrentLocation { get; }
}
}
