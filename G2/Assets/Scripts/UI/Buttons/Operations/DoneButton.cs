using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneButton : MonoBehaviour
{
    public GameObject operationCanvas;
    public bool operationCanvasIsEnabled;
    public void ButtonClicked()
    {
        operationCanvasIsEnabled = operationCanvas.activeSelf;
        operationCanvasIsEnabled = !operationCanvasIsEnabled;
        operationCanvas.SetActive(operationCanvasIsEnabled);
    }  

}
