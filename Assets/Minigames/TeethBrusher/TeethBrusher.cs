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
<<<<<<< HEAD
        Timer.TimeOut += () =>
        {
            //TODO
            print("LOST");
            SceneManager.LoadScene(2);
        };
=======
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
>>>>>>> Rod
    }

    public void RemoveStain(GameObject stain)
    {
        teeth.Remove(stain);
        if (teeth.Count == 0)
        {
<<<<<<< HEAD
            //TODO
            SceneManager.LoadScene(2);
=======
            Timer.Instance.StopTimer();
            audioSource.clip = winAudio;
            audioSource.Play();
            StartCoroutine(WaitUntilAudioIsOver());
>>>>>>> Rod
        }
    }

    IEnumerator WaitUntilAudioIsOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length * 1.3f);
        SceneManager.LoadScene("Map");
      
    }
}