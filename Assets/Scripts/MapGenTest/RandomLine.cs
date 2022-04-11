using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomLine : MonoBehaviour
{
    public TileBase dirt;
    public Tilemap map;
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        while(count <= 3)
        {
            Vector3Int[] positions = new Vector3Int[100];
            positions[0] = new Vector3Int(Random.Range(0, 32), Random.Range(0, 32), 0);

            for (int x = 1; x < positions.Length; x++)
            {
                int rnd = 0;
                positions[x] = positions[x - 1];
                List<Vector3Int> possibleMove = new List<Vector3Int>();
                possibleMove.Add(new Vector3Int(1, 0, 0));
                possibleMove.Add(new Vector3Int(-1, 0, 0));
                possibleMove.Add(new Vector3Int(0, 1, 0));
                possibleMove.Add(new Vector3Int(0, -1, 0));
                if (x > 1)
                {
                    Vector3Int moveDone = positions[x - 1] - positions[x - 2];
                    Debug.Log("moveDove " + moveDone);
                    moveDone.x *= -1;
                    moveDone.y *= -1;
                    possibleMove.Remove(moveDone);
                    foreach (Vector3Int move in possibleMove)
                    {
                        Debug.Log(move);
                    }
                    rnd = Random.Range(0, possibleMove.Count);
                    positions[x] += possibleMove[rnd];
                }
                else
                {
                    rnd = Random.Range(0, possibleMove.Count);
                    positions[x] += possibleMove[rnd];
                }

            }
            for (int p = 0; p < positions.Length; p++)
            {
                Debug.Log(positions[p]);
            }

            for (int i = 0; i < positions.Length; i++)
            {
                map.SetTile(new Vector3Int(positions[i].x, positions[i].y, 0), dirt);
            }
            count++;
        }
        
    }

    void checkExist(Vector3Int[] pos, int i)
    {
        if(i > 1)
        {
            if(pos[i] == pos[i - 2])
            {
                pos[i].x++;
            }
        }
    }
}
