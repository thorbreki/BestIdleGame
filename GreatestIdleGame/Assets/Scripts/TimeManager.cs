using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int totalSecondsPlayedSinceStart = 0; // Storing the time as int to get a higher max value than float, possibly

    [SerializeField] private ProgressBarController progressBarController; // The controller for the progress bar
    [SerializeField] private AchievementsTextController achievementsTextController; // The controller for the achievements text

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
        achievementsTextController.MoveUpOneAchievement(); // Tell the achievements text that it should move up by one achievement
    }

    /// <summary>
    /// This getter returns how many achievements the player has earned
    /// </summary>
    /// <returns></returns>
    public int GetAchievementsEarned()
    {
        return numberOfAchievementsEarned;
    }

    /// <summary>
    /// Creates the achievement array, which stores the seconds needed to finish every achievement
    /// </summary>
    private void CreateAchievementArray()
    {
        achievementArr = new int[32]
        {
            10, // 10 seconds
            20, // 20 seconds
            30, // 30 seconds
            40, // 40 seconds
            50, // 50 seconds
            60, // 1 minute
            120, // 2 minutes
            180, // 3 minutes
            240, // 4 minutes
            300, // 5 minutes
            600, // 10 minutes
            1200, // 20 minutes
            1800, // 30 minutes
            2400, // 40 minutes
            3000, // 50 minutes
            3600, // 1 hour
            7200, // 2 hours
            10800, // 3 hours
            14400, // 4 hours
            18000, // 5 hours
            21600, // 6 hours
            43200, // Half a day
            86400, // 1 day
            172800, // 2 days
            259200, // 3 days
            345600, // 4 days
            432000, // 5 days
            518400, // 6 days
            604800, // 1 week
            1209600, // 2 weeks
            1814400, // 3 weeks
            2592000, // 1 month
        };
    }
}
