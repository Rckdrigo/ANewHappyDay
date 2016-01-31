using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Timer : MonoBehaviour
{
    public float maxTime = 5;
    float time = 0;
    Image image;

    public static Timer Instance;

    public delegate void TimerEvents();

    public static event TimerEvents TimeOut;

    public void StopTimer()
    {
        StopCoroutine("DecreaseTime");
    }

    void Start()
    {
        Instance = this;
        time = maxTime;
        StartCoroutine("DecreaseTime");
        image = GetComponent<Image>();
    }

    IEnumerator DecreaseTime()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        time -= Time.deltaTime;
        image.fillAmount = time / maxTime;
        if (time > 0)
        {
            //print("Timer: " + time);
            StartCoroutine("DecreaseTime");
        }
        else
            try
            {
                TimeOut();
            }
            catch (NullReferenceException)
            {
            }
    }
}
