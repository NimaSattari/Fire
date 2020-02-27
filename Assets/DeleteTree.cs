using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTree : MonoBehaviour
{
    GameObject[] Trees;
    public void Delete()
    {
        Trees = GameObject.FindGameObjectsWithTag("point");
        for (var i = 0; i < Trees.Length; i++)
            Destroy(Trees[i]);
    }
}
