using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletleCanvas;
    [SerializeField] private GameObject messageUI;
    private bool _isActivated = false;

    public void Activate()
    {
        _isActivated = true;
        messageUI.SetActive(false);
    }

     public void FinishLevel()
    {
        if (_isActivated)
        {
            levelCompletleCanvas.SetActive(true);
            //gameObject.SetActive(false); // - house delate
            Time.timeScale = 0f;
        }
        else
        {
            messageUI.SetActive(true);
        }
    }
}
