using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{

    public float speed;
    public float movement;
    public float jumpSpeed;
    public Rigidbody2D rb2d;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public float CooldownTime = 3;
    private float NextFireTime = 0;
    bool setL = false;
    float timeriki = 0;
    float timer = 0;
    public Animator playerAnimation;
    public Vector3 respawnPoint;
    Checkpoint checkpoint;
    public GameObject winnerekrani;

    public bool dondur = false;

    public bool yeretemasediyormu;




    ustkarakterController ustkarakter;

    void Start()
    {
        Time.timeScale = 1;
        rb2d = GetComponent<Rigidbody2D>();

        ustkarakter = FindObjectOfType<ustkarakterController>();

        playerAnimation = GetComponent<Animator>();

        respawnPoint = transform.position;

        checkpoint = FindObjectOfType<Checkpoint>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Return))
        {
            rb2d.AddForce(Vector2.right * 200);
        }

        #region üste değince 180 derece dönme

        if (this.gameObject.transform.position.y >= -0.9f && !isTouchingGround)
        {
            dondur = true;

        }
        if (dondur)
        {
            //donmeorani += Time.deltaTime;
            transform.rotation = Quaternion.Euler(180f, 0f, 0f);

        }

        if (yeretemasediyormu == true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }



        #endregion
        hareket();
        tershareket();



        timer += Time.deltaTime;

        if (Input.GetKey("l") && timer > 3)
        {
            setL = true;
            timer = 0;
        }
        PlayAndAnimate();





    }

    public void hareket()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal");
        if (setL == false)
        {


            if (Input.GetKey(KeyCode.D))
            {
                rb2d.velocity = new Vector2(speed * movement, rb2d.velocity.y);
                transform.localScale = new Vector2(0.3f, 0.3f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(speed * movement, rb2d.velocity.y);
                transform.localScale = new Vector2(-0.3f, 0.3f);
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);


            }
        }


    }


    public void tershareket()
    {
        if (setL == true)

        {

            isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

            movement = Input.GetAxis("Horizontal");


            if (Input.GetKey(KeyCode.D))
            {

                rb2d.velocity = new Vector2(-speed * movement, rb2d.velocity.y);
                transform.localScale = new Vector2(0.3f, 0.3f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(-speed * movement, rb2d.velocity.y);
                transform.localScale = new Vector2(-0.3f, 0.3f);
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }

            timeriki += Time.deltaTime;

            if (timeriki >= 3)
            {
                timeriki = 0;
                setL = false;
                timer = -2;
            }

        }



    }


    private void PlayAndAnimate()
    {
        playerAnimation.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform.position;
        }

        if (collision.tag == "winner")

        {
            Time.timeScale = 0;
            winnerekrani.SetActive(true);
        }

        if (collision.tag == "ustground")
        {
            yeretemasediyormu = false;
        }
        if (collision.tag == "Ground")
        {
            yeretemasediyormu = true;
        }
    }
}
