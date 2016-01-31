using UnityEngine;
using System.Collections;

public class Randomize : MonoBehaviour {
	public GameObject Ingredient;
	public int ActualIngredient;
	public GameObject[] HiddenIngredients;
	public int tiempoActivo, tiempoInactivo;
	public GameObject Amarillo, Azul, Verde, Morado;

	// Use this for initialization
	void Start () {
		tiempoActivo = 0;

		StartCoroutine (RandomIng());
	//	StartCoroutine (HideIng());
		//gameObject.SetActive (false);

	}

	public void AsignarActivo(int activo){
		
		switch (activo) 
		{ 
		case 1:
			Ingredient = Amarillo;
			Amarillo.SetActive (true);
			Verde.SetActive (false);
			Azul.SetActive (false);
			Morado.SetActive (false);

			break;
		case 2:
			Ingredient = Verde;
			Amarillo.SetActive (false);
			Verde.SetActive (true);
			Azul.SetActive (false);
			Morado.SetActive (false);

			break;
		case 3:
			Ingredient = Azul;
			Amarillo.SetActive (false);
			Verde.SetActive (false);
			Azul.SetActive (true);
			Morado.SetActive (false);

			break;
		case 4:
			Ingredient = Morado;
			Amarillo.SetActive (false);
			Verde.SetActive (false);
			Azul.SetActive (false);
			Morado.SetActive (true);
				break;

			default :
			Amarillo.SetActive (false);
			Verde.SetActive (false);
			Azul.SetActive (false);
			Morado.SetActive (false);
			break;
		}
		;


	}

	IEnumerator RandomIng(){
		
	
		ActualIngredient = Random.Range (1, 10);
		Debug.Log ("El numero Random fue " + ActualIngredient);
		//Ingredient.SetActive (true);
		AsignarActivo (ActualIngredient);
		yield return new WaitForSeconds (.5f);
		StartCoroutine (RandomIng ());






	}


	IEnumerator HideIng()
	{
		while(tiempoInactivo < 10)
		{
		Ingredient = GameObject.FindGameObjectWithTag ("Activo");
		Ingredient.tag = "Hidden";
		//Ingredient.SetActive (false);	
		tiempoInactivo+=1;
		yield return new WaitForEndOfFrame();
		}
		tiempoInactivo = 0;
		yield return new WaitForSeconds(5f);

	}

	// Update is called once per frame

	void Update () 
		{
		
		//RandomIng ();
		//HideIng ();	

		}

	}

