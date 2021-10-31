using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTemplateGenerator : MonoBehaviour
{
    //number of tiles on one edge of the grid
    public int gridSize;
    //distance between tiles
    public int maxTileDist;

    public GameObject emptyGenerator;
    public GameObject player;
    public GameObject exit;

    //public Vector3 exitSpawnPos;
    public Vector3 instantiatePos;
    private Vector3 playerSpawnPos = new Vector3(0,0,0);
    //the offset for the entire grid so that it is in the centre of the world
    public float offsetPos;

    private List<GameObject> allTiles = new List<GameObject>();
    private List<GameObject> edgeTiles = new List<GameObject>();

    //private ExitGenerator exitGenerator;

	// Use this for initialization
	void Start ()
    {
        //get exit generator script
        //exitGenerator = GetComponent<ExitGenerator>();

        //spawn empties in correct location
		for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                SpawnEmpty(i,j);
            }
        }

        //spawn player
        SpawnPlayer();

        //exitGenerator.SpawnExit(offsetPos,maxTileDist);

        //find edges method
        FindEdges();
	}

    //spawn player
    void SpawnPlayer()
    {
        //Instantiate player
        Instantiate(player, playerSpawnPos, Quaternion.identity);
    }

   
    //spawns empty object with a level randomiser script
    void SpawnEmpty(int x, int y)
    {
        
        //Calculates distance to move whole grid based off number of tiles and size of tiles
        offsetPos = (gridSize-1)*maxTileDist*0.5f;

        //calculate empty position in grid
        instantiatePos = new Vector3(x * maxTileDist - offsetPos, y * maxTileDist-offsetPos);
        //instantiate empty
        GameObject g = Instantiate(emptyGenerator, instantiatePos, Quaternion.identity);
        //add to all tiles
        allTiles.Add(g);
    }

    private void FindEdges()
    {

        float edgeValuePos = ((gridSize*maxTileDist)/2) - maxTileDist/2 - 1;
        //float edgeValuePos = gridSize*(maxTileDist/2);
        //float edgeValuePos = 19;
        float edgeValueNeg = -edgeValuePos;

        for(int i = 0; i < allTiles.Count; i++)
        {

            if (allTiles[i].transform.position.x <= edgeValueNeg 
               || allTiles[i].transform.position.x >= edgeValuePos)
            {
                edgeTiles.Add(allTiles[i]);
            }
            else if (allTiles[i].transform.position.y <= edgeValueNeg
               || allTiles[i].transform.position.y >= edgeValuePos)
            {
                edgeTiles.Add(allTiles[i]);
            }
        }

        SpawnExit();
    }
    
    private void SpawnExit()
    {
        Debug.Log("shoes will fly");
        int k = Random.Range(0, edgeTiles.Count);
        //GameObject exitTileObject = edgeTiles[k];
        Debug.Log(k);
        //Instantiate(exit, edgeTiles[j].transform.position, Quaternion.identity);
    }
}
