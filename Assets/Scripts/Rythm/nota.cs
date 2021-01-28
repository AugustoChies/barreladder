using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nota : MonoBehaviour
{
    public float speed;
    public GlobalStats stats;
    private Animator CAnimation;
    private float timeDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        CAnimation = GetComponent<Animator>();
        CAnimation.SetBool("batida", true);     
    }

    void Update()
    {        
        transform.Translate(Vector2.down * speed * Time.deltaTime);        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (gameObject.name == "barrinha(Clone)")
        {
            Delete();

        }
    }

    public void Delete()
    {
        timeDestroy = 0f;
        Destroy(gameObject, timeDestroy);
    }





}