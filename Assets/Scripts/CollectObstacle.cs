using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObstacle : Collectable
{
    [SerializeField]
    private int Score;

    [SerializeField]
    private GameObject ParticleSystemPrefab;

    // INHERITANCE
    protected override void Init()
    {
        ScoreValue = Score;
        TimeValue = 0;
        ParticleSystem = ParticleSystemPrefab;
    }

    // POLYMORPHISM
    protected override void HandlePositive()
    {
        //Debug.Log($"Add score: {base.ScoreValue}");
        base.GameManager.AddScore(base.ScoreValue);
    }
}
