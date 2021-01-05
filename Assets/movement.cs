using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool naEscada;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && naEscada == true)
        {
            transform.Translate(0, 10 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) && naEscada == true)
        {
            transform.Translate(0, -10 * Time.deltaTime, 0);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Escada")
        {
            naEscada = true;
        }
       
    }



}
   

