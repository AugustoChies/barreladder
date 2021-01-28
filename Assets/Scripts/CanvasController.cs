using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject endPanel;
    public List<Image> stars;
    public GlobalStats stats;
    public TextMeshProUGUI pointtext,multipliertxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        pointtext.text = ""+ (int)stats.currentScore;
        multipliertxt.text = "x" + stats.scorevariation.ToString("F1");

    }

    public void Finish()
    {
        endPanel.SetActive(true);
        stars[0].enabled = true;
        if(stats.currentScore > stats.scoreBarrier.x)
        {
            stars[1].enabled = true;
        }
        if (stats.currentScore > stats.scoreBarrier.y)
        {
            stars[2].enabled = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage");
    }


}
