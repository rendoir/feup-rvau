using UnityEngine;
using TMPro;
using Valve.VR;
using Valve.VR.InteractionSystem;

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

    private Hand hand;
    private Holdable gun = null;
    public GameObject gunPrefab;
    public GameObject bulletPrefab;
    public SteamVR_Action_Boolean triggerAction;

    public bool isGunAttached;
    public float bulletForwardOffset = 0f;

    private ShootTarget[] targets;

    void Start()
    {
        isGunAttached = false;

        FindTargets();
        Restart();
        ResetGun();

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

        /*
        // Workaround for editor testing
        if(isGunAttached) {
            GrabTypes startingGrabType = hand.GetGrabEnding();
            
            if (startingGrabType != GrabTypes.None) {
                Shoot(null, SteamVR_Input_Sources.Any);
            }
        }
        */

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
        ResetGun();
        Restart();
        DisplayInterface(false);
        DisplayTip(true);
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
        if(!isPlayerInside || !isPlayerPlaying || !isGunAttached)
            return;

        // Check if action source matches the hand with the gun
        if(hand.handType != sources)
            return; 

        gun.GetComponent<Gun>().OnShoot();

        GameObject bullet = Instantiate(bulletPrefab, hand.transform.position + hand.transform.forward * bulletForwardOffset, hand.transform.rotation);
        bullet.transform.Rotate(90f, 0f, 0f);
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

    public void OnGunAttached(Hand hand, Holdable gun) {
        isGunAttached = true;
        this.hand = hand;
    }

    public void ResetGun() {
        if(isGunAttached || gun == null) {
            GameObject newGun = Instantiate(gunPrefab, transform);

            if(gun != null) {
                isGunAttached = false;
                gun.DetachFromHand(hand);
                gun.enabled = false;
                Destroy(gun.gameObject, 1.5f);
            }
            
            gun = newGun.GetComponent<Holdable>();
            gun.onAttachToHand.AddListener(OnGunAttached);
        }
    }

}
