using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBarController : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private TextMeshPro levelText;

    // Private variables
    int numOfSecondsToNextLevel = 10; // The number of seconds the game has to be running for the player to get to the next level
    int numOfSecondsLastLevel = 0; // The number of seconds the state of the game was in when the player reached the last level

    Vector3 scaleVector; // A local vector used in order to make scaling of the progress bar faster (less memory usage)

    private void Start()
    {
        scaleVector = Vector3.one;
    }

    private void Update()
    {
        UpdateProgressBar();
    }

    /// <summary>
    /// This function updates the progress bar every frame and handles when the progress bar finishes
    /// </summary>
    private void UpdateProgressBar()
    {
        // The scale of the progress bar is the time already passed (in this current level) divided by the seconds needed
        scaleVector.x = (Time.time - numOfSecondsLastLevel) / numOfSecondsToNextLevel;
        transform.localScale = scaleVector;

        // WHEN PLAYER GOES UP A LEVEL:
        // UPDATE NUMOFSECONDSLASTLEVEL,
        // UPDATE LEVELTEXT,
        // SET SCALEVECTOR.X TO 0
    }
}
