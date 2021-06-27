using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGenerator : MonoBehaviour {

    private TileTemplateGenerator tileTemplateGenerator;

    public GameObject exit;



    Vector3 exitSpawnPos;

    //Determines whether X or Y will be the maximum value for exit location  
    bool maxX = false;

    int maxSign = 0;

	// Use this for initialization
	void Start () {
        
        
    }


    public void SpawnExit(float _offsetPos, float _maxTileDist)
    {
        int randNumbM = Random.Range(0, 2);
        Debug.Log("randNumb = " + randNumbM);
        if (randNumbM == 0)
        {
            maxX = true;
        }


        //Determines if sign of maximum number will be + or -
        int randNumbP = Random.Range(0, 2);

        if(randNumbP == 0)
        {
            maxSign = -1;
        }
        else
        {
            maxSign = 1;
        }


        float exitPositionX = 0;
        float exitPositionY = 0;

        if (maxX == true)
        {
            exitPositionX = maxSign*Random.Range(_offsetPos - _maxTileDist, _offsetPos);
            exitPositionY = Random.Range(-_offsetPos, _offsetPos);
        }
        else
        {
            exitPositionY = maxSign*Random.Range(_offsetPos - _maxTileDist, _offsetPos);
            exitPositionX = Random.Range(-_offsetPos, _offsetPos); 
        }

        exitSpawnPos = new Vector3(exitPositionX, exitPositionY, 0);

        Instantiate(exit, exitSpawnPos, Quaternion.identity);

        Debug.Log(exitPositionX);
        Debug.Log(exitPositionY);

        Debug.Log("offsetPos = " + _offsetPos);
        Debug.Log("maxTileDist = " + _maxTileDist);

        Debug.Log(maxX);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
