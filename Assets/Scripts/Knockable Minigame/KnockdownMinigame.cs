using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockdownMinigame : MiniGame
{
    public LevelManager LevelManager;
    public Basket BallBasket;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.RegisterLevelCompletionHandler(LevelCompletionHandler);
        BallBasket.RegisterBallDepletionHandler(BasketDepletionHandler);
    }

    private void LevelCompletionHandler(LevelManager levelManager)
    {
        levelManager.advanceLevel();
    }

    private void BasketDepletionHandler(Basket basket)
    {
        Debug.Log("Balls Depleted");
    }

    public override void OnPlayerExited()
    {
        base.OnPlayerExited();
        BallBasket.Reset();
        LevelManager.Reset();
    }
}
