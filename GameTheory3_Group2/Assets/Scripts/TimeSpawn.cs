using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class TimeSpawn : MonoBehaviour
{ 
    //VARIABLES
    public GameObject player;
    private GameObject spawnee;
    public bool stopSpwaning=false;
    public float spawnTime;
    public float spawnDeay;
    public bool sw=false;
    public List<GameObject> obstacles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<LaunchBall>().launched && !sw )
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDeay);
            sw = true;
        }

    }

    public void SpawnObject()
    {
        spawnee = obstacles[Random.Range(0, obstacles.Count)];
        Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(-10,10),transform.position.y);
        Instantiate(spawnee, spawnPosition, transform.rotation);
       
        if (stopSpwaning)
        {
            CancelInvoke("SpawnObject");
        }

    }

    

}
