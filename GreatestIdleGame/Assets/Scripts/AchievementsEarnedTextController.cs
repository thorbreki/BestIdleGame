using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsEarnedTextController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI AchievementsText;
    [SerializeField] private TimeManager timeManager;

    // Update is called once per frame
    private void Update()
    {
        AchievementsText.text = timeManager.GetAchievementsEarned().ToString() + " achievements earned";
    }
}
