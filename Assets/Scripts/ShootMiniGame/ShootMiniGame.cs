using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootMiniGame : MiniGame
{
    public int MAX_BULLETS = 20;
    public int MAX_TIME = 10;

    public int bullets;
    public float time;
    public int hits;

    public TextMeshPro timerText;
    public TextMeshPro bulletsText;
    public TextMeshPro scoreText;

    private ShootTarget[] targets;

    void Start()
    {
        // TODO - Remove this
        isPlayerInside = true;
        isPlayerPlaying = true;

        FindTargets();
        Restart();
    }

    public void Update()
    {
        if(!isPlayerInside) {
            return;
        }

        if(!isPlayerPlaying) {
            // TODO - Check start input and call Restart
            return;
        }

        if(isGameOver) {
            return;
        }

        // Update timer
        time -= Time.deltaTime;
        timerText.text = ((int) time).ToString();

        // Update bullets
        // TODO - Check input and launch bullets
        bulletsText.text = bullets.ToString();

        // Update score
        scoreText.text = hits.ToString();

        // Check game over condition
        if(time <= 0 || hits >= targets.Length || bullets <= 0) {
            isGameOver = true;
        }
    }

    public override void OnPlayerEntered()
    {
        base.OnPlayerEntered();
    }

    public override void OnPlayerExited()
    {
        base.OnPlayerExited();
    }

    public void Restart()
    {
        foreach (ShootTarget target in targets)
                target.Restart();

        bullets = MAX_BULLETS;
        time = MAX_TIME;
        hits = 0;
    }

    public void OnTargetHit()
    {
        hits++;
    }

    void FindTargets() {
        targets = GetComponentsInChildren<ShootTarget>();
    } 
}
