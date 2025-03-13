using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    /*---Route summary data---------------------------------------------------------*/
    public Vector3[] waypoints;
    public List<GameObject> ports;
    public List<GameObject> ships;
    public float linelength;
    /*---References-----------------------------------------------------------------*/
    LineManager lm;
    LineLengthCalculator llc;
    LineRenderer lr;
    /*---Local variables---------------------------------------------------------*/
    private bool isRouteLooped;
    private bool isRouteFinished;
    private bool isRouteEditing;
    private void Awake()
    {
        lm = GetComponent<LineManager>();
        llc = GetComponent<LineLengthCalculator>();
    }
    private void Update()
    {
        if (lr == null)
        {
            lr = GetComponent<LineRenderer>();
        }
        if (!isRouteFinished)
        {
            ports = lm.ports;
            linelength = llc.length;
            waypoints = lm.points;
        }
    }
}