using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private HighScoreData highScore;
    public Text hsText;
    public Timer timer;
    public SaveHighScoreToFile saveSystem;

    private void Start()
    {
        saveSystem = GetComponent<SaveHighScoreToFile>();

        timer = new Timer();
        highScore = saveSystem.Load();
        hsText.text = "Highscore: " + highScore.score;
        GameStarted();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) saveSystem.Save(highScore);
        if (Input.GetKeyDown(KeyCode.P)) saveSystem.Save(new HighScoreData());
    }

    public void GameStarted()
    {
        timer.StartTimer();
    }
    public void GameWon()
    {
        float timerScore = timer.StopTimer();
        highScore.SubmitScore(timerScore);
        saveSystem.Save(highScore);
        hsText.text = "Highscore = " + highScore.score;
    }
}
