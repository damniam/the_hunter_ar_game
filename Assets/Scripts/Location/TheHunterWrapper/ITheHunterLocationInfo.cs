namespace TheHunter.Unity.Location
{


    public interface ITheHunterLocationInfo
    {

        float latitude { get; }

        float longitude { get; }

        float altitude { get; }

        float horizontalAccuracy { get; }

        float verticalAccuracy { get; }

        double timestamp { get; }
    }
}