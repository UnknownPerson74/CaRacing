using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMark : MonoBehaviour
{
  
    public GameObject BL;
    public GameObject BR;

    public float skidMarkIntensity = 1.0f; // Adjust the intensity of the skid mark effect

    void Update()
    {
        Effect();
    }

    void Effect()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Start emitting skid marks for all wheels
           
            EnableSkidMark(BL);
            EnableSkidMark(BR);
        }
        else
        {
            // Stop emitting skid marks for all wheels
           
            DisableSkidMark(BL);
            DisableSkidMark(BR);
        }
    }

    void EnableSkidMark(GameObject wheel)
    {
        TrailRenderer trailRenderer = wheel.GetComponentInChildren<TrailRenderer>();
        if (trailRenderer != null)
        {
            trailRenderer.emitting = true;
            trailRenderer.time = Mathf.Infinity; // Skid marks persist until manually stopped
            trailRenderer.widthMultiplier = skidMarkIntensity; // Adjust the width of the skid mark
        }
    }

    void DisableSkidMark(GameObject wheel)
    {
        TrailRenderer trailRenderer = wheel.GetComponentInChildren<TrailRenderer>();
        if (trailRenderer != null)
        {
            trailRenderer.emitting = false;
        }
    }
}
