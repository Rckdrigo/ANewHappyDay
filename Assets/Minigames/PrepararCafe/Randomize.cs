using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Randomize : MonoBehaviour
{
    public GameObject Ingredient;
    public int ActualIngredient;
    private GameObject[] HiddenIngredients;
    public int tiempoActivo, tiempoInactivo;
    public GameObject Amarillo, Azul, Verde, Morado;
    private Vector3 placeholder;
    private List<GameObject> allIngredients;
    [Range(1, 3)]
    public int ingredientes;

    public AudioClip winAudio, loseAudio;
    private AudioSource audioSource;

    void Awake()
    {
        allIngredients = new List<GameObject>();
        allIngredients.Add(Amarillo);
        allIngredients.Add(Azul);
        allIngredients.Add(Verde);
        allIngredients.Add(Morado);

        foreach (GameObject go in allIngredients)
        {
            go.SetActive(false);
        }
    }

    void Start()
    {
        tiempoActivo = 0;
        StartCoroutine("RandomIng");
        audioSource = GetComponent<AudioSource>();
        Timer.TimeOut += OnTimeOut;
    }


    void OnTimeOut()
    {
        Lose();
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }


    public void AsignarActivo(int activo)
    {
        switch (activo)
        {
            case 1:
                Toggle(Amarillo);
                break;
            case 2:
                Toggle(Azul);
                break;
            case 3:
                Toggle(Morado);
                break;
            case 4:
                Toggle(Verde);
                break;
        }
    }

    void Toggle(GameObject toggleActive)
    {
        foreach (GameObject go in allIngredients)
        {
            if (toggleActive.name.Equals(go.name))
            {
                go.SetActive(true);
                go.transform.position = SelectPlace();
            }
            else
            {
                go.SetActive(false);
            }
        }
    }

    IEnumerator RandomIng()
    {
        ActualIngredient = Random.Range(1, 8);        
        AsignarActivo(ActualIngredient);
        yield return new WaitForSeconds(.5f);
        StartCoroutine("RandomIng");
    }


    IEnumerator HideIng()
    {
        while (tiempoInactivo < 10)
        {
            Ingredient = GameObject.FindGameObjectWithTag("Activo");
            Ingredient.tag = "Hidden";
            tiempoInactivo += 1;
            yield return new WaitForEndOfFrame();
        }
        tiempoInactivo = 0;
        yield return new WaitForSeconds(5f);

    }

    public Vector3 SelectPlace()
    {
        int random = Random.Range(0, 3);
        Vector3 randomPos = Vector3.zero;

        switch (random)
        {
            case 0:
                randomPos = Azul.transform.position;
                break;
            case 1:
                randomPos = Amarillo.transform.position;
                break;
            case 2:
                randomPos = Verde.transform.position;
                break;
            case 3:
                randomPos = Morado.transform.position;
                break;
        }

        return randomPos;
    }

    void Win()
    {
        StopCoroutine("RandomIng");
        MiniGameManager.ActivateCoffee();
        audioSource.clip = winAudio;
        audioSource.Play();
        Timer.Instance.StopTimer();
        StartCoroutine(WaitUntilAudioIsOver());
    }

    void Lose()
    {
        StopCoroutine("RandomIng");
        audioSource.clip = loseAudio;
        audioSource.Play();
        StartCoroutine(WaitUntilAudioIsOver());
    }

    IEnumerator WaitUntilAudioIsOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length * 1.2f);
        SceneManager.LoadScene("Minimap");
    }


}

