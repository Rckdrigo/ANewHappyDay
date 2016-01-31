using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
    public GameObject splashGO;
    private GameObject splash;
    public static bool streaming = false;

    public static CollisionDetector Instance;

    void Start()
    {
        Instance = this;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Water")
        {
            streaming = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Water")
        {
            streaming = false;
        }
    }

}
