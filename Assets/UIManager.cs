using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManagerDefense gameManager;
    public SoundManager soundManager;

    private Slider volumeSlider;

    void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
            gameManager.TogglePauseMenu();
    }

    public void MusicSliderUpdate(float val)
    {
        soundManager.SetVolume(val);
    }

    public void MusicToggle(bool val)
    {
        volumeSlider.interactable = val;
        soundManager.SetVolume(val ? volumeSlider.value : 0f);
    }
}
