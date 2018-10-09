using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
    public GameObject Enemy;
    float wait;
    bool spawn;
	// Use this for initialization
	void Start () {
        spawn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!spawn)
        {
            StartCoroutine("Spawnear");
            spawn = true;
        }
	}

    IEnumerator Spawnear()
    {
        Vector2 origen;
        for (int i = 1; i < 10; i++)
        {
            origen.x = Random.Range(1, 800);
            origen.y = 1024;
            GameObject clone = Instantiate(Enemy) as GameObject;
            clone.transform.position = origen;
            yield return null;
        }
        spawn = false;
    }

}
