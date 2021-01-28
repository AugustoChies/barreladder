using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GlobalStats : ScriptableObject
{
    public float scrollSpeed, pitchChange; 
    public Vector2 baseAndTopSpeed;
    public Vector2 baseandTopPitch;
    public Vector2 baseandTopPointGain;
    public Vector2 scoreBarrier;
    public float drunkness;
    public float currentScore,scorevariation;


    public void SetScrollSpeed(float percent)
    {
        float variation = baseAndTopSpeed.y - baseAndTopSpeed.x;
        scrollSpeed = baseAndTopSpeed.x + variation * percent;
        variation = baseandTopPitch.y - baseandTopPitch.x;
        pitchChange = baseandTopPitch.x + variation * percent;
    }

    public void ChangePointValueDeltaTime(float percent)
    {
        float variation = baseandTopPointGain.y - baseandTopPointGain.x;
        currentScore += (baseandTopPointGain.x + variation * percent) * Time.deltaTime;
        scorevariation = (baseandTopPointGain.x + variation * percent)/ baseandTopPointGain.x;
    }

    public void ChangePointValue(float value)
    {
        currentScore += value;
        if(currentScore < 0)
        {
            currentScore = 0;
        }
    }
}
