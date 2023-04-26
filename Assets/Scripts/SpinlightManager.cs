using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle spinlight animations
/// </summary>

public class SpinlightManager : MonoBehaviour
{
    public float spinSpeed;
    public RectTransform[] spinLights;
    public float scaleAmount;
    public float scaleSpeed;

    public void Spin()
    {
        for (int index = 0; index < spinLights.Length; index++)
        {
            float currentSpeed = spinSpeed;
            if (index % 2 == 0)
            {
                currentSpeed *= 2;
            }
            spinLights[index].Rotate(0, 0, Time.deltaTime * currentSpeed);
        }
    }

    // CHALLENGE: animate the scale of the spin lights
    public void Scale()
    {
        for (int index = 0; index < spinLights.Length; index++)
        {
            float newScaleAmount = Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
            Vector3 newScale = Vector3.one * newScaleAmount;

            spinLights[index].localScale = Vector3.one + newScale;
        }
    }
}
