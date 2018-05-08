using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    CameraSwitch cameraSwitch;
    TimerScript timerScript;

    private void Start()
    {
        cameraSwitch = GetComponent<CameraSwitch>();
        timerScript = GetComponent<TimerScript>();
    }

    public void Skip()
    {
        if (cameraSwitch != null && timerScript != null)
        {
            cameraSwitch.ChangeView();
            timerScript.StartCountUp();
        }
    }

    public void LoadScene(string wool)
    {
        SceneManager.LoadScene(wool);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
