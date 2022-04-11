using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomMap : MonoBehaviour
{

    public TileBase[] grass_sprite;
    public Tilemap map;

    // Start is called before the first frame update
    void Start()
    {        
        
        for(int y = 0; y <= 32; y++)
        {
            for(int x = 0; x <= 32; x++)
            {
                map.SetTile(new Vector3Int(x, y, -1), grass_sprite[Random.Range(0, grass_sprite.Length)]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
