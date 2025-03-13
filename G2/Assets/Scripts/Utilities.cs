using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    int[] ResizeArray(int[] source, int newSize)
    {
        int[] newArray = new int[newSize];
        for (int i = 0; i < Mathf.Min(source.Length, newSize); i++)
        {
            newArray[i] = source[i];
        }
        return newArray;
    }
    public Vector3[] PointsArrayResize(Vector3[] source, int newSize)
    {
        Vector3[] newArray = new Vector3[newSize];
        for (int i = 0; i < Mathf.Min(source.Length, newSize); i++)
        {
            newArray[i] = source[i];
        }
        return newArray;
    }
    /*GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
    }*/

}

