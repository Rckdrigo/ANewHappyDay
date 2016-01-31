using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
    public GameObject splashGO;
    private GameObject splash;
    public static bool streaming = false;

    public static CollisionDetector Instance;

    public AudioMixerSnapshot normal, lowPassFilter;

    void Start()
    {
        Instance = this;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        print("GOOD");
        if (collider.transform.tag == "Water")
        {
            streaming = true;
            lowPassFilter.TransitionTo(0.01f);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Water")
        {
            streaming = false;
            normal.TransitionTo(0.01f);
        }
    }

}
