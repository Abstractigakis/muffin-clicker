using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyToolbox
{
    public static Vector2 GetRandomVector2(float w, float x, float y, float z)
    {
        Vector2 value = new Vector2();
        value.x = Random.Range(w, x);
        value.y = Random.Range(y, z);
        return value;
    }
}
