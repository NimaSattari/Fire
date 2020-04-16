using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpread : MonoBehaviour
{
    GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;

    public void Random()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("point");
        index = UnityEngine.Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        if (!currentPoint.GetComponent<Tree>().CantFire)
        {
            currentPoint.GetComponent<Tree>().Fire();
        }
    }
}
