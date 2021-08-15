using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsTextController : MonoBehaviour
{
    // SERIALIZED VARIABLES
    private float lerpIterationAmount = 0.00005f; // How much the achievements text travels up in each iteration
    // COROUTINE OBJECTS
    private Coroutine lerpUpCoroutine;

    public void MoveUpOneAchievement()
    {
        if (lerpUpCoroutine != null) { StopCoroutine(lerpUpCoroutine); } // Make sure that the lerp up coroutine isn't already running
        lerpUpCoroutine = StartCoroutine(LerpUp(2.3f));
    }

    /// <summary>
    /// Lerps the game object's y position by the specified amount
    /// </summary>
    /// <param name="upAmount"></param>
    /// <returns></returns>
    private IEnumerator LerpUp(float upAmount)
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + upAmount, transform.position.z); // The ending position
        //Vector3 startingPosition = transform.position; // The starting position of the game object
        float t = 0;

        while (t < 1)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            t += lerpIterationAmount;
            yield return null;
        }
    }
}
