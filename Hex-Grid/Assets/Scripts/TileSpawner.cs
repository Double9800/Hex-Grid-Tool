using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Tiles;
    private bool CanSpawn;
    public int x, y;
    [SerializeField] private int TileType;
    [SerializeField] private GridGeneretor gridGenerator;
    private GameObject TileContainer;
    void Start()
    {
        gridGenerator.CreateGrid(x, y);
        TileContainer = new GameObject("TileContainer");
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTile();
        BlockTransform();
    }

    //Block movement on Y axis
    private void BlockTransform()
    {
        gameObject.transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    //Spawn Different tiles on the grid
    private void SpawnTile()
    {
        Vector3 Origin = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Ray ray = new Ray(Origin, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(Origin, Vector3.down, Color.blue);
        if (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.CompareTag("Tile"))
            {
                Debug.Log(hit.transform.name);
                CanSpawn = false;
            }
            else if (hit.collider.CompareTag("GridTile") && CanSpawn == false)
            {
                CanSpawn = true;
            }
            else if (hit.collider.CompareTag("GridTile") && CanSpawn == true)
            {
                Instantiate(Tiles[TileType], hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
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
