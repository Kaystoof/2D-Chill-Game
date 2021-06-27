using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTemplateGenerator : MonoBehaviour {

    public int gridSize;
    public int maxTileDist;

    public GameObject emptyGenerator;

    public GameObject player;

    public GameObject exit;

    public Vector3 exitSpawnPos;
    public Vector3 instantiatePos;
    public Vector3 playerSpawnPos;
    public float offsetPos;

    private ExitGenerator exitGenerator;

	// Use this for initialization
	void Start () {

        exitGenerator = GetComponent<ExitGenerator>();

		for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                SpawnEmpty(i,j);
                
            }
        }

        SpawnPlayer();

        exitGenerator.SpawnExit(offsetPos,maxTileDist);
        

        
	}
	

    void SpawnPlayer()
    {
        playerSpawnPos = new Vector3(0, 0, 0);
        Instantiate(player, playerSpawnPos, Quaternion.identity);
    }

   


    void SpawnEmpty(int x, int y)
    {
        //Calculates distance to move whole grid based off number of tiles and size of tiles
        offsetPos = (gridSize-1)*maxTileDist*0.5f;

        instantiatePos = new Vector3(x * maxTileDist - offsetPos, y * maxTileDist-offsetPos);
        Instantiate(emptyGenerator, instantiatePos, Quaternion.identity);

        

        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
