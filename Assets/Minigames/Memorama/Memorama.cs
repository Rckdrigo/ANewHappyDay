using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct ColorMemorama
{
    public int id;
    public Sprite sprite;
}

public class Memorama : MonoBehaviour
{
    public Transform line0, line1, line2;
    public List<ColorMemorama> cards;
    public Sprite backside;

    public static int currentCardsFaceUpCount;
    static List<MemoramaCard> currentCardsFaceUp;

    public AudioClip winAudio, loseAudio;
    AudioSource audioSource;

    public static Memorama Instance;

    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();

        currentCardsFaceUp = new List<MemoramaCard>();

        for (int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, cards.Count);
            line0.GetChild(i).GetComponent<MemoramaCard>().COLOR = cards[r];
            line0.GetChild(i).GetComponent<MemoramaCard>().backside = backside;
            cards.RemoveAt(r);
        }

        for (int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, cards.Count);
            line1.GetChild(i).GetComponent<MemoramaCard>().COLOR = cards[r];
            line1.GetChild(i).GetComponent<MemoramaCard>().backside = backside;
            cards.RemoveAt(r);
        }

        for (int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, cards.Count);
            line2.GetChild(i).GetComponent<MemoramaCard>().COLOR = cards[r];
            line2.GetChild(i).GetComponent<MemoramaCard>().backside = backside;
            cards.RemoveAt(r);
        }

        Timer.TimeOut += OnTimeOut;
    }


    void OnTimeOut()
    {
        currentCardsFaceUpCount = 0;
        audioSource.clip = loseAudio;
        audioSource.Play();
        StartCoroutine(WaitUntilAudioIsOver());
    }

    public void CheckIfCorrect(MemoramaCard card)
    {
        currentCardsFaceUpCount++;
        currentCardsFaceUp.Add(card);
        if (currentCardsFaceUpCount == 2)
        {
            if (currentCardsFaceUp[0].COLOR.id == currentCardsFaceUp[1].COLOR.id)
            {
                audioSource.clip = winAudio;
                audioSource.Play();
                Timer.Instance.StopTimer();
                currentCardsFaceUpCount = 0;
                StartCoroutine(WaitUntilAudioIsOver());
                return;
            }
            else
            {
                currentCardsFaceUpCount = 0;
                currentCardsFaceUp[0].HideCard();
                currentCardsFaceUp[1].HideCard();
            }
            currentCardsFaceUp.Clear();
        }
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }

    IEnumerator WaitUntilAudioIsOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length * 1.3f);
        currentCardsFaceUp.Clear();
        SceneManager.LoadScene("Minimap");
      
    }
}
