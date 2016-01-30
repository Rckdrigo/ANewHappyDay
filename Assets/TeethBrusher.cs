using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeethBrusher : MonoBehaviour
{
	public List<GameObject> teeth;
	public static TeethBrusher Instance;

	void Start ()
	{
		Instance = this;
	}

	public void RemoveStain (GameObject stain)
	{
		teeth.Remove (stain);
		if (teeth.Count == 0)
			print ("GANASTE");
	}
}