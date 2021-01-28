using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public float alcool;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        delete();

    }
    void delete()
    {
        float timeDestroy = 3f;
        Destroy(gameObject, timeDestroy);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.name == "drink(Clone)")
            {
                float timeDestroy = 0;
                Destroy(gameObject, timeDestroy);
            }

            if (gameObject.name == "drink2(Clone)")
            {
                float timeDestroy = 0;
                Destroy(gameObject, timeDestroy);
            }
            if (gameObject.name == "drink3(Clone)")
            {
                float timeDestroy = 0;
                Destroy(gameObject, timeDestroy);
            }
            if (gameObject.name == "radio(Clone)")
            {
                float timeDestroy = 0;
                Destroy(gameObject, timeDestroy);
            }
            if (gameObject.name == "disk(Clone)")
            {
                float timeDestroy = 0;
                Destroy(gameObject, timeDestroy);
            }

            if (gameObject.name == "vase(Clone)")
            {
                float timeDestroy = 0;
                Destroy(gameObject, timeDestroy);
                other.gameObject.GetComponent<PlayerMove>().ExternalStun();
            }
        }



        
       
          
    


    }


 }
