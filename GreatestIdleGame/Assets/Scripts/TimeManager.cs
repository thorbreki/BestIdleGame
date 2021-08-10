using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int totalSecondsPlayedSinceStart = 0; // Storing the time as int to get a higher max value than float, possibly

    [SerializeField] private ProgressBarController progressBarController; // The controller for the progress bar

    private int numberOfAchievementsEarned = 0; // How many achievements the player has earned

    private int[] achievementArr; // the array which holds all the seconds needed to finish every achievement

    private void Start()
    {
        // Create the achievement array
        CreateAchievementArray();

        // Retrieve how much time the player had played when he turned off the game the last time
        totalSecondsPlayedSinceStart = PlayerPrefs.GetInt(nameof(totalSecondsPlayedSinceStart));

        // Retrieve how many achievements the player has earned to straight away know the player's progress
        numberOfAchievementsEarned = PlayerPrefs.GetInt(nameof(numberOfAchievementsEarned));

        // Update the progress bar to the state it was in when the player last turned off the game
        progressBarController.SetNumOfSecondsToNextLevel(achievementArr[numberOfAchievementsEarned]);
    }

    private void OnApplicationQuit()
    {
        // Save how many seconds the player has played to the system so you can load it up later
        //PlayerPrefs.SetInt(nameof(totalSecondsPlayedSinceStart), ((int)Time.time) + totalSecondsPlayedSinceStart);

        // Save how many ahcievements the player has recieved to easily figure out the player's progress
        //PlayerPrefs.SetInt(nameof(numberOfAchievementsEarned), numberOfAchievementsEarned);

        //PlayerPrefs.DeleteKey(nameof(totalSecondsPlayedSinceStart)); // ----------DEBUG
    }

    /// <summary>
    /// This function handles everything when upgrading to the next achievement
    /// </summary>
    public void UpgradeToNextAchievement()
    {
        numberOfAchievementsEarned++; // The player just earned a new achievement obviously
        progressBarController.SetNumOfSecondsToNextLevel(achievementArr[numberOfAchievementsEarned]); // Tell the progress bar how many seconds needed to earn achievement
    }

    /// <summary>
    /// Creates the achievement array, which stores the seconds needed to finish every achievement
    /// </summary>
    private void CreateAchievementArray()
    {
        achievementArr = new int[6]
        {
            10,
            20,
            30,
            40,
            50,
            60
        };
    }
}
