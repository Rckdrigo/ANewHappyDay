using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TeethBrusher : MonoBehaviour
{
    public List<GameObject> teeth;
    public static TeethBrusher Instance;

    void Start()
    {
        Instance = this;
        Timer.TimeOut += () =>
        {
            //TODO
            print("LOST");
            SceneManager.LoadScene("Map");
        };
    }

    public void RemoveStain(GameObject stain)
    {
        teeth.Remove(stain);
        if (teeth.Count == 0)
        {
            //TODO
            SceneManager.LoadScene("Map");
        }
    }
}