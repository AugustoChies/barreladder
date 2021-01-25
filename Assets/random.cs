using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    
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



}
