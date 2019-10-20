using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshPro scoreboard = null;
    public Basket ballBaket = null;

    public GameObject[] Levels;
    public int currentLevel = 0;
    private GameObject currentGameObject = null;

    private int KnockedDownCans = 0;
    private int TotalNumberOfCans = 0;

    public delegate void LevelCompletionDelegate(LevelManager levelManager);
    private LevelCompletionDelegate LevelCompletionHandler = null;

    private void Start()
    {
        this.SpawnCurrentLevel();
    }

    private void SpawnCurrentLevel()
    {
        this.KnockedDownCans = 0;
        this.currentGameObject = GameObject.Instantiate(Levels[currentLevel],this.transform);
        Knockable[] cans = this.currentGameObject.GetComponentsInChildren<Knockable>();
        TotalNumberOfCans = cans.Length;
        foreach (Knockable can in cans)
        {
            can.RegisterDelegate(OnDeathHandler);
        }
        this.UpdateText();
    }

    private void ClearCurrentLevel()
    {
        if (currentGameObject != null)
        {
            Destroy(currentGameObject);
            currentGameObject = null;
        }
    }

    public void advanceLevel()
    {
        ClearCurrentLevel();
        this.currentLevel++;
        if (this.currentLevel < Levels.Length)
        {
            SpawnCurrentLevel();
            if (this.ballBaket != null)
            {
                ballBaket.Reset();
            }
        }
    }

    private void OnDeathHandler()
    {
        this.KnockedDownCans++;
        this.UpdateText();
        if (this.KnockedDownCans == this.TotalNumberOfCans && this.LevelCompletionHandler != null)
        {
            this.LevelCompletionHandler(this);
        }
    }

    private void UpdateText()
    {
        this.scoreboard.text = "" + this.KnockedDownCans + "/" + this.TotalNumberOfCans;
    }

    public void RegisterLevelCompletionHandler(LevelCompletionDelegate handler)
    {
        this.LevelCompletionHandler = handler;
    }

    public void Reset()
    {
        Destroy(this.currentGameObject);
        this.currentLevel = 0;
        this.SpawnCurrentLevel();
    }

}
