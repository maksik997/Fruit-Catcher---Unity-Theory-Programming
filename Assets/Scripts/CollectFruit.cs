using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : Collectable
{
    [SerializeField]
    private int Score, Time;

    [SerializeField]
    private GameObject ParticleSystemPrefab;

    // INHERITANCE
    protected override void Init()
    {
        ScoreValue = Score;
        TimeValue = Time;
        ParticleSystem = ParticleSystemPrefab;
    }

    // POLYMORPHISM
    protected override void HandlePositive()
    {
        //Debug.Log($"Add score: {base.ScoreValue}");
        base.GameManager.AddScore(base.ScoreValue);
    }

    protected override void HandleNegative()
    {
        //Debug.Log($"Deduct time: {base.TimeValue}");
        base.GameManager.AddTime(base.TimeValue);
    }
}
