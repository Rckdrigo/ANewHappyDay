using UnityEngine;
using System.Collections;
using StyloGestures;
using UnityEngine.UI;

public class Touched : MonoBehaviour {

	public bool isWin;
	// Use this for initialization
	void Start () {
		}
		


	void Update()
	{

	}
	void OnMouseDown()
	{
		if (isWin == true) {
			isWinner ();
		} else {
			isLosser ();
		}
		Debug.Log ("Esta Tocandome D:!!!" + name);
	}
	// Update is called once per frame

	public void isWinner()
	{
	}
	public void isLosser()
	{
	}
 }

