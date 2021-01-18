using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public GameObject barrinha;
public Transform point;
   public float cronometro;
    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
    cronometro += Time.deltaTime;

    if (cronometro >= tempo)
         {

        GameObject CloneTiro = Instantiate(barrinha, point.position, point.rotation,transform.parent);
        cronometro = 0;     

         }


    }
}


