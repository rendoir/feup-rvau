using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public GameObject ScoreDisplay;
    public string BaseText = "Score:";

    private TextMesh TextRenderer;

    private long CurrentScore = 0;

    void Start()
    {
        this.TextRenderer = ScoreDisplay.GetComponent<TextMesh>();
        this.SetScoreText();
    }

    private void SetScoreText()
    {
        this.TextRenderer.text = BaseText + " " + this.CurrentScore;
    }

    public void IncreaseScore(long delta = 1)
    {
        this.CurrentScore += delta;
        this.SetScoreText();
    }

    public void DecreaseScore(long delta=1)
    {
        this.CurrentScore -= delta;
        this.SetScoreText();
    }

    public long GetCurrentScore()
    {
        return this.CurrentScore;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            this.IncreaseScore();
        }
    }
}
