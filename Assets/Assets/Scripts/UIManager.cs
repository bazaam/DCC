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
        soundManager.SetMasterVolume(val);
    }

    public void MusicToggle(bool val)
    {
        Debug.Log("Toggle state = ");
        Debug.Log(val);
        volumeSlider.interactable = val;
        soundManager.SetMasterVolume(val ? volumeSlider.value : 0f);
    }
}
