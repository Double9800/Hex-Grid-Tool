using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetHexTileParent : MonoBehaviour
{
    //Set Parent as father's tile and Destroy the HexTile when editor goes play
    private void Awake()
    {
        GameObject Parent = GameObject.FindGameObjectWithTag("HexTileParent");
        if (Application.isEditor && Parent != null)
        {           
            gameObject.transform.parent = Parent.transform;
        }
        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
