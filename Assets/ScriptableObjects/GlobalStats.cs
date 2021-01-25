using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GlobalStats : ScriptableObject
{
    public float scrollSpeed, pitchChange; 
    public Vector2 baseAndTopSpeed;
    public Vector2 baseandTopPitch;

    public void SetScrollSpeed(float percent)
    {
        float variation = baseAndTopSpeed.y - baseAndTopSpeed.x;
        scrollSpeed = baseAndTopSpeed.x + variation * percent;
        variation = baseandTopPitch.y - baseandTopPitch.x;
        pitchChange = baseandTopPitch.x + variation * percent;
    }
}
