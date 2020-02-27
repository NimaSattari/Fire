using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPick1 : MonoBehaviour
{
    GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    SpriteRenderer spriteRenderer;

    private void Update()
    {
        CircleCollider2D circleCollider2D = currentPoint.GetComponent<CircleCollider2D>();
        circleCollider2D.radius += Time.deltaTime / 100;
    }

    public void Random()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("point");
        index = UnityEngine.Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        spriteRenderer = currentPoint.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        StartCoroutine(TurnToBlack());
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject currentPoint1 = collision.gameObject;
        spriteRenderer = currentPoint1.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        StartCoroutine(TurnToBlack());
    }

    IEnumerator TurnToBlack()
    {
        yield return new WaitForSeconds(5);
        spriteRenderer.color = Color.black;
    }
}
