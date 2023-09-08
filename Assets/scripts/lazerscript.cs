using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerscript : MonoBehaviour
{

    public GameObject character;
    Checkpoint checkpoint;
    public Vector3 startPoint;
    CharacterController mainchar;
    Vector3 respawnpoint;
    public GameObject losecanvas;

    //karakter kontrollera public gameobject lazer ekle lazeri koy lazerle etkileşime geçerse transform.positonu respawnpointe eşitle.
    private void Start()
    {
        FindObjectOfType<Checkpoint>();
        FindObjectOfType<CharacterController>();
        respawnpoint = character.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("karakteron"))
        {
            Time.timeScale = 0;
            losecanvas.SetActive(true);

        }


        if (collision.CompareTag("karakterarka"))
        {
            Destroy(this.gameObject);
        }
    }



}
