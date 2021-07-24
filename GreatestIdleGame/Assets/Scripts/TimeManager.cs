using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int totalSecondsPlayedSinceStart = 0; // Storing the time as int to get a higher max value than float, possibly

    private void Start()
    {
        // Retrieve how much time the player had played when he turned off the game the last time
        //totalSecondsPlayedSinceStart = PlayerPrefs.GetInt(nameof(totalSecondsPlayedSinceStart));
    }

    private void OnApplicationQuit()
    {
        // Save how many seconds the player has played to the system so you can load it up later
        //PlayerPrefs.SetInt(nameof(totalSecondsPlayedSinceStart), ((int)Time.time) + totalSecondsPlayedSinceStart);

        PlayerPrefs.DeleteKey(nameof(totalSecondsPlayedSinceStart));
    }
}
