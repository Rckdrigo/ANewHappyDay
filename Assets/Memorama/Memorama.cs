using UnityEngine;
using UnityEngine.UI;
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

	MemoramaCard[,] memorama;

	public static int currentCardsFaceUpCount;
	static List<MemoramaCard> currentCardsFaceUp;

	void Start ()
	{
		memorama = new MemoramaCard[3, 3];
		currentCardsFaceUp = new List<MemoramaCard> ();

		for (int i = 0; i < 3; i++) {
			memorama [0, i] = line0.GetChild (i).GetComponent<MemoramaCard> ();
			int r = Random.Range (0, cards.Count);
			line0.GetChild (i).GetComponent<MemoramaCard> ().COLOR = cards [r];
			line0.GetChild (i).GetComponent<MemoramaCard> ().backside = backside;
			cards.RemoveAt (r);
		}

		for (int i = 0; i < 3; i++) {
			memorama [1, i] = line1.GetChild (i).GetComponent<MemoramaCard> ();
			int r = Random.Range (0, cards.Count);
			line1.GetChild (i).GetComponent<MemoramaCard> ().COLOR = cards [r];
			line1.GetChild (i).GetComponent<MemoramaCard> ().backside = backside;
			cards.RemoveAt (r);
		}

		for (int i = 0; i < 3; i++) {
			memorama [2, i] = line2.GetChild (i).GetComponent<MemoramaCard> ();
			int r = Random.Range (0, cards.Count);
			line2.GetChild (i).GetComponent<MemoramaCard> ().COLOR = cards [r];
			line2.GetChild (i).GetComponent<MemoramaCard> ().backside = backside;
			cards.RemoveAt (r);
		}
	}

	public static void CheckIfCorrect (MemoramaCard card)
	{
		currentCardsFaceUpCount++;
		currentCardsFaceUp.Add (card);
		if (currentCardsFaceUpCount == 2) {
			if (currentCardsFaceUp [0].COLOR.id == currentCardsFaceUp [1].COLOR.id) {
				print ("GANASTE");
				return;
			} else {
				currentCardsFaceUpCount = 0;
				currentCardsFaceUp [0].HideCard ();
				currentCardsFaceUp [1].HideCard ();
			}
			currentCardsFaceUp.Clear ();
		}
	}
}
