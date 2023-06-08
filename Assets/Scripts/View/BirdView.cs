using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdView : BaseElement
{

    public delegate void Fly();
    public event Fly OnFly;

    public delegate void Die();
    public event Die OnDie;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && app.model.birdModel.isAlive)
        {
            OnFly?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        OnDie?.Invoke();
    }


}
