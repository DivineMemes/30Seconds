using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedScript : MonoBehaviour
{
    public Canvas gameCanvas;
    public Canvas winCanvas;
    public TimerScript timer;
    public Text scoreText;
    public LeaderBoard leaderBoard;
    public Camera topDown;
    public FPSController fps;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            gameCanvas.gameObject.SetActive(false);
            winCanvas.gameObject.SetActive(true);
            scoreText.text = timer.timer.ToString();
            timer.StopAllCoroutines();
            leaderBoard.Load();
            topDown.gameObject.SetActive(true);
            
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
