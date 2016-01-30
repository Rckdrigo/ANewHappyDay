using UnityEngine;
using System.Collections;

public class DirtSpotBehaviour : MonoBehaviour
{

	SpriteRenderer sprite;

	void Start ()
	{
		sprite = GetComponent<SpriteRenderer> ();
	}

	void OnMouseOver ()
	{
		print ("ACA");
		sprite.color -= new Color (0, 0, 0, 0.2f);
		if (sprite.color.a <= 0) {
			TeethBrusher.Instance.RemoveStain (gameObject);
			Destroy (gameObject);
		}

	}
}
