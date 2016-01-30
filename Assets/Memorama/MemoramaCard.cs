using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MemoramaCard : MonoBehaviour
{
	[System.NonSerialized] public Sprite backside;
	ColorMemorama _color;
	Image image;

	public ColorMemorama COLOR { 
		set { 
			_color = value;
			image.sprite = _color.sprite;
			StartCoroutine (FirstFlipCard ());
		} 
		get { return _color; }
	}


	void Awake ()
	{
		image = GetComponent<Image> ();
	}

	IEnumerator FirstFlipCard ()
	{
		yield return new WaitForSeconds (0.5f);
		image.sprite = backside;
		GetComponent<Button> ().interactable = true;
	}

	public void HideCard ()
	{
		image.sprite = backside;
		GetComponent<Button> ().interactable = true;
	}

	public void FlipCard ()
	{
		if (Memorama.currentCardsFaceUpCount < 2) {
			image.sprite = _color.sprite;
			GetComponent<Button> ().interactable = false;
			StartCoroutine (SendInfo ());
		}
	}

	IEnumerator SendInfo ()
	{
		yield return new WaitForSeconds (0.25f);
		Memorama.CheckIfCorrect (this);
	}


}
