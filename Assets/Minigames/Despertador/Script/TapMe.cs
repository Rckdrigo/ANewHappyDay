using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TapMe : MonoBehaviour
{
    private Vector3 spawnPosition = new Vector3(-4, 0, 0);
    public GameObject[] tapObjects;
    public GameObject[] tapOrder;

    private string tapToTag;

    void Awake()
    {
        spawnPosition.z = transform.position.z;
        Shuffle();
        Initialize();
      
       
        GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        //Debug.Log("Tag to Tap: " + tapToTag);

        Timer.TimeOut += OnTimeOut;
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
            //Debug.Log("WINNER");
            //Time.timeScale = 0;
            Timer.Instance.StopTimer();
            transform.parent.BroadcastMessage("WakeUp");            
        }
        else
        {
            CloseLids();
        }
    }

    void CloseLids()
    {
        //Debug.Log("TO DO");
        transform.parent.BroadcastMessage("Die");
    }

    public static void FinishedAnimation()
    {
        SceneManager.LoadScene("Map");   
    }
}
