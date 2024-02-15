using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // bound 8

    private readonly float Speed_ = 20;
    private readonly float xBound = 8;

    // ENCAPSULATION
    private float Modifier_;
    public float Modifier {
        get { return Modifier_; }
        set 
        {
            if (value > 2)
            {
                this.Modifier_ = 2;
            }
            else if (value < 0)
            {
                this.Modifier_ = 0;
            }
            else
            {
                this.Modifier_ = value;
            }
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        Modifier = 1;
    }

    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(HorizontalInput * Modifier_ * Speed_ * Time.deltaTime * Vector3.left);

        if(transform.position.x > xBound || transform.position.x < -xBound)
        {
            transform.position = new(transform.position.x > xBound ? xBound : -xBound, transform.position.y, transform.position.z);
        }
    }
}
