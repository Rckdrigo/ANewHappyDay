using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MiniGameManager : MonoBehaviour
{

    public static bool wakeUp, coffee, teeth, memo, pee;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Welcome");
    }

    public static void ActivateWakeup()
    {
        wakeUp = true;
    }

    public static void ActivateCoffee()
    {
        coffee = true;
    }

    public static void ActivateTeeth()
    {
        teeth = true;
    }

    public static void ActivateMemo()
    {
        memo = true;
    }

    public static void ActivatePee()
    {
        pee = true;
    }

    public static bool AllMinigamePassed()
    {
        return wakeUp & coffee & teeth & memo & pee & (wakeUp == true);
    }
}
