using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalSecondsController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI totalSecondsText;
    private void Update()
    {
        totalSecondsText.text = "Total seconds doing nothing: " + Time.time.ToString("F0");
    }
}
