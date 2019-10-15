using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;

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
    public TextMeshPro playTip;

    public GameObject hand;
    public GameObject bulletPrefab;
    public SteamVR_Action_Boolean triggerAction;

    private ShootTarget[] targets;

    void Start()
    {
        // TODO - Remove this
        isPlayerInside = true;

        FindTargets();
        Restart();

        triggerAction.AddOnStateDownListener(Shoot, SteamVR_Input_Sources.Any);
    }

    public void Update()
    {
        if(!isPlayerInside) {
            return;
        }

        if(!isPlayerPlaying) {
            return;
        }

        if(isGameOver) {
            return;
        }

        // Update timer
        time -= Time.deltaTime;
        time = Mathf.Max(time, 0);

        UpdateInterface();

        // Check game over condition
        if(time <= 0 || hits >= targets.Length || bullets <= 0) {
            OnGameOver();
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
        isGameOver = false;
    }

    public void OnTargetHit()
    {
        hits++;
    }

    void FindTargets() {
        targets = GetComponentsInChildren<ShootTarget>();
    }

    public void Shoot(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
    {
        // TODO - Check if player is holding the weapon
        if(!isPlayerInside || !isPlayerPlaying)
            return;

        // TODO - Check if trigger was pressed on the hand with the gun (use sources.Equals)

        GameObject bullet = Instantiate(bulletPrefab, hand.transform.position, hand.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(Bullet.force * hand.transform.forward);
        bullets--;
    }

    public void OnButtonPressed() {
        Restart();
        isPlayerPlaying = true;
        DisplayInterface(true);
        DisplayTip(false);
        UpdateInterface();
    }

    public void OnGameOver() {
        isGameOver = true;
        isPlayerPlaying = false;
        DisplayInterface(false);
        DisplayTip(true);
    }

    public void DisplayInterface(bool shouldDisplay) {
        timerText.gameObject.SetActive(shouldDisplay);
        scoreText.gameObject.SetActive(shouldDisplay);
        bulletsText.gameObject.SetActive(shouldDisplay);
    }

    public void DisplayTip(bool shouldDisplay) {
        playTip.gameObject.SetActive(shouldDisplay);
    }

    public void UpdateInterface() {
        // Update timer text
        timerText.text = ((int) time).ToString();

        // Update bullets text
        bulletsText.text = bullets.ToString();

        // Update score text
        scoreText.text = hits.ToString();
    }

}
