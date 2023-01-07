using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SetTileParent : MonoBehaviour
{
    private void Awake()
    {
        GameObject Parent = GameObject.FindGameObjectWithTag("TileContainer");
        if(Parent != null)
        {
            gameObject.transform.parent = Parent.transform;
        }
    }
}
