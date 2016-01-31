using UnityEngine;
using System.Collections;
using StyloGestures;
using UnityEngine.UI;

public class Touched : MonoBehaviour
{
    private GameObject randomizer;
    public bool coolIngredient;

    void Awake()
    {
        randomizer = GameObject.Find("Randomizer");
    }

    void OnMouseDown()
    {
        
        if (coolIngredient)
        {
            Debug.Log("DELICIOUS!");
            randomizer.SendMessage("Win");
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("GUACALA!");
            randomizer.SendMessage("Lose");
            GetComponent<AudioSource>().Play();
        }
    }

}

