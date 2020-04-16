using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool fired = false;
    public bool CantFire = false;
    int x = 0;
    int y = 0;
    GameObject wind;
    [SerializeField] [Range(0.01f, 0.1f)] float Speed = 0.01f;
    float timer = 0f;
    public void Fire()
    {
        fired = true;
        CantFire = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(TurnToBlack());
    }
    private void Start()
    {
        wind = GameObject.Find("Wind");
    }
    private void FixedUpdate()
    {
        if (fired == true)
        {
            switch (wind.GetComponent<Wind>().rotation)
            {
                case 0:
                    x = -1;
                    y = 0;
                    break;
                case 1:
                    y = -1;
                    x = 0;
                    break;
                case 2:
                    x = 1;
                    y = 0;
                    break;
                case 3:
                    y = 1;
                    x = 0;
                    break;
            }
            GetComponent<CircleCollider2D>().radius = ((timer += Time.deltaTime) * Speed) + 0.1f;
            GetComponent<CircleCollider2D>().offset = new Vector2(x * (timer += Time.deltaTime) * Speed, y * (timer += Time.deltaTime) * Speed);
        }
    }
    IEnumerator TurnToBlack()
    {
        yield return new WaitForSeconds(10);
        fired = false;
        GetComponent<SpriteRenderer>().color = Color.black;
        GetComponent<CircleCollider2D>().radius = 0.1f;
        timer = 0f;
        GetComponent<CircleCollider2D>().offset = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tree>().CantFire == false)
        {
            collision.GetComponent<Tree>().Fire();
        }
    }
}
