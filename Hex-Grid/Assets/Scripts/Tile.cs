using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerations;

public class Tile : MonoBehaviour
{

    [HideInInspector]public EnumUtility.TileTheme TileTypology;
    [HideInInspector]public string[] Cells = new string[6];
    
    private string ReturnTileTypology()
    {
        return TileTypology.ToString();
    }

    private Transform ReturnTransform()
    {
        return this.gameObject.transform;
    }

    public void SetType(EnumUtility.TileTheme Type)
    {
        TileTypology = Type;
    }

    public void CheckTypologyEvent()
    {
        string[] NeighboringCells = new string[6];
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
                    NeighboringCells[x] = _hit.transform.gameObject.GetComponent<Tile>().ReturnTileTypology();
                    Cells[x] = NeighboringCells[x];
                }
            }
            else
            {
                NeighboringCells[x] = "NULL";
                Cells[x] = NeighboringCells[x];
                Debug.Log("Null");
            }
        }
    }

}

