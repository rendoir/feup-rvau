using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockdownMinigame : MonoBehaviour
{
    public LevelManager LevelManager;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.RegisterLevelCompletionHandler(LevelCompletionHandler);
    }

    private void LevelCompletionHandler(LevelManager levelManager)
    {
        levelManager.advanceLevel();
    }
}
