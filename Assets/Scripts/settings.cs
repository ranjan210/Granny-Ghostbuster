using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Slider slider;
    public UnityAndroidVibrator ubv;
    public Button vibButton;
    public Sprite on;
    public Sprite off;

void Awake(){
        if(PlayerPrefs.GetInt("vibration",0)==1)
        {
            vibButton.GetComponent<Image>().sprite = on;
        }
        else
        {
            vibButton.GetComponent<Image>().sprite = off;

        }
}
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVolume()
    {
        AudioListener.volume = slider.normalizedValue;
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }

    public void changeVibration()
    {
        bool res = ubv.switchVibration();
        int boolInt = res ? 1 : 0;
        PlayerPrefs.SetInt("vibration", boolInt);
        if (res)
        {
            vibButton.GetComponent<Image>().sprite = on;
        }
        else
        {
            vibButton.GetComponent<Image>().sprite = off;

        }

    }

}
