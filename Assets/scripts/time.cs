using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{


    float totaltime = 0f;
    private float waitTime = 0.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;

    public GameObject character;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            visualTime = timer;
            timer = timer - waitTime;
            Debug.Log(timer);

            if (timer >= 10f)
            {
                Destroy(character);
            }

        }

        void sayac()
        {

            totaltime += Time.deltaTime;
            totaltime++;

            Debug.Log(totaltime);
            totaltime = 0;

            if (totaltime >= 2f)
            {
                Destroy(character);

            }
        }

    }
}