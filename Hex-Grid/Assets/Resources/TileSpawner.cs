﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerations;

[ExecuteInEditMode]
public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Tiles;
    private bool CanSpawn;
    [HideInInspector] public int x, y;
    [HideInInspector] public TileTheme TileType;
    [SerializeField] private GridGeneretor gridGenerator;
    private GameObject TileContainer;
    [HideInInspector] public int NumberOfSpawn;
    private int z = 1;
    void Start()
    {
        if (NumberOfSpawn == 0 && Application.isEditor)
        {
            gridGenerator.CreateGrid(x, y);
            TileContainer = new GameObject("TileContainer");
            TileContainer.tag = "TileContainer";
            SetNumbeChangeNumberSpawn(ref z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTile(ref TileType);     
        BlockTransform();
    }

    //Get tile theme and change it
    public void SetTileTheme(TileTheme Type)
    {
        TileType = Type;
    }

    //Set NumberOfSpawn to 1, like this the window class can block the second spawn of this class
    public void SetNumbeChangeNumberSpawn(ref int x)
    {
        NumberOfSpawn = x;
    }

    //Block movement on Y axis
    private void BlockTransform()
    {
        gameObject.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    //Spawn Different tiles on the grid
    private void SpawnTile(ref TileTheme Type)
    {
        Vector3 Origin = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Ray ray = new Ray(Origin, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(Origin, Vector3.down, Color.blue);
        if (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.CompareTag("Tile"))
            {               
                CanSpawn = false;
            }
            else if (hit.collider.CompareTag("GridTile") && CanSpawn == false)
            {
                CanSpawn = true;
            }
            else if (hit.collider.CompareTag("GridTile") && CanSpawn == true)
            {
                Instantiate(Tiles[(int)TileType], hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                Tiles[(int)TileType].GetComponent<Tile>().TileTypology = Type;
                hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                Debug.Log("Nothing");
            }
        }
    }

    //Create Gizmo for the gameobject
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(gameObject.transform.position, new Vector3(0.5f, 0.1f, 0.5f));
    }
}
