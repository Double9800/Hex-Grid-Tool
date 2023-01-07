using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Enumerations;

public class HexGridWindow : EditorWindow
{
    GameObject TileSpawner;
    GameObject[] Tile;
    int x, y;
    EnumUtility.TileTheme TileType;
    string NE, E, SE, SO, O, NO;
    

    [MenuItem("Window/HexGridWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(HexGridWindow));
    }

    void OnGUI()
    {
        x = EditorGUILayout.IntField("X Size", x);
        y = EditorGUILayout.IntField("Y Size", y);

        if (GUILayout.Button("Create Grid & Instantiate Tile spawner"))
        {
            SpawnObject();
        }

        TileType = (EnumUtility.TileTheme)EditorGUILayout.EnumPopup("Tile To Create", TileType);

        if (GUILayout.Button("Change Tile"))
        {
            ChangeTileType();
        }
       
        EditorGUILayout.TextField("North East Cell",NE);
        EditorGUILayout.TextField("East Cell",E);
        EditorGUILayout.TextField("South East Cell",SE);
        EditorGUILayout.TextField("South West Cell",SO);
        EditorGUILayout.TextField("West Cell",O);
        EditorGUILayout.TextField("North West Cell",NO);

        if (GUILayout.Button("Check neighboring cells(selected cell)"))
        {
           Tile = Selection.gameObjects;
           Tile[0].GetComponent<Tile>().CheckTypologyEvent();
            NE =  Tile[0].GetComponent<Tile>().Cells[0];
            E =   Tile[0].GetComponent<Tile>().Cells[1];
            SE =  Tile[0].GetComponent<Tile>().Cells[2];
            SO =  Tile[0].GetComponent<Tile>().Cells[3];
            O =   Tile[0].GetComponent<Tile>().Cells[4];
            NO = Tile[0].GetComponent<Tile>().Cells[5]; 
        }
    }

    void SpawnObject()
    {
        TileSpawner = Resources.Load("TileSpawner", typeof(GameObject)) as GameObject;
        TileSpawner.GetComponent<TileSpawner>().x = x;
        TileSpawner.GetComponent<TileSpawner>().y = y;
        Instantiate(TileSpawner, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void ChangeTileType()
    {
        TileSpawner = GameObject.FindGameObjectWithTag("TileSpawner");
        TileSpawner.GetComponent<TileSpawner>().SetTileTheme(TileType);
    }
}
