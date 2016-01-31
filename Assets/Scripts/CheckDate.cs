using UnityEngine;
using System.Collections;
using System;

public class CheckDate : MonoBehaviour
{

    public static CheckDate checkDate;

    void Start()
    {
        if (!PlayerPrefs.HasKey("ContinuousDay"))
            PlayerPrefs.SetInt("ContinuousDay", 0);
    }

    public void SetTodayData()
    {
        int i = PlayerPrefs.GetInt("ContinuousDay");
        if (PlayerPrefs.GetFloat("LastDayPlayed") != (float)DateTime.Today.ToOADate())
        {
            if (CheckIfContinuousDay())
            {
                i++;
                if (i == 7)
                {
                    //TODO
                    print("INVOCAR EL DEMONIO");
                    PlayerPrefs.SetInt("ContinuousDay", 0);
                }
                else
                    PlayerPrefs.SetInt("ContinuousDay", i);
            }
            else
            {
                PlayerPrefs.SetInt("ContinuousDay", 0);
            }


            float today = (float)DateTime.Today.ToOADate();

            PlayerPrefs.SetFloat("LastDayPlayed", today);
            PlayerPrefs.Save();
        }

    }


    public bool CheckIfContinuousDay()
    {
        double lastDayPlayed = (double)PlayerPrefs.GetFloat("LastDayPlayed");
       
        if (DateTime.FromOADate(lastDayPlayed).AddDays(1).Equals(DateTime.Today))
            return true;
        return false;
    }


}
