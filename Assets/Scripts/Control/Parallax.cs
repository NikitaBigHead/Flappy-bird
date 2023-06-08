using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : BaseElement
{
    private GameObject ground;
    private GameObject background;

    private bool work = true;
    private void Start()
    {
        ground = app.model.backgroundModel.ground;
        background = app.model.backgroundModel.background;

        app.view.birdView.OnDie+= stopParallax;

        StartCoroutine(makeParallax());
    }

    IEnumerator makeParallax()
    {
        float endPosX = app.model.backgroundModel.endPosX;
        float startPosXGround = app.model.backgroundModel.startPosXGround;
        float startPosXBackground = app.model.backgroundModel.startPosXBackground;

        while (work)
        {
            ground.transform.Translate(-Vector2.right * app.model.pipeModel.speed * Time.fixedDeltaTime);
            if (ground.transform.position.x <= endPosX) ground.transform.position = new Vector2(startPosXGround, ground.transform.position.y );

            background.transform.Translate(-Vector2.right * (app.model.pipeModel.speed * 
                app.model.backgroundModel.parallaxEffect) * Time.fixedDeltaTime);
            if (background.transform.position.x <= endPosX) background.transform.position = new Vector2(startPosXBackground, background.transform.position.y);

            yield return new WaitForFixedUpdate();
        }

    }
    private void stopParallax()
    {
        work = false;
    }
}
