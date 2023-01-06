using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawHexTileGizmo : MonoBehaviour
{
    //Set Parent as father's tile and Destroy the HexTile when editor goes play
    private void Awake()
    {
        if (Application.isEditor)
        {
            GameObject Parent = GameObject.FindGameObjectWithTag("HexTileParent");
            gameObject.transform.parent = Parent.transform;
        }
        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "Light Gizmo.tiff");
    }
}
