using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour {
    public GameObject[] collectibles;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private List<GameObject[]> activeCollectibles;
    private int safeZone = 50;
    private float tileLength = 56.69f;
    private int amnTilesOnScreen = 7;
    private int[] xPositions;
    // Use this for initialization
    void Start () {
        activeCollectibles = new List<GameObject[]>();
        xPositions = new int[]{ 6, 2, -2};
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnCollectibles();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnCollectibles();
            DeleteCollectibles();
        }
    }

    private void SpawnCollectibles()
    {
        GameObject[] objs = SpawnRandom();
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].transform.position = new Vector3(objs[i].transform.position.x, objs[i].transform.position.y, objs[i].transform.position.z+ spawnZ);
        }
        spawnZ += tileLength;
        activeCollectibles.Add(objs);
    }

    private GameObject[] SpawnRandom()
    {
        int size = Random.Range(3, 6);
        GameObject[] objs = new GameObject[size];
        for(int i=0; i<size; i++)
        {
            int type = Random.Range(0, 3);
            int randomX = Random.Range(0, 3);
            float randomz = Random.Range(-10, 25);
            GameObject collect = Instantiate(collectibles[type]) as GameObject;
            collect.transform.SetParent(transform);
            collect.transform.position = new Vector3(xPositions[randomX], -2.6f, randomz);
            objs[i] = collect;
        }
        return objs;
    }

    private void DeleteCollectibles()
    {
        GameObject[] objs = activeCollectibles[0];
        for(int i=0; i<objs.Length; i++)
        {
            if(objs[i] != null)
            {
                Destroy(objs[i]);
            }
        }
        activeCollectibles.RemoveAt(0);
    }
}
