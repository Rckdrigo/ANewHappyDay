using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour
{
    private AudioListener audioListener;
    private AudioSource audioSource;
    private bool mute = false;

    void Awake()
    {
        audioListener = gameObject.GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();        
        Debug.Log("TO DO");
        //obtener mute
        audioSource.playOnAwake = !mute;        
    }

    void OnMouseDown()
    {
        StartCoroutine(Toggle());
    }

    IEnumerator Toggle()
    {
        yield return new WaitForSeconds(0.1f);

        if (audioSource.mute == false)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }
}
