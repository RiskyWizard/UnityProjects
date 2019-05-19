using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    int width, height;
    public static List<GameObject> EnemyList;
    int numEnemies = 12;
    GameObject EnemyInstance;
    GameObject enemies;

    void Start() {
        EnemyList = new List<GameObject>();
        enemies = new GameObject("Enemies");
        width = Map.width;
        height = Map.height;
        EnemyInstance = Resources.Load<GameObject>("Enemy");

        for(int i = 0; i < numEnemies; i++) {
            GameObject e = GameObject.Instantiate(EnemyInstance,Map.SpawnPoint(),Quaternion.identity,enemies.transform);
            EnemyList.Add(e);
        
        }
    
    }

    void Update() {
    
    }

}
