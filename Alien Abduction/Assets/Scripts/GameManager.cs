using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] SpawnItems;

    public Vector2 position;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 1);
    }

    void SpawnEnemy() {
        int rnd = Random.Range(0, SpawnItems.Length);
        // GameObject Camera = GameObject.Find("Main Camera");
        Camera oCamera = Camera.main;
        // float cameraHeight = 2f * oCamera.orthographicSize;
        Vector2 position = new Vector2(Random.Range(-4.6f, 4.6f), oCamera.orthographicSize + 0.4f);
        var debris = Instantiate(SpawnItems[0], position, Quaternion.identity);
        GameObject Foreground = GameObject.Find("Foreground"); 
        debris.transform.SetParent(Foreground.transform, false);
    }
}
