using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public GlobalStats stats;
    public GameObject barrinha;
    public Transform point;
    public float cronometro;
    public float bpm;
    public float distance;
    public RectTransform target;
    
    // Start is called before the first frame update
    void Start()
    {
        distance = this.GetComponent<RectTransform>().position.y - target.position.y;
        GameObject CloneTiro = Instantiate(barrinha, point.position, point.rotation, transform.parent);
        CloneTiro.GetComponent<nota>().speed = distance / (120 / bpm);
    }

    // Update is called once per frame
    void Update()
    {
        cronometro += Time.deltaTime * stats.pitchChange;

        if (cronometro >= (60/bpm))
        {
            GameObject CloneTiro = Instantiate(barrinha, point.position, point.rotation,transform.parent);
            CloneTiro.GetComponent<nota>().speed = (distance / (120/bpm)) * stats.pitchChange;
            cronometro = 0;    
        }

    }
}


