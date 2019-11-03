using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnockdownScoreboard : MonoBehaviour
{
    public KnockdownMinigame Minigame;

    public GameObject StartStateObject;
    public GameObject NormalStateObject;
    public GameObject LossStateObject;
    public GameObject AdvacementStateObject;
    public GameObject WinStateObject;

    public TextMeshPro cansCounter;
    public TextMeshPro ballsCounter;

    private int currentBalls = 0;
    private int totalBalls = 0;
    private int currentCans = 0;
    private int totalCans = 0;

    public float TimeBetweenSoundBeeps = 1.0f;

    private AudioSource beepSound;
    private Coroutine soundPlayRoutine = null;

    void Start()
    {
        beepSound = GetComponent<AudioSource>();
        SetBallsCounterText();
        SetCansCounterText();
        HideAllObjects();
    }

    public void StartPlayingSound()
    {
        if (soundPlayRoutine == null)
        {
            soundPlayRoutine = StartCoroutine("Sound");
        }
    }

    public void StopPlayingSound()
    {
        if (soundPlayRoutine != null)
        {
            StopCoroutine(soundPlayRoutine);
            soundPlayRoutine = null;
        }
    }

    IEnumerator Sound()
    {
        while (true)
        {
            beepSound.Play();
            yield return new WaitForSecondsRealtime(TimeBetweenSoundBeeps);
        }
    }

    public void SetCanCount(int current,int total)
    {
        this.currentCans = current;
        this.totalCans = total;
        this.SetCansCounterText();
    }

    public void SetBallCount(int current,int total)
    {
        this.currentBalls = current;
        this.totalBalls = total;
        this.SetBallsCounterText();
    }

    private void SetCansCounterText()
    {
        string text = "CANS: " + currentCans + "/" + totalCans;
        cansCounter.text = text;
    }

    private void SetBallsCounterText()
    {
        string text = "BALLS: " + currentBalls + "/" + totalBalls;
        ballsCounter.text = text;
    }

    public void HideAllObjects()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    public void ShowStartState()
    {
        StartStateObject.gameObject.SetActive(true);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    public void ShowNormalStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(true);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    public void ShowLossStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(true);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    public void ShowAdvancementStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(true);
        WinStateObject.gameObject.SetActive(false);
    }

    public void ShowWinStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(true);
    }

    /*
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) this.ShowStartState();
        if(Input.GetKeyDown(KeyCode.X)) this.ShowNormalStateObject();
        if(Input.GetKeyDown(KeyCode.C)) this.ShowLossStateObject();
        if(Input.GetKeyDown(KeyCode.V)) this.ShowAdvancementStateObject();
        if(Input.GetKeyDown(KeyCode.B)) this.ShowWinStateObject();
    }
    */
}
