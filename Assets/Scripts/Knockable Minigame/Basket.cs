using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Basket : MonoBehaviour
{
    public TextMeshPro UsableBallScoreboard = null;

    public GameObject BallPrefab;

    public float DelayBetweenBallSpawn = 1.5f;

    public int BallsToSpawn = 5;

    public float XSpawnOffset = 1.0f;
    public float ZSpawnOffset = 1.0f;

    private int UsableBalls = 0;

    private List<GameObject> Balls = new List<GameObject>();

    public delegate void OnBallDepletionDelegate(Basket basket);
    private OnBallDepletionDelegate DepletionHandler = null;

    void Start()
    {

        SpawnBalls();
    }

    void SpawnBalls()
    {
        UsableBalls = BallsToSpawn;
        this.UpdateText();
        for(int i=0;i<BallsToSpawn;++i)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        Vector3 offset = new Vector3(0,0.5f,0);

        float xoffset = Random.Range( -XSpawnOffset, XSpawnOffset);
        float zoffset = Random.Range( -ZSpawnOffset, ZSpawnOffset);
        offset.x = xoffset;
        offset.z = zoffset;

        GameObject ball = GameObject.Instantiate(BallPrefab,this.transform.position + offset,this.transform.rotation, transform);
        ball.GetComponent<ThrowingBall>().RegisterOnNotUsableListener(OnBallNotUsableHandler);
        Balls.Add(ball);
    }

    public void Reset()
    {
        foreach(var ball in Balls)
        {
            Destroy(ball);
        }
        Balls.Clear();
        SpawnBalls();
    }

    private void UpdateText()
    {
        this.UsableBallScoreboard.text = ""+this.UsableBalls+"/"+BallsToSpawn;
    }

    private void OnBallNotUsableHandler()
    {
        this.UsableBalls--;
        this.UpdateText();
        if(this.UsableBalls == 0)
        {
            this.DepletionHandler(this);
        }
    }

    public void RegisterBallDepletionHandler(OnBallDepletionDelegate handler)
    {
        this.DepletionHandler = handler;
    }

}
