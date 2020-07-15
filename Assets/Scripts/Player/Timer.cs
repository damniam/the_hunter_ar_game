using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public int timeScale;
    public Text time;

    private float currentTime = 1;
    private int days = 0;
    private bool skipFrame = false;
    private int condition = 1;
    private void Start()
    {
    }
    private void Update()
    {
        // Dodawanie czasu
        if (!skipFrame)
        {
            currentTime += Time.unscaledDeltaTime;
            days = ((int)currentTime / timeScale);
            time.text = days.ToString();
            if (condition == days)
            {
                GameManager.Instance.CurrentPlayer.SetSurvivedDays(days);
                condition++;
            }
        }
        else
        {
            skipFrame = false;
            Debug.Log("Czas naliczony podczas pauzy: " + Time.unscaledDeltaTime);
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            skipFrame = true;
        }

    }
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            skipFrame = true;
        }
    }
}
