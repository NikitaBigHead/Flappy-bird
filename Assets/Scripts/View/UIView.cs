using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIView : BaseElement
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = app.model.audioModel.audioSource;
    }
    private void sound()
    {
        audioSource.PlayOneShot(app.model.audioModel.smoosh);
    }
    public void openPauseMenu()
    {
        sound();
        Time.timeScale = 0f;
        app.model.uIModel.pauseMenu.SetActive(true);
    }
    public void closePauseMenu() {
        Time.timeScale = 1f;
        app.model.uIModel.pauseMenu.SetActive(false);
    }

    public void openFallMenu()
    {
        sound();
        app.model.uIModel.fallMenu.SetActive(true);
    }
    public void restartGame()
    {
        sound();
        Invoke("_restartGame", app.model.audioModel.smoosh.length - 1.2f);
        
    }
    private void _restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void openMenu()
    {
        sound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


}

