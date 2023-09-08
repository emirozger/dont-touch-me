using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class blockdeleter : MonoBehaviour
{
    public GameObject block;
    public Transform player;


    public Vector3 gozukenkisim;
    float timer = 0;
    bool random = false;







    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            if (random == false)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    block.transform.position = new Vector3(0, -6f, 0);
                    random = true;
                    timer = 0;

                }
            }

            if (random == true)
            {
                if (Input.GetKeyDown(KeyCode.P) && timer > 3)
                {
                    block.transform.position = new Vector3(player.transform.position.x + 10, -2f, 0);
                    random = false;
                    timer = 0;
                }
            }
        }
    }



}
