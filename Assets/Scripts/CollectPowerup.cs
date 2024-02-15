using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerup : Collectable
{
    [SerializeField]
    private GameObject ParticleSystemPrefab;
    [SerializeField]
    private int Multiplier;

    // INHERITANCE
    protected override void Init()
    {
        ScoreValue = 0;
        TimeValue = 0;
        ParticleSystem = ParticleSystemPrefab;
    }

    // POLYMORPHISM
    protected override void HandlePositive()
    {
        Debug.Log("Unlock special action");
        base.GameManager.MultiplyScore(Multiplier);
    }
}
