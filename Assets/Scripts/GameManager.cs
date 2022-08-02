using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public Text highScoreText;
    public Text currentScore;
    public Slider slider;

    public Button[] button;

    public Image GameOver;
    bool gameOver;
    Scene scene;
    public int score = 0;

    void Awake()
    {
        Debug.Log(PlayerPrefs.GetFloat("Volume",1));
        AudioListener.volume = PlayerPrefs.GetFloat("Volume",1);
        slider.value = AudioListener.volume * 100;

    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void updateScore(int change)
    {
        if (gameOver)
        {
            return;
        }
        score += change;
        scoretext.text = "SCORE : " + score;
    }

    public void game_Over()
    {
        gameOver = true;
        GameOver.gameObject.SetActive(true);
        HideButtons();
        highScoreText.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highscore");
        if (PlayerPrefs.GetInt("highscore") < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        currentScore.text = "YOUR SCORE : " + score;
    
    }


    public void HideButtons(){
        foreach(Button b in button){
            b.gameObject.SetActive(false);
        }
    }

    public void reload_Level()
    {
        SceneManager.LoadScene(scene.name);
    }

    public void load_menu() { }

}
