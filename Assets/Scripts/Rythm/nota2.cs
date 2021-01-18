using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nota2 : MonoBehaviour
{ 
    public Image canvas;
public float speed;
private Animator CAnimation;
private float timeDestroy;

// Start is called before the first frame update
void Start()
{
    CAnimation = GetComponent<Animator>();
    CAnimation.SetBool("batida", true);
    GameObject.Find("barrinha(Clone)").transform.parent = canvas.transform;

    if (gameObject.name == "barrinha(Clone)")
    {
        timeDestroy = 8f;
        Destroy(gameObject, timeDestroy);
    }
}

void Update()
{
    transform.Translate(Vector2.right * speed * Time.deltaTime);
}
}