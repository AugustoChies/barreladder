using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject endPanel, drunkPanel, notPanel;
    public List<Image> stars;
    public GlobalStats stats;
    public TextMeshProUGUI pointtext,multipliertxt;
    public Image drunkBar;
    bool lost;

    private void Update()
    {
        if (lost) return;

        pointtext.text = ""+ (int)stats.currentScore;
        multipliertxt.text = "x" + stats.scorevariation.ToString("F1");
        drunkBar.fillAmount = stats.drunkness / 100.0f;
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

    public void Drunk()
    {
        lost = true;
        drunkPanel.SetActive(true);
    }

    public void NotDrunk()
    {
        lost = true;
        notPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage");
    }


}
