using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public static int width = 256;
    public static int height = 128;

    static GameObject[,] mapGrid;
    string seed;
    GameObject BlockInstance;
    GameObject Player;
    GameObject map;
    float fillPerc;
    int updateCount = 0;

	void Awake() {
        Player = GameObject.FindWithTag("Player");
        fillPerc = 0.40f;
        map = new GameObject("Map");
        BlockInstance = Resources.Load<GameObject>("Block");

        MapInit();
        UpdateMap();
        /*
        InvokeRepeating("UpdateMap",0.3f,0.6f);
        */

        /*
        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                Debug.Log(GetNeighbors(i,j));
                if(mapGrid[i,j].activeInHierarchy)
                    GameObject.Instantiate(BlockInstance,new Vector3(i,j,0),Quaternion.identity,map.transform);
            }
        }
        */
		
	}

    void Update() {
    }

    void MapInit() {
        mapGrid = new GameObject[width,height];
        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                mapGrid[i,j] = GameObject.Instantiate(BlockInstance, new Vector3(i,j,0),Quaternion.identity,map.transform);
                mapGrid[i,j].SetActive(false);
            }
        }

        Random.seed = System.DateTime.Now.Millisecond;

        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                if(i == 0 || i == width-1 || j == 0 || j == height-1)   mapGrid[i,j].SetActive(true);
                else {
                    if(Random.value > fillPerc) mapGrid[i,j].SetActive(true);
                    else                mapGrid[i,j].SetActive(false);
                }
                
            }
        }
    
    }

    void UpdateMap() {
        int maxNeighbors = 4;
        int iterations = width * height * 10;
        //int iterations = 1000;

        //for(int x = 1; x < width-1; x++) {
            //for(int y = 1; y < height-1; y++) {
        for(int i = 0; i < iterations; i++) {
            int x = Random.Range(1,width-1);
            int y = Random.Range(1,height-1);
            if(GetNeighbors(x,y) > maxNeighbors) 
                mapGrid[x,y].SetActive(true);
            else
                mapGrid[x,y].SetActive(false);
            
            
        }
    
    }

    int GetNeighbors(int x, int y) {
        int count = 0;
        for(int i = x-1; i <= x+1; i++) {
            for(int j = y-1; j <= y+1; j++) {
                if((i != x || j != y) && (i >= 0 && i < width && j >= 0 && j < height))
                    count += mapGrid[i,j].activeInHierarchy ? 1 : 0;
            }
        }
        return count;
    
    }

    public static Vector3 SpawnPoint() {
        int x = Random.Range(1,width-1);
        int y = Random.Range(1,height-1);
        while(mapGrid[x,y].activeInHierarchy) {
            x = Random.Range(1,width-1);
            y = Random.Range(1,height-1);
        }
        return new Vector3(x,y,0);
    }
	
}
