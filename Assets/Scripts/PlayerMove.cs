using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public List<Transform> playerPositions;
    private Rigidbody2D rb;
    private int currentPosition;
    private bool move;
    public int highLimit, lowLimit;
    public float speed;
    protected Vector2 vertMmovement;
    public GlobalStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats.SetScrollSpeed(0.0f);
        rb = GetComponent<Rigidbody2D>();
        vertMmovement = Vector2.zero;
        currentPosition = 3;
        Vector2 newPos = new Vector2(playerPositions[currentPosition].position.x, rb.position.y);
        rb.MovePosition(newPos);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentPosition > 0)
            {
                currentPosition--;
                move = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPosition < playerPositions.Count - 1)
            {
                currentPosition++;
                move = true;
            }
        }
        vertMmovement.y = 0;
        if (Input.GetKey(KeyCode.W) && rb.position.y < highLimit)
        {
            vertMmovement.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) && rb.position.y > lowLimit)
        {
            vertMmovement.y = -1;
        }        
    }

    private void FixedUpdate()
    {
        if (move)
        {
            move = false;
            Vector2 newPos = new Vector2(playerPositions[currentPosition].position.x, rb.position.y);
            rb.MovePosition(newPos);
        }
        else
        {
            rb.MovePosition(rb.position + (vertMmovement * speed * Time.deltaTime));
        }

        float percentHeight = (rb.position.y - lowLimit) / (highLimit - lowLimit);
        stats.SetScrollSpeed(percentHeight);
    }
}
