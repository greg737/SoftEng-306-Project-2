﻿using UnityEngine;
using System.Collections;

public class BulletTimeSpawner : MonoBehaviour
{
    public GameObject powerup;

    //Spawn bullet time powerup at spawner position
    public void Spawn()
    {
        GameObject clone = (GameObject)Instantiate(powerup, transform.position, transform.rotation);
    }
}