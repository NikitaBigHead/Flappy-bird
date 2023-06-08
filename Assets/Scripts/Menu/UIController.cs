using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip smoosh;

    public Scrollbar scrollbarLevel;
    public Scrollbar scrollbarVolumeSound;

    public GameObject menu;
    public GameObject settings;

    private void Start()
    {
        scrollbarLevel.value = PlayerPrefs.GetFloat("Level");
        scrollbarVolumeSound.value = PlayerPrefs.GetFloat("SoundVolume");

        audioSource.volume = scrollbarVolumeSound.value;
    }
    private void sound()
    {
        audioSource.PlayOneShot(smoosh);
    }
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void openSettings()
    {
        sound();
        menu.SetActive(false);
        settings.SetActive(true);
    }
    public void openMenu()
    {
        sound();
        SceneManager.LoadScene("Menu");
     }

    public void onLevelChanged()
    {
        PlayerPrefs.SetFloat("Level", scrollbarLevel.value);
    }

    public void onVolumeChanged()
    {
        PlayerPrefs.SetFloat("SoundVolume", scrollbarVolumeSound.value);
        audioSource.volume = scrollbarVolumeSound.value;
    }
    
}
