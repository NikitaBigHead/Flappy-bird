using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdModel : BaseElement
{
    public float jumpForce = 5f;
    public  Rigidbody2D rb;
    public bool isAlive = true;
    public Animator animator;
    void Awake()
    {
        rb = app.view.birdView.gameObject.GetComponent<Rigidbody2D>();
    }
}
