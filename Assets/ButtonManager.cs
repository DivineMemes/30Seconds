using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public CameraSwitch cameraSwitch;
    public TimerScript timerScript;

    public void Skip()
    {
        cameraSwitch.ChangeView();
        timerScript.StartCountUp();
    }
}
