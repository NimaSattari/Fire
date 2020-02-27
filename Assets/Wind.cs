using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float Angle = 90f;
    public void Rotate()
    {
        transform.Rotate(Vector3.forward * -90f);
    }

}
