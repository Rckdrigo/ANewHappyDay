using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Invocation : MonoBehaviour
{
    public AudioMixerSnapshot demonic;
    public GameObject penthagram, demon;

    void Start()
    {
        if (MiniGameManager.AllMinigamePassed())
        {
            InitRitual();
        }
    }

    void InitRitual()
    {
        demonic.TransitionTo(2);
        StartCoroutine(ActivateDemon());
    }

    IEnumerator ActivateDemon()
    {
        penthagram.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        demon.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitRitual();
        }
    }
}
