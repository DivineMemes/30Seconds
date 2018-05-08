using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedScript : MonoBehaviour
{
    public Canvas gameCanvas;
    public Canvas winCanvas;
	
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            gameCanvas.gameObject.SetActive(false);
            winCanvas.gameObject.SetActive(true);
            StopAllCoroutines();
        }
    }
}
