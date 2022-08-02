using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ui_manager : MonoBehaviour
{
    public Canvas menu;
    public Canvas playUi;
    public Canvas settingUi;
    float currentAlpha = 1;
    float desiredAlpha = 0;
    float currentAlpha2 = 0;
    float desiredAlpha2 = 1;
    bool isTransition;
    public Text highScoreText;

    void Start()
    {

    }

    void Update()
    {
        if (isTransition)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, 2.0f * Time.deltaTime);
            menu.GetComponent<CanvasGroup>().alpha = currentAlpha;
            currentAlpha2 = Mathf.MoveTowards(currentAlpha2, desiredAlpha2, 1.0f * Time.deltaTime);
            playUi.GetComponent<CanvasGroup>().alpha = currentAlpha2;

        }

        if (currentAlpha == desiredAlpha)
        {
            menu.GetComponent<CanvasGroup>().interactable = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().enabled = true;

        }
        if (currentAlpha2 == desiredAlpha2)
        {
            playUi.GetComponent<CanvasGroup>().interactable = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().enabled = true;


        }

        if (currentAlpha == desiredAlpha && currentAlpha2 == desiredAlpha2)
        {
            isTransition = false;
        }
    }

    public void startTransition()
    {
        isTransition = true;
    }

    public void showSettings()
    {
        menu.GetComponent<CanvasGroup>().alpha = 0;
        menu.GetComponent<CanvasGroup>().interactable = false;
        settingUi.gameObject.SetActive(true);
        settingUi.GetComponent<Canvas>().sortingOrder = 0;
        /*settingUi.GetComponent<CanvasGroup>().alpha = 1;
        settingUi.GetComponent<CanvasGroup>().interactable = true;
        */
    }

    public void showMenu()
    {

        settingUi.gameObject.SetActive(false);
          menu.GetComponent<CanvasGroup>().alpha = 1;
        menu.GetComponent<CanvasGroup>().interactable = true;
    }

    public void Quit(){
        Application.Quit();
    }


}
