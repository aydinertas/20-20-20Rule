using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Controller : MonoBehaviour
{
    [SerializeField] TMP_Text startTimetext, passingTimeText;

    private DateTime startTime, nowTime;
    private bool isStarted;

    private float _Minute, _second;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    [SerializeField] GameObject startButton,resetButton;
    private void Awake()
    {
        startButton.SetActive(true);
        resetButton.SetActive(false);
    }
    public void StartButton()
    {
        resetButton.SetActive(true);
        startButton.SetActive(false);
        nowTime = DateTime.Now;
        startTime = nowTime;
        isStarted = true;
       
        startTimetext.text = "Start Time : " + nowTime.ToString("HH:mm:ss");
        InvokeRepeating("Timer", 0f, 1f);
    }

    public void Timer()
    {
        _second= DateTime.Now.Second-startTime.Second;
        _Minute= DateTime.Now.Minute-startTime.Minute;        
        TimeSpan _time = startTime - DateTime.Now;
       
        passingTimeText.text = "Elapsed Time : " + Mathf.Abs(_time.Hours) + ":"+ Mathf.Abs(_time.Minutes) + ":"+Mathf.Abs(_time.Seconds);


        if (Mathf.Abs(_time.Minutes)==30)
        {
            isStarted = false;

            if (clip!=null)
            {
                audioSource.PlayOneShot(clip, 1f);
            }
           
            CancelInvoke();
        }
    }



    public void ResetButton()
    {
        CancelInvoke();
        startButton.SetActive(true);
        startTimetext.text = "Start Time : ";
        passingTimeText.text = "Elapsed Time : ";
        resetButton.SetActive(false);
    }
}
