using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolling : MonoBehaviour
{
    public GameObject obje;
    public float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * -1 - 3;
        obje.transform.position = new Vector3(3, y, 0);
    }
}
