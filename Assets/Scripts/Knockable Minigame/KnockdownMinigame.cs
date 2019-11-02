using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockdownMinigame : MiniGame
{
    public LevelManager LevelManager;
    public Basket BallBasket;
    public KnockdownScoreboard Scoreboard;

    private int CurrentState = 0;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.RegisterLevelCompletionHandler(LevelCompletionHandler);
        BallBasket.RegisterBallDepletionHandler(BasketDepletionHandler);
        this.CurrentState = 0;
        Scoreboard.ShowStartState();
        Scoreboard.StartPlayingSound();
    }

    private void LevelCompletionHandler(LevelManager levelManager)
    {
        if (LevelManager.currentLevel == (LevelManager.Levels.Length - 1))
        {
            // won game state
            this.CurrentState = 4;
            this.Scoreboard.ShowWinStateObject();
            Scoreboard.StartPlayingSound();
        }
        else
        {
            // advance level state
            this.CurrentState = 3;
            this.Scoreboard.ShowAdvancementStateObject();
            Scoreboard.StartPlayingSound();
        }
    }

    private void BasketDepletionHandler(Basket basket)
    {
        // Set The State To The Loss State If We Are Supposed To
        if (!LevelManager.WasLevelCompleted())
        {
            this.CurrentState = 2;
            this.Scoreboard.ShowLossStateObject();
            Scoreboard.StartPlayingSound();
        }
    }

    public override void OnPlayerExited()
    {
        base.OnPlayerExited();
        BallBasket.Clear();
        LevelManager.ClearCurrentLevel();
        // set state to 0
        this.CurrentState = 0;
        Scoreboard.ShowStartState();
        Scoreboard.StopPlayingSound();
    }

    public override void OnPlayerEntered()
    {
        base.OnPlayerEntered();
        // set state to 0
        this.CurrentState = 0;
        Scoreboard.ShowStartState();
        Scoreboard.StartPlayingSound();
    }

    public void GazeHandler()
    {
        Scoreboard.StopPlayingSound();
        switch (CurrentState)
        {
            case 0://start game state - start/reset game
                {
                    this.LevelManager.Reset();
                    this.BallBasket.Reset();
                    this.CurrentState = 1;
                    this.Scoreboard.ShowNormalStateObject();
                    break;
                }
            case 1:// normal game state do nothing in this case
                {
                    break;
                }
            case 2:// loss game state - reset game
                {
                    this.LevelManager.Reset();
                    this.BallBasket.Reset();
                    this.CurrentState = 1;
                    this.Scoreboard.ShowNormalStateObject();
                    break;
                }
            case 3:// level advancement game state - advance level and go into normal state
                {
                    this.BallBasket.Reset();
                    this.LevelManager.advanceLevel();
                    this.CurrentState = 1;
                    this.Scoreboard.ShowNormalStateObject();
                    break;
                }
            case 4:// victory game state - reset game
                {
                    this.LevelManager.Reset();
                    this.BallBasket.Reset();
                    this.CurrentState = 1;
                    this.Scoreboard.ShowNormalStateObject();
                    break;
                }
            default: break;
        }
    }

}
