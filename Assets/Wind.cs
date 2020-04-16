using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int rotation = 0;
    public void Rotate()
    {
        transform.Rotate(Vector3.forward * 90f);
        if(rotation == 0)
        {
            rotation = 1;
        }
        else if(rotation == 1)
        {
            rotation = 2;
        }
        else if (rotation == 2)
        {
            rotation = 3;
        }
        else if (rotation == 3)
        {
            rotation = 0;
        }
    }

}
