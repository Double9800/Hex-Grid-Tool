using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneretor : MonoBehaviour
{
    [HideInInspector]
    public int GridX, GridY;
    [SerializeField]
    private GameObject Tile;

    private const float OffsetOnX = 0.22f;
    private const float outerRadius = 1f;

    //GenerateHexGrid
    public void CreateGrid(int Xaxis, int Yaxis)
    {
        GameObject Parent = new GameObject("HexTileContainer");
        Parent.tag = "HexTileParent";
        for (float x = 0; x < Xaxis; x++)
        {
            for (float y = 0; y < Yaxis; y++)
            {
                InstantiateTile(x, y);
            }
        }
    }

    //Instantiate Tile in different Rows(Odd & Even) 
    private void InstantiateTile(float x, float y)
    {

        if (x % 2 == 0)
        {
            Instantiate(Tile, EvenLineVector(x, y), Quaternion.identity);
            //Tile.transform.parent = Parent.Transform;
        }
        else
        {
            Instantiate(Tile, OddLineVector(x, y), Quaternion.identity);
            //Tile.transform.parent = Parent.Transform;
        }

    }

    //Return Odd position
    private Vector3 OddLineVector(float x, float y)
    {
        float xPosition = (x + y * 0.5f - y / 2) * (OffsetOnX * 1.97f);
        float yPosition = 0f;
        float zPosition = y * (outerRadius * 1.5f);

        return new Vector3(xPosition, yPosition, zPosition);
    }

    //Return Even position
    private Vector3 EvenLineVector(float x, float y)
    {
        float xPosition = (x + y * 0.5f - y / 2) * (OffsetOnX * 1.97f);
        float yPosition = 0f;
        float zPosition = y * (outerRadius * 1.5f) + 0.75f;


        return new Vector3(xPosition, yPosition, zPosition);
    }
}
