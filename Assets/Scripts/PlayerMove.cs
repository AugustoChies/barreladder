using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public compasso beat;
    public List<Transform> playerPositions;
    private Rigidbody2D rb;
    private int currentPosition;
    private bool move;
    public int highLimit, lowLimit;
    public float speed;
    protected Vector2 vertMmovement;
    public GlobalStats stats;
    public CanvasController canvas;
    public bool stunned,finished;
    public float stunDuration;
    public float stunPointReduction;
    public float alcoolDecreasePS;
    public delegate bool BeatReaction();
    public BeatReaction BeatMovement;
    private float percentHeight;
    bool IFrames;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<CanvasController>();
        BeatMovement += beat.BarFeedBack;
        stats.SetScrollSpeed(0.0f);
        stats.currentScore = 0;
        stats.drunkness = 0;
        rb = GetComponent<Rigidbody2D>();
        vertMmovement = Vector2.zero;
        currentPosition = 3;
        Vector2 newPos = new Vector2(playerPositions[currentPosition].position.x, rb.position.y);
        rb.MovePosition(newPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        vertMmovement.y = 0;
        if (!stunned)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (currentPosition > 0)
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

            if (Input.GetKey(KeyCode.W) && rb.position.y < highLimit)
            {
                vertMmovement.y = 1;
            }
            else if (Input.GetKey(KeyCode.S) && rb.position.y > lowLimit)
            {
                vertMmovement.y = -1;
            }
        }
        if (stats.drunkness >= 100)
        {
            canvas.Drunk();
            stats.scrollSpeed = 0;
            finished = true;
        }
        if (stats.drunkness > 0)
        {
            stats.drunkness -= alcoolDecreasePS * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (finished) return;

        if (move)
        {
            if (BeatMovement())
            {
                move = false;
                Vector2 newPos = new Vector2(playerPositions[currentPosition].position.x, rb.position.y);
                rb.MovePosition(newPos);
            }
            else
            {
                move = false;
                Vector2 newPos = new Vector2(playerPositions[currentPosition].position.x, rb.position.y);
                rb.MovePosition(newPos);
                stats.ChangePointValue(-stunPointReduction);
                StartCoroutine(StunTimer());                
            }
        }
        else
        {
            rb.MovePosition(rb.position + (vertMmovement * speed * Time.deltaTime));
        }

         percentHeight = (rb.position.y - lowLimit) / (highLimit - lowLimit);
        stats.SetScrollSpeed(percentHeight);
        stats.ChangePointValueDeltaTime(percentHeight);
    }

    public void ExternalStun()
    {
        if(!IFrames)
            StartCoroutine(StunTimer());
    }

    public IEnumerator StunTimer()
    {
        stunned = true;
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(stunDuration);
        stunned = false;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        StartCoroutine(IFramesCounter());
    }

    IEnumerator IFramesCounter()
    {
        IFrames = true;
        float spriteBlinkInterval = 0.15f;
        float timer = 0;
        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
        for (float i = 0; i < stunDuration; i+= Time.deltaTime)
        {
            timer += Time.deltaTime;
            if(timer > spriteBlinkInterval)
            {
                rend.enabled = !rend.enabled;
                timer = 0;                
            }
            yield return null;
        }
        IFrames = false;
        rend.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            if (stats.drunkness < 50)
            {
                canvas.NotDrunk();
                stats.scrollSpeed = 0;
                finished = true;
            }
            else
            {
                canvas.Finish();
                stats.scrollSpeed = 0;
                finished = true;
            }            
        }
        else if (collision.CompareTag("Obstacle"))
        {
            if(!IFrames)
                StartCoroutine(StunTimer());
        }
        else if (collision.CompareTag("drink"))
        {
            stats.drunkness += (int)collision.GetComponent<random>().alcool;
        }

        else if(collision.CompareTag("radio"))
        {
            stats.ChangePointValueDeltaTime(percentHeight * collision.GetComponent<random>().alcool);

        }
        else if(collision.CompareTag("disk"))
        {

            stats.ChangePointValue(collision.GetComponent<random>().alcool);

        }


    }
  
}