using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compasso : MonoBehaviour
{
    public bool pegou =false;
    protected GameObject activeBar;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool BarFeedBack()
    {        
        if (pegou)
        {
            Destroy(activeBar);
            return true;
        }
        else
        {
            return false;
        }       
    }

    public bool CheckTiming()
    {
        return pegou;
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "barrinha")
        {
            activeBar = other.gameObject;
            pegou = true;
        }

    }

    void OnTriggerExit2D(Collider2D other) { 
        if (other.tag == "barrinha")
        {
            pegou = false;
        }

    }
}
