using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Enumerations;

public class HexGridWindow : EditorWindow
{
    GameObject TileSpawner;
    int x, y;
    EnumUtility.TileTheme TileType;

    [MenuItem("Window/HexGridWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(HexGridWindow));
    }

    void OnGUI()
    {
        x = EditorGUILayout.IntField("X Size", x);
        y = EditorGUILayout.IntField("Y Size", y);

        if (GUILayout.Button("Instantiate Tile Generetor"))
        {
            SpawnObject();
        }

        TileType = (EnumUtility.TileTheme)EditorGUILayout.EnumPopup("Tile To Create", TileType);

        if (GUILayout.Button("Change Tile"))
        {
            ChangeTileType();
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
