using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TeethBrusher : MonoBehaviour
{
    public List<GameObject> teeth;
    public static TeethBrusher Instance;

    public AudioClip winAudio, loseAudio;
    AudioSource audioSource;

    void Start()
    {
        Instance = this;
        Timer.TimeOut += OnTimeOut;
        audioSource = GetComponent<AudioSource>();
    }

    void OnTimeOut()
    {
        audioSource.clip = loseAudio;
        audioSource.Play();
        StartCoroutine(WaitUntilAudioIsOver());
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }

    public void RemoveStain(GameObject stain)
    {
        teeth.Remove(stain);
        if (teeth.Count == 0)
        {
            Timer.Instance.StopTimer();
            audioSource.clip = winAudio;
            audioSource.Play();
            StartCoroutine(WaitUntilAudioIsOver());
        }
    }

    IEnumerator WaitUntilAudioIsOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length * 1.3f);
        SceneManager.LoadScene("Map");
      
    }
}