using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tersgravity : MonoBehaviour
{
    //float timer = 0;
    public bool girdimi = false;
    private IEnumerator coroutine;
    float timer = 3;
    ustkarakterController secondchar;
    //CharacterController mainchar;


    private void Start()
    {
        secondchar = FindObjectOfType<ustkarakterController>();
        //FindObjectOfType<CharacterController>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player2") && timer >= 3 && girdimi == false)
        {
            girdimi = true;
            Debug.Log(girdimi);
            timer = 0;

            Physics2D.gravity = new Vector3(0, 2f, 0 * Time.deltaTime);
        }


        if (collision.CompareTag("Player2") && timer >= 3 && girdimi == true)
        {
            Physics2D.gravity = new Vector3(0, -10f, 0 * Time.deltaTime);

            girdimi = false;
            timer = 0;
            secondchar.etkilesimegirdimi = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            secondchar.etkilesimegirdimi = true;
            //Debug.Log(girdimi);

        }
    }


}
