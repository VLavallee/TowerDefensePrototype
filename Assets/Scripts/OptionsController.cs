using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] float defaultDifficulty = 1f;
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();

        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found.. did you start from splash screen?");
        }
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScreen();
    }

    public void SetDefaults()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        musicPlayer.SetVolume(defaultVolume);
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        PlayerPrefsController.SetDifficulty(defaultDifficulty);
    }
}
