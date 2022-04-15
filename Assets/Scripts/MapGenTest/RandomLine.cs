using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomLine : MonoBehaviour
{
    public TileBase dirt;
    public Tilemap map;
    public TileBase target;
    public int pathLength = 20;
    public int numberOfPath = 3;
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        while(count < numberOfPath)
        {
            List<Vector3Int> positions = new List<Vector3Int>();
            positions.Add( new Vector3Int(Random.Range(0, 32), Random.Range(0, 32), 0));

            for (int x = 1; x < pathLength; x++)
            {
                int rnd;
                positions.Add(positions[x - 1]);
                List<Vector3Int> possibleMove = new List<Vector3Int>();
                possibleMove.Add(new Vector3Int(1, 0, 0));
                possibleMove.Add(new Vector3Int(-1, 0, 0));
                possibleMove.Add(new Vector3Int(0, 1, 0));
                possibleMove.Add(new Vector3Int(0, -1, 0));
                if (x > 1)
                {
                    Vector3Int moveDone = positions[x - 1] - positions[x - 2];
                    moveDone.x *= -1;
                    moveDone.y *= -1;
                    possibleMove.Remove(moveDone);
                    rnd = Random.Range(0, possibleMove.Count);
                    positions[x] += possibleMove[rnd];
                    if (positions[x].x > 32 || positions[x].x < 0 || positions[x].y > 32 || positions[x].y < 0)
                    {
                        positions[x] -= possibleMove[rnd];
                        break;
                    }
                }
                else
                {
                    rnd = Random.Range(0, possibleMove.Count);
                    positions[x] += possibleMove[rnd];
                    if (positions[x].x > 32 || positions[x].x < 0 || positions[x].y > 32 || positions[x].y < 0)
                    {
                        positions[x] -= possibleMove[rnd];
                        break;
                    }
                }

            }
            Vector3Int[] pos = positions.ToArray();
            for (int i = 0; i < pos.Length; i++)
            {
                map.SetTile(new Vector3Int(positions[i].x, positions[i].y, 0), dirt);
            }
            count++;
        }

        for (int x = 0; x <= 32; x++)
        {
            for (int y = 0; y <= 32; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (map.HasTile(pos))
                {
                    TileBase current = map.GetTile(pos);
                    Debug.Log(current == target);
                }

            }
        }

    }

}
