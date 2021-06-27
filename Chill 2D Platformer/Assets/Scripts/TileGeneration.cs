using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    public List<GameObject> allTiles = new List<GameObject>();

    public float minGenDist = 10f;

    void Start()
    {
		
	}
	
	void Update()
    {
		
	}

    public void GenerateTile()
    {

    }

    private bool CheckGenerateTile(Transform _playerPosition)
    {
        for (int i = 0; i < allTiles.Count; i++)
        {
            bool tileInRangeX = false;

           // if (_playerPosition.position.x - allTiles[i].transform.position.x < )
            //{

            //}


        }

        return true;
    }
}
