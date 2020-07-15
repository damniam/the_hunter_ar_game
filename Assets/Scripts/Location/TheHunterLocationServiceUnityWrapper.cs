namespace TheHunter.Unity.Location
{


    using UnityEngine;


    /// <summary>
    /// Wrap Unity's LocationService into MapboxLocationService
    /// </summary>
    public class TheHunterLocationServiceUnityWrapper : ITheHunterLocationService
    {

        public bool isEnabledByUser { get { return Input.location.isEnabledByUser; } }


        public LocationServiceStatus status { get { return Input.location.status; } }


        public ITheHunterLocationInfo lastData { get { return new TheHunterLocationInfoUnityWrapper(Input.location.lastData); } }


        public void Start(float desiredAccuracyInMeters, float updateDistanceInMeters)
        {
            Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);
        }


        public void Stop()
        {
            Input.location.Stop();
        }



    }
}
