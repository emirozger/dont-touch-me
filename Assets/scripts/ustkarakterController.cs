using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ustkarakterController : MonoBehaviour
{
    public float Speed;
    CharacterController altkarakter;
    float timer = 0;
    public Animator playerAnimation;
    Rigidbody2D rb2d;
    public bool etkilesimegirdimi = false;
    public float hareket;
    tersgravity tersgravitykodu;

    void Start()
    {
        altkarakter = FindObjectOfType<CharacterController>();
        playerAnimation = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        tersgravitykodu = FindObjectOfType<tersgravity>();


    }

    void Update()
    {
        timer += Time.deltaTime;
        hareket = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(Speed * hareket, rb2d.velocity.y);
            transform.localScale = new Vector2(0.12f, 0.12f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(Speed * hareket, rb2d.velocity.y);
            transform.localScale = new Vector2(-0.12f, 0.12f);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        PlayAndAnimate();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if
            (collision.CompareTag("button2") && timer >= 3)
        {
            Physics2D.gravity = new Vector3(0, -2f, 0);
            timer = 0;
            etkilesimegirdimi = true;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "button2")
        {
            etkilesimegirdimi = true;
            Debug.Log(etkilesimegirdimi);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "button2")
        {
            etkilesimegirdimi = false;
            Debug.Log(etkilesimegirdimi);
        }
    }

    private void PlayAndAnimate()
    {
        playerAnimation.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        playerAnimation.SetBool("Etkilesim", tersgravitykodu.girdimi);
    }






    /* public void tershareketv2()
     {
         if (Input.GetKey(KeyCode.E))
         {
             altkarakter.tershareket();
             Debug.Log("e ye bastım");
         }


     }
    */



}