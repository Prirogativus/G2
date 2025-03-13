using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class FinishRouteCreationButton : MonoBehaviour
{
    public GameObject BasicCanvas;
    public GameObject RoutesEditor;
    public GameObject smallShipPrefab;
    public GameObject mediumShipPrefab;
    public GameObject largeShipPrefab;
    public Route route;
    public AddShip addShip;
    public bool BasicCanvasIsEnabled = true;
    bool isRoutesEditorOn = false;
    private void Awake()
    {
        route = FindObjectOfType<Route>();
        addShip = GameObject.Find("AddShipPanel").GetComponent<AddShip>();
    }
    public void ButtonClicked()
    {
        ShipsInstantiation();
        BasicCanvasIsEnabled = !BasicCanvasIsEnabled;
        BasicCanvas.SetActive(BasicCanvasIsEnabled);
        RoutesEditor.SetActive(!BasicCanvasIsEnabled);
        GameObject[] points = GameObject.FindGameObjectsWithTag("point");
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] != null)
            {
                points[i].SetActive(false);
            }
        }

    }
    public void ShipsInstantiation()
    {
        GameObject currentShip;
        for (int i = 0; i < addShip.smallShipAmount; i++) 
        {
            currentShip = Instantiate(smallShipPrefab, route.waypoints[0],  Quaternion.Euler(-90, 0 , 0));
            ShipMovement shipMovement = currentShip.GetComponent<ShipMovement>();
            shipMovement.route = route;
        }
        for (int i = 0; i < addShip.mediumShipAmount; i++)
        {
            currentShip = Instantiate(smallShipPrefab, route.waypoints[0], new Quaternion(-90, 0, 0, 0));
            ShipMovement shipMovement = currentShip.GetComponent<ShipMovement>();
            shipMovement.route = route;
        }
        for (int i = 0; i < addShip.largeShipAmount; i++)
        {
            currentShip = Instantiate(smallShipPrefab, route.waypoints[0], new Quaternion(-90, 0, 0, 0));
            ShipMovement shipMovement = currentShip.GetComponent<ShipMovement>();
            shipMovement.route = route;
        }
    }
}
