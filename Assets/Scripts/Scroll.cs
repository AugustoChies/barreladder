using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GlobalStats stats;

    private void FixedUpdate()
    {
        this.transform.Translate(Vector2.down * stats.scrollSpeed * Time.deltaTime);
    }  

}
