using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite beforeFlag;
    public Sprite afterFlag;
    public SpriteRenderer spriteRenderer;
    public bool checkPointReached = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.sprite = afterFlag;
            checkPointReached = true;
        }
    }
}
