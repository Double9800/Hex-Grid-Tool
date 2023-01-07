using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerations;

public class Tile : MonoBehaviour
{


    private EnumUtility.TileTheme TileTypology;
    private string[] NeighboringCells = { "NE", "E", "SE", "SO", "O", "NO" };
    private Material[] TileMat;

    private EnumUtility.TileTheme ReturnTileTypology()
    {
        return TileTypology;
    }

    private Transform ReturnTransform()
    {
        return this.gameObject.transform;
    }

    public void CheckTypologyEvent()
    {
        int[] RotationValues = { 25, 90, 155, 205, 270, 335 };
        string[] neighboringCellsString = { "NE", "E", "SE", "SO", "O", "NO" };
        Vector3 StartPoint = transform.position;
        RaycastHit _hit;

        for (int x = 0; x < 6; x++)
        {
            Vector3 Direction = Quaternion.Euler(transform.rotation.x, transform.rotation.y + RotationValues[x], transform.rotation.z) * Vector3.forward;
            Ray RayCast = new Ray(StartPoint, Direction);
            Debug.DrawRay(StartPoint, Direction, Color.red);

            if (Physics.Raycast(RayCast, out _hit, 1f))
            {
                if (_hit.transform.gameObject.GetComponent<Tile>() == true)
                {
                    Debug.Log(neighboringCellsString[x] + " " + _hit.transform.gameObject.GetComponent<Tile>().ReturnTileTypology());
                }
            }
            else
            {
                Debug.Log("NULL");
            }
        }
    }

}

