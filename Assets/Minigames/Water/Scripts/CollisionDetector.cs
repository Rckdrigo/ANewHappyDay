using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
    public GameObject splashGO;
    private GameObject splash;
    [Range(3f,5f)]
    public float segundos;
    private float startTime;
    public bool streaming = false;

    void Awake()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (streaming)
        {
            if ((Time.time - startTime) > segundos )
            {
                Win();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Water")
        {
            startTime = Time.time;
            streaming = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Water")
        {
            Die();
        }
    }

    void Die()
    {
        GameObject.Find("tapper").SendMessage("Die");
    }

    void Win()
    {
        GameObject.Find("tapper").SendMessage("Win");
    }

    IEnumerator Contar()
    {
        yield return new WaitForSeconds(1);
        segundos -= 1f;
    }
}
