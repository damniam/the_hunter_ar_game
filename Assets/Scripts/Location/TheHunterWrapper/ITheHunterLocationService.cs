namespace TheHunter.Unity.Location
{


    // using UnityEngine;
    using UnityEngine;

    public interface ITheHunterLocationService
    {


        bool isEnabledByUser { get; }

        LocationServiceStatus status { get; }

        ITheHunterLocationInfo lastData { get; }

        void Start(float desiredAccuracyInMeters, float updateDistanceInMeters);

        void Stop();
    }
}