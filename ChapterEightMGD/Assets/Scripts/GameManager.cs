using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the main gameplay of the game
/// </summary>

public class GameManager : MonoBehaviour
{
    [Tooltip("A reference to the tile we want to spawn")]
    public Transform tile;

    [Tooltip("A reference to the obstacle we want to spawn")]
    public Transform obstacle;

    [Tooltip("Where the first tile should be placed at")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("How many tiles should we create in advance")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Tooltip("How many tiles to spawn with no obstacles")]
    public int initNoObstacles = 4; 

    /// <summary>
    /// Where the next tile should be spawned at
    /// </summary>
    private Vector3 nextTileLocation;

    /// <summary>
    /// How should the next tile be rotated?
    /// </summary>
    private Quaternion nextTileRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Set our starting point
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i< initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }
    

    /// <summary>
    /// Will spawn a tile at a certain location and setup the next position
    /// </summary>
    
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);

        // Figure out where and at what rotation we should spawn the next item
        var nextTile = newTile.Find("Next Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;

        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle(Transform newTile)
    {
        // now we need to get all of the possible places to spawn the obstacle
        var obstacleSpawnPoints = new List<GameObject>();

        // go through each of the child game object in our tile
        foreach (Transform child in newTile)
        {
            if (child.CompareTag("ObstacleSpawn"))
            {
                // we add it as a possibility 
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }

        // make sure there is at least one
        if (obstacleSpawnPoints.Count > 0)
        {
            // Get a random spawm point from the ones we have
            int index = Random.Range(0, obstacleSpawnPoints.Count);
            var spawnPoint = obstacleSpawnPoints[index];

            //Store its position for us to use 
            var spawnPos = spawnPoint.transform.position;

            // Create our obstacle
            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

            // Have it parented to the tile
            newObstacle.SetParent(spawnPoint.transform);
        }
    }
}
