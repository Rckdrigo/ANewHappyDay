using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TapMe : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(-4, 0, 0);
    public GameObject[] tapObjects;
    public GameObject[] tapOrder;

    public AudioClip winAudio, loseAudio;

    private string tapToTag;
    private AudioSource audioSource;

    void Awake()
    {
        spawnPosition.z = transform.position.z;
        Shuffle();
        Initialize();
      
    }

    void Start()
    {
        Timer.TimeOut += OnTimeOut;
        audioSource = GetComponent<AudioSource>();
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }

    void OnTimeOut()
    {
        CloseLids();
    }

    void Shuffle()
    {
        Randomizer.Randomize<GameObject>(tapObjects);
        tapToTag = tapObjects[Random.Range(0, tapObjects.Length)].name;
    }

    void Initialize()
    {
        tapOrder = new GameObject[tapObjects.Length];

        for (int i = 0; i < tapObjects.Length; i++)
        {
            tapOrder[i] = (GameObject)Instantiate(tapObjects[i], spawnPosition, Quaternion.Euler(Vector3.one));
            tapOrder[i].transform.parent = gameObject.transform;
            tapOrder[i].tag = tapObjects[i].name;
            tapOrder[i].AddComponent<TapDetect>();
            spawnPosition.x += 4;

            if (tapOrder[i].tag.Equals(tapToTag))
                tapOrder[i].GetComponent<AudioSource>().Play();
        }
    }

    void CheckTappedTag(string tappedTag)
    {
        if (tappedTag.ToString().Equals(tapToTag))
        {
            audioSource.clip = winAudio;
            audioSource.Play();
            Timer.Instance.StopTimer();
            transform.parent.BroadcastMessage("WakeUp");            
        }
        else
        {
            audioSource.clip = loseAudio;
            audioSource.Play();
            Timer.Instance.StopTimer();
            CloseLids();
        }
    }

    void CloseLids()
    {
        transform.parent.BroadcastMessage("Die");
    }

    public static void FinishedAnimation()
    {
        SceneManager.LoadScene(2);   
    }
}
