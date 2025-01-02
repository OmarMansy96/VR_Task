using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModes : MonoBehaviour
{
    public enum Mode { Timed, Endless }
    public Mode currentMode;

    public float timedDuration = 60f;
    public TextMeshProUGUI timerText, gameMode;

    private float timer;
    public static bool isGameRunning = false;

    void Start()
    {
        //if (currentMode == Mode.Timed)
        //{
        //    timer = timedDuration;
        //}
        //StartGame();
    }

    void Update()
    {
        if (isGameRunning && currentMode == Mode.Timed)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();

            if (timer <= 0)
            {
                EndGame();
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer);
        }
    }

    public void StartTimeMode()
    {
        currentMode = Mode.Timed;
        timer = timedDuration;
        isGameRunning = true;
        gameMode.text = $"Mode: Timed ";
    }
    public void StopTimeMode()
    {
        currentMode = Mode.Endless;
        isGameRunning = true;
        timerText.text = " ";
        gameMode.text = $"Mode: Endless ";

    }

    public void EndGame()
    {
        isGameRunning = false;
        Debug.Log("Game Over!");
        timerText.text = "Game Over";

        // Additional end-game logic (e.g., show final score, restart option)
    }
}
