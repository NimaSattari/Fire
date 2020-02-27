using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPick : MonoBehaviour
{
    GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    SpriteRenderer spriteRenderer;
    List<int> burned = new List<int>();

    public void Random()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("point");
        print(spawnPoints);
        index = UnityEngine.Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        spriteRenderer = currentPoint.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        burned.Add(index);
        StartCoroutine(TurnToBlack());
        
    }

    private void findClosest(List<Vector2> positions, Vector2 a,float min=0)
    {
        int c = 0; // index of closest tree 
        float minDist = min; // min distance with closest tree
        for(int i=0;i<positions.Count; i++)
        {
            var p = positions[i];
            float dist = Vector2.Distance(p, a);
            if ((dist < minDist || minDist == 0) && i != index && !burned.Contains(i))
            {
                minDist = dist;
                c = i;
                burned.Add(i);
            }
        }
        // burning closest tree
        index = c;
        currentPoint = spawnPoints[index];
        spriteRenderer = currentPoint.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        StartCoroutine(TurnToBlack());

    }

    IEnumerator TurnToBlack()
    {
        StartCoroutine(BurnClose());
        yield return new WaitForSeconds(5);
        spriteRenderer.color = Color.black;
    }

    IEnumerator BurnClose()
    {
        yield return new WaitForSeconds(3);
        var a = SpawnTree.positions[index];
        findClosest(SpawnTree.positions, a);
    }
}
