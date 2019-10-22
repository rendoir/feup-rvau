using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Basket : MonoBehaviour
{
    public TextMeshPro UsableBallScoreboard = null;
    public GameObject BallPrefab;
    public int BallsToSpawn = 5;
    public float SpawnRadius = 2f;
    public float YSpawnOffset = 1.5f;

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

        float angleDelta = 360.0f / this.BallsToSpawn;
        float currentAngle = 0f;
        float currentYOffset = this.YSpawnOffset;

        for (int i = 0; i < BallsToSpawn; ++i)
        {
            float spawnX = Mathf.Sin(currentAngle * Mathf.PI/180.0f) * this.SpawnRadius;
            float spawnZ = Mathf.Cos(currentAngle * Mathf.PI/180.0f) * this.SpawnRadius;
            Vector3 offset = new Vector3(spawnX,currentYOffset,spawnZ);

            GameObject ball = GameObject.Instantiate(BallPrefab, this.transform.position + offset, this.transform.rotation, transform);
            ball.GetComponent<ThrowingBall>().RegisterOnNotUsableListener(OnBallNotUsableHandler);
            Balls.Add(ball);

            currentAngle += angleDelta;
            currentYOffset += this.YSpawnOffset;
        }
    }

    public void Reset()
    {
        foreach (var ball in Balls)
        {
            Destroy(ball);
        }
        Balls.Clear();
        SpawnBalls();
    }

    private void UpdateText()
    {
        this.UsableBallScoreboard.text = "" + this.UsableBalls + "/" + BallsToSpawn;
    }

    private void OnBallNotUsableHandler()
    {
        this.UsableBalls--;
        this.UpdateText();
        if (this.UsableBalls == 0)
        {
            this.DepletionHandler(this);
        }
    }

    public void RegisterBallDepletionHandler(OnBallDepletionDelegate handler)
    {
        this.DepletionHandler = handler;
    }

}
