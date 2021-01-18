using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GlobalStats : ScriptableObject
{
    public float scrollSpeed;
    public Vector2 baseAndTopSpeed;

    public void SetScrollSpeed(float percent)
    {
        float variation = baseAndTopSpeed.y - baseAndTopSpeed.x;
        scrollSpeed = baseAndTopSpeed.x + variation * percent;
    }
}
