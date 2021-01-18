using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nota : MonoBehaviour
{
    public float speed;
    private Animator CAnimation;
    private float timeDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("batida", true);
        // GameObject.Find("barrinha(Clone)").transform.parent = canvas.transform;
        //barrinha.transform.SetParent(canvas);

        
    }

    void Update()
    {
        //GameObject.Find("barrinha(Clone)").transform.parent = canvas.transform;
        if (gameObject.name == "barrinha(Clone)")
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (gameObject.name == "barrinha(Clone)")
        {
            timeDestroy = 0f;
            Destroy(gameObject, timeDestroy);

        }
    }





}