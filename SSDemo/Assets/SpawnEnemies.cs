using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{
    public bool destroyed;
    public GameObject enemyPref;
    GameObject enemy;
    List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("CreateEnemy", 1, 4f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveEnemy();
	}

    void CreateEnemy()
    {
        float random = Random.RandomRange(-2.4f, 2.4f);
        enemy = (GameObject)Instantiate(enemyPref, new Vector3(random, 5), Quaternion.identity);
        enemies.Add(enemy);
    }

    void MoveEnemy()
    {
        int lenght = enemies.Count;
        if (enemies.Count != 0)
        {
            for (int i = 0; i < lenght; i++)
            {
                GameObject e = enemies[i];
                if(e != null)
                    e.transform.Translate(-Vector3.up * Time.deltaTime * 2);

                if (e.transform.position.y < -6f || destroyed)
                {
                    enemies.RemoveAt(i);
                    Destroy(e);
                    destroyed = false;
                }
            }
        }
    }
}
