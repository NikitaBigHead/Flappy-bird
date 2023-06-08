using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class _GameManager: BaseElement
{
    private void Start()
    {
        init();

        app.view.birdView.OnDie += openFallMenu;
    }
    private void init()
    {
        app.model.scoreModel.bestScore = PlayerPrefs.GetInt("BestScore");
        app.model.audioModel.audioSource.volume = PlayerPrefs.GetFloat("SoundVolume");

        float level = PlayerPrefs.GetFloat("Level");
        Debug.Log("level is " + 
            level);
        if(level < 0.3f)
        {
            Debug.Log("level is 1");
            setLevelData(app.model.gameManagerModel.level1);
            Debug.Log(Time.timeScale);
        }
        else if (level <0.77f)
        {
            Debug.Log("level is 2");
            setLevelData(app.model.gameManagerModel.level2);
            Debug.Log(Time.timeScale);
        }
        else if(level <= 1)
        {
            Debug.Log("level is 3");
            setLevelData(app.model.gameManagerModel.level3);
            Debug.Log(Time.timeScale);
        }
    }

    private void setLevelData(LevelInfo level)
    {

        app.model.pipeModel.speed = level.speed;
        app.model.pipeModel.holeHeight = level.holeHeight;
        app.model.pipeModel.timeSpawn = level.timeSpawn;

        Debug.Log("__________set__________");
        Debug.Log("speed is " + app.model.pipeModel.speed);
        Debug.Log("holeHeight is " + app.model.pipeModel.holeHeight);
        Debug.Log("timeSpawn is " + app.model.pipeModel.timeSpawn);

    }
    private void openFallMenu()
    {
        if(app.model.scoreModel.score > app.model.scoreModel.bestScore)
        {
            app.model.scoreModel.bestScore = app.model.scoreModel.score;
            PlayerPrefs.SetInt("BestScore", app.model.scoreModel.bestScore);
        }

        Invoke("_openFallMenu", 0.75f);
    }
    private void _openFallMenu()
    {
        app.view.UIView.openFallMenu();

        app.model.scoreModel.scoreTextFallMenu.text = Convert.ToString( app.model.scoreModel.score);
        app.model.scoreModel.bestScoreTextFallMenu.text = Convert.ToString(app.model.scoreModel.bestScore);

    }
}
