using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActionScript : MonoBehaviour
{
    private GameObject start;
    private GameObject sound;
    private GameObject cancel;
    private GameObject exit;

    void Awake()
    {
        start = GameObject.Find("Start");
        sound = GameObject.Find("Sound");
        exit = GameObject.Find("Exit");
    }

    void Click()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name);

        if (gameObject.name.Equals("play"))
        {
            StartCoroutine(StartGame());
        }
        if (gameObject.name.Equals("audio"))
        {
            StartCoroutine(ToggleSound());
        }
        if (gameObject.name.Equals("exit"))
        {
            StartCoroutine(ExitGame());
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(2);
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }

    IEnumerator ToggleSound()
    {
        Debug.Log("TO DO");
        yield return new WaitForSeconds(0.2f);
    }
}
