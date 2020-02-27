using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnTree : MonoBehaviour
{
    public GameObject[] Trees;
    public static List<Vector2> positions = new List<Vector2>();

    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    public void Spawn()
    {

        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
        SpawnGoodies();
    }
    void SpawnGoodies()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        GameObject TreePrefab = Trees[Random.Range(0, Trees.Length)];
        Instantiate(TreePrefab, pos, transform.rotation);
        positions.Add(pos);
    }
}

