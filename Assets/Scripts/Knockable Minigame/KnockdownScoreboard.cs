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

    void Start()
    {
        SetBallsCounterText();
        SetCansCounterText();
        HideAllObjects();
    }

    private void SetCansCounterText()
    {
        string text = "Cans:\n" + currentCans + "/" + totalCans;
        cansCounter.text = text;
    }

    private void SetBallsCounterText()
    {
        string text = "Balls:\n" + currentBalls + "/" + totalBalls;
        ballsCounter.text = text;
    }

    private void HideAllObjects()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    private void ShowStartState()
    {
        StartStateObject.gameObject.SetActive(true);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    private void ShowNormalStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(true);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    private void ShowLossStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(true);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(false);
    }

    private void ShowAdvancementStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(true);
        WinStateObject.gameObject.SetActive(false);
    }

    private void ShowWinStateObject()
    {
        StartStateObject.gameObject.SetActive(false);
        NormalStateObject.gameObject.SetActive(false);
        LossStateObject.gameObject.SetActive(false);
        AdvacementStateObject.gameObject.SetActive(false);
        WinStateObject.gameObject.SetActive(true);
    }

    private void ResetGame()
    {

    }

    private void AdvanceLevel()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) this.ShowStartState();
        if(Input.GetKeyDown(KeyCode.X)) this.ShowNormalStateObject();
        if(Input.GetKeyDown(KeyCode.C)) this.ShowLossStateObject();
        if(Input.GetKeyDown(KeyCode.V)) this.ShowAdvancementStateObject();
        if(Input.GetKeyDown(KeyCode.B)) this.ShowWinStateObject();
    }

}
