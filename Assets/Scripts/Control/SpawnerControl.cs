using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : BaseElement
{

    private GameObject pipes;
    private bool work = true;
    void Start()
    {
        app.view.birdView.OnDie += stopSpawner;

        pipes = app.model.pipeModel.pipes;
        StartCoroutine(spawner());

    }

    private IEnumerator spawner()
    {
        while (work)
        {
            Instantiate(pipes, gameObject.transform.position ,Quaternion.identity);
            yield return new WaitForSeconds(app.model.pipeModel.timeSpawn);
        }


    } 
    
    private  void stopSpawner()
    {
        work = false;
    }
}
