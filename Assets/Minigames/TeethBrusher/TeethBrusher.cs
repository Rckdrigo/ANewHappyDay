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

    Vector2 dir;

    void Start()
    {
        Instance = this;
        Timer.TimeOut += OnTimeOut;
        audioSource = GetComponent<AudioSource>();

        dir = Random.insideUnitCircle;
        StartCoroutine(Move((Vector2)transform.position + dir * 5));
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
            MiniGameManager.ActivateTeeth();
            audioSource.clip = winAudio;
            audioSource.Play();
            StartCoroutine(WaitUntilAudioIsOver());
        }
    }

    IEnumerator WaitUntilAudioIsOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length * 1.3f);
        SceneManager.LoadScene("Minimap");
      
    }

    IEnumerator Move(Vector2 nextPos)
    {
        for (int i = 0; i < 15; i++)
        {
            transform.position = Vector2.Lerp(transform.position, nextPos, Time.deltaTime * 2);
            yield return null;
        }
        dir = Random.insideUnitCircle;
        StartCoroutine(Move((Vector2)transform.position + dir * 5));
    }
}