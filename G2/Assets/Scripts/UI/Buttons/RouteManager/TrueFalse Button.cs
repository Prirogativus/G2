using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueFalseButton : MonoBehaviour
{
    public GameObject BasicCanvas;
    public GameObject RoutesEditor;
    public bool BasicCanvasIsEnabled = true;
    public Image buttonImage;
    public Sprite enableIcon;
    public Sprite disableIcon;
    public bool isRoutesEditorOn = false;
    public void ButtonClicked()
    {
        BasicCanvasIsEnabled = !BasicCanvasIsEnabled;
        isRoutesEditorOn = !BasicCanvasIsEnabled;
        BasicCanvas.SetActive(BasicCanvasIsEnabled);
        RoutesEditor.SetActive(!BasicCanvasIsEnabled);

        if (BasicCanvasIsEnabled)
        {
            buttonImage.sprite = enableIcon;
        }
        else 
        {
            buttonImage.sprite = disableIcon;
        }
    }  
        void Start()
    {
        
    }
    void Update()
    {
        
    }
}
