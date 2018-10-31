using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 56.69f;
    private int amnTilesOnScreen = 7;
    private List<GameObject> activeTiles;
    private float safeZone = 50.0f;
	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTiles();
        }

	}
	
	// Update is called once per frame
	void Update () {
        if(playerTransform.position.z - safeZone > ( spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTiles();
            DeleteTile();
        }

    }

    private void SpawnTiles()
    {
        GameObject go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
