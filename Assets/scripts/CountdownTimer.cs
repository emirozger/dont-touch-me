using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    float CurrentTime = 0f;
    float StartingTime = 250f;
    public Text countdowntext;
    public GameObject losers;

    void Start()
    {
        CurrentTime = StartingTime;

    }


    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        //Debug.Log(CurrentTime);
        countdowntext.text = CurrentTime.ToString();

        if (CurrentTime <= 0)
        {
            // saniye 0 a gelince başlangıça dönüp bidaha sayıyor
            //CurrentTime = StartingTime;
            losers.SetActive(true);
            CurrentTime = 0;

            Time.timeScale = 0f;
            losers.SetActive(true);
        }


    }
}
