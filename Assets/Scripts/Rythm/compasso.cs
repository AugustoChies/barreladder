using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compasso : MonoBehaviour
{
    public bool pegou =false;
    public delegate void PressKey();
    public PressKey movedSideWays,moved;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pegou == true)
        {
            Debug.Log("ponto");
            movedSideWays();
        }

        if (Input.GetKeyDown(KeyCode.Space) && pegou == false)
        {
            Debug.Log("Errou!!");
            // coloque a ação aqui 
        }



    }

    public void CheckTiming()
    {
        if (pegou)
        {
            movedSideWays();
        }
        else
        {

        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "barrinha")
        {
            
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
