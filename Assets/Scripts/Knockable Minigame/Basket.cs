using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject BallPrefab;

    public int balls = 5;

    public float XSpawnOffset = 1.0f;
    public float ZSpawnOffset = 1.0f;

    List<GameObject> Balls = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        for(int i=0;i<balls;++i)
        {
            SpawnBall();
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void SpawnBall()
    {
        Vector3 offset = new Vector3(0,1.5f,0);

        float xoffset = Random.Range( -XSpawnOffset, XSpawnOffset);
        float zoffset = Random.Range( -ZSpawnOffset, ZSpawnOffset);
        offset.x = xoffset;
        offset.z = zoffset;

        var ball = GameObject.Instantiate(BallPrefab,this.transform.position + offset,this.transform.rotation);
        Balls.Add(ball);
    }

    public void Reset()
    {
        foreach(var ball in Balls)
        {
            Destroy(ball);
        }
        Balls.Clear();
        StartCoroutine(SpawnBalls());
    }

}
