using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer = 30;
    public Text timerText;
    public CameraSwitch cameraSwitch;



    private void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    IEnumerator CountDownTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timer--;

            timerText.text = timer.ToString();

            if(timer <= 0)
            {
                StartCountUp();
            }
        }
    }

    IEnumerator CountUpTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timer++;

            timerText.text = timer.ToString();
        }
    }

    public void StartCountUp()
    {
        cameraSwitch.ChangeView();
        timer = 0;
        StopCoroutine(CountDownTimer());
        StartCoroutine(CountUpTimer());
    }

}
