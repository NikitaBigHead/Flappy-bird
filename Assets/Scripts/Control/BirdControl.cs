using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : BaseElement
{
    private Rigidbody2D rb;
    private float jumpForce;
    private AudioSource audioSource;
    private Animator animator;
    void Start()
    {
        rb = app.model.birdModel.rb;
        jumpForce = app.model.birdModel.jumpForce;
        audioSource = app.model.audioModel.audioSource;
        animator = app.model.birdModel.animator;

        app.view.birdView.OnFly += fly;
        app.view.birdView.OnDie += die;
    }

    private void fly()
    {
        audioSource.PlayOneShot(app.model.audioModel.wing);
        rb.velocity = Vector2.up * jumpForce;
    }
    private void die()
    {
        if (app.model.birdModel.isAlive)
        {
            audioSource.PlayOneShot(app.model.audioModel.hit);
            audioSource.PlayOneShot(app.model.audioModel.die);

            animator.Play("Died");
            app.model.birdModel.isAlive = false;

        }
    }
}
