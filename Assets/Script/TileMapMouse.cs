using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour
{
    Renderer rend; TileMap _tileMap;
    Vector3 currentTileCoord;
    public Collider coll;
    public Transform selectionCube;
    void Start()
    {
        _tileMap = GetComponent<TileMap>();
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if ( coll.Raycast(ray, out hitInfo, Mathf.Infinity) ){
            int x = Mathf.FloorToInt( hitInfo.point.x / _tileMap.tileSize ),
                z = Mathf.FloorToInt( hitInfo.point.z / _tileMap.tileSize );
            Debug.Log ("Tile: " + x + ", " + z);
            currentTileCoord.x = x; currentTileCoord.z = z;
            selectionCube.transform.position = currentTileCoord*1f;
        } else {
        }

        
    }
}
