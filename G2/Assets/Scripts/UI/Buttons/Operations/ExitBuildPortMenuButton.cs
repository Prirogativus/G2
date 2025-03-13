using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBuildPortMenuButton : MonoBehaviour
{
    public GameObject buildMenuCanvas;

    public void HideCanvas()
    {
        if (buildMenuCanvas != null)
        {
            buildMenuCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Bro hujnia");
        }
    }
}