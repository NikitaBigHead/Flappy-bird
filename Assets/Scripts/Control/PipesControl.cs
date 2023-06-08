using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static BirdView;
using Random = UnityEngine.Random;

public class PipesControl : BaseElement
{
    private float speed;
    private float holeHeight;

    private GameObject pipeUp;
    private GameObject pipeDown;

    private AudioSource audioSource;

    void Start()
    {
        app.view.birdView.OnDie+= stopPipes;

        speed = app.model.pipeModel.speed;
        holeHeight = app.model.pipeModel.holeHeight;
        audioSource = app.model.audioModel.audioSource;

        pipeUp = gameObject.transform.Find("PipeUp").gameObject;
        pipeDown = gameObject.transform.Find("PipeDown").gameObject;

        HeightChange();
        ExpandHole();
    }

    void ExpandHole()
    {
        pipeDown.transform.position = new Vector2(pipeDown.transform.position.x,
            pipeUp.transform.position.y - holeHeight) ;
    }
    void HeightChange()
    {
        float startPos = app.model.pipeModel.posStartYUp;
        float minHeight = app.model.pipeModel.minHeightPipe;
        float maxHeight = app.model.pipeModel.maxHeightPipe;

        pipeUp.transform.position = new Vector3(pipeUp.transform.position.x,
            startPos - Random.Range(minHeight,maxHeight));
    }
    void FixedUpdate()
    {

        transform.Translate(-Vector2.right * speed* Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            audioSource.PlayOneShot(app.model.audioModel.point);

            app.model.scoreModel.score++;
            app.model.scoreModel.scoreText.text = Convert.ToString(app.model.scoreModel.score);
        }
    }

    private void stopPipes()
    {
        speed = 0.0f;
    }
}
