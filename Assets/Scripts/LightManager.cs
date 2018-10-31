using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {
    public GameObject[] lightsPrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private List<GameObject> activeLights;
    private int safeZone = 50;
    private float tileLength = 56.69f;
    private int amnTilesOnScreen = 7;

    // Use this for initialization
    void Start () {
        activeLights = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnLight();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnLight();
            DeleteLight();
        }
    }

    private void SpawnLight()
    {
        int type = Random.Range(0, 3);
        GameObject go = Instantiate(lightsPrefabs[type]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(2.35f,0, spawnZ);
        spawnZ += 2* tileLength;
        activeLights.Add(go);

    }

    private void DeleteLight()
    {
        Destroy(activeLights[0]);
        activeLights.RemoveAt(0);
    }
}
