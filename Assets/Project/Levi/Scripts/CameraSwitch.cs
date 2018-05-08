using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public Camera topDown;
    public Camera firstPerson;

    public Button skipButton;
    public Text goalText;
    public Text startText;

    public void ChangeView()
    {
        firstPerson.gameObject.SetActive(true);

        topDown.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
        goalText.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
    }
}
