using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -5.0f;
    private float tileLength = 10.0f;
    private int amnTilesOnScreen = 7;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        
        activeTiles=new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile(0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    void SpawnTile (int prefabIndex = -1) {
        
        GameObject go;
        if(prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);

    }

    void DeleteTile() {

        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    int RandomPrefabIndex() {

        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
