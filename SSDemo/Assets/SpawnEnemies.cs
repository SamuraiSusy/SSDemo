﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{
    public bool destroyed;
    public GameObject enemyPref;
    GameObject enemy;
    List<GameObject> enemies = new List<GameObject>();
    float speedMultiplier;
    float time;
    CastleHp hp;

	// Use this for initialization
    void Start()
    {
        speedMultiplier = 1;
        //time = Time.time;
        //hp = GetComponent<CastleHp>();
    }

	// Update is called once per frame
	void Update ()
    {
        MoveEnemy();

        //if (hp.hp == 0)
        //    time = 0;
	}

    void FixedUpdate()
    {
        if (Time.time % 4 == 0)
        {
            CreateEnemy();
            if (Time.time > 15f)
                Invoke("CreateEnemy", 1);
        }
        if (Time.time % 10f == 0)
        {
            Debug.Log(Time.time);
            speedMultiplier = speedMultiplier + 0.5f;
        }
        if (Time.time != 0 && Time.time % 15f == 0)
        {
            Debug.Log("more");
        }
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
                    e.transform.Translate(-Vector3.up * Time.deltaTime * speedMultiplier);

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
