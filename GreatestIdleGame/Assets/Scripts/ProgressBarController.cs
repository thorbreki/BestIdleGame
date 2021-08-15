using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBarController : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private TextMeshPro levelText;
    [SerializeField] private TimeManager timeManager; // The Time Manager component of the time manager object

    // Private variables
    private int numOfSecondsToNextLevel = 10; // The number of seconds the game has to be running for the player to get to the next level

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
        scaleVector.x = (timeManager.totalSecondsPlayedSinceStart + Time.time) / numOfSecondsToNextLevel;
        transform.localScale = scaleVector;

        // WHEN PLAYER GOES UP A LEVEL:
        if (transform.localScale.x >= 1f)
        {
            UpgradeToNextAchievement();
        }
    }

    public void TestPrint()
    {
        print("The current time in ProgressBarController: " + Time.time);
    }

    /// <summary>
    /// This function calls when the progress bar fills up and the player earns the current achievement
    /// </summary>
    private void UpgradeToNextAchievement()
    {
        // Tell time manager that it is time to progress to the next level
        timeManager.UpgradeToNextAchievement();
        // Tell achievement text that it is time to translate up so that the next achievement will be on the same y position as the progress bar
    }


    /// <summary>
    /// A setter for the numOfSecondsToNextLevel variable
    /// </summary>
    /// <param name="newValue"></param>
    public void SetNumOfSecondsToNextLevel(int newValue)
    {
        numOfSecondsToNextLevel = newValue;
    }
}
