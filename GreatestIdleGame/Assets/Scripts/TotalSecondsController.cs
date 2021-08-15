using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalSecondsController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI totalSecondsText;
    [SerializeField] private TimeManager timeManager;


    private void Update()
    {
        totalSecondsText.text = Mathf.FloorToInt((timeManager.totalSecondsPlayedSinceStart + Time.time)).ToString() + " seconds doing nothing";
    }
}
