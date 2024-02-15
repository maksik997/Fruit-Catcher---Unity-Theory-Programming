using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    // ENCAPSULATION
    protected GameManager GameManager { get; private set; }
    protected GameObject ParticleSystem { private get; set; }
    public int ScoreValue { get; protected set; }
    public int TimeValue { get; protected set; }


    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Init();
    }

    // ABSTRACTION
    protected abstract void Init();

    protected virtual void HandlePositive()
    {
        // Perform action when collided with Basket
        // Default => do nothing
    }

    protected virtual void HandleNegative()
    {
        // Perform action when collided with BottomBound
        // Default => do nothing
    }

    private void OnTriggerEnter(Collider other)
    {
        // POLYMORPHISM
        if (other.CompareTag("Basket"))
        {
            HandlePositive();
            Instantiate(ParticleSystem, transform.position, ParticleSystem.transform.rotation);
        }
        else
            HandleNegative();

        // On collision hide object and do something
        gameObject.SetActive(false);

        // Stop this object, to avoid making it drop at unreasonable speed
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
