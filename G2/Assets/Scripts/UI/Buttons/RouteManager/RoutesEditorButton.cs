using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoutesEditorButton : MonoBehaviour
{
    public GameObject BasicCanvas;
    public GameObject RoutesEditor;
    public bool BasicCanvasIsEnabled = true;
    public bool RoutesEditorIsEnabled = false;
    public Image buttonImage;
    public Sprite enableIcon;
    public Sprite disableIcon;

    public void ButtonClicked()
    {
        BasicCanvasIsEnabled = !BasicCanvasIsEnabled;
        RoutesEditorIsEnabled = !RoutesEditorIsEnabled;
        BasicCanvas.SetActive(BasicCanvasIsEnabled);
        RoutesEditor.SetActive(!BasicCanvasIsEnabled);

        /*if (BasicCanvasIsEnabled)
        {
            buttonImage.sprite = enableIcon;
        }
        else 
        {
            buttonImage.sprite = disableIcon;
        }*/
    }
       
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
