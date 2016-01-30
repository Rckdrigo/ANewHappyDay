using UnityEngine;
using System.Collections;

public class FootBehaviour : MonoBehaviour
{
    public bool rightFoot;
    float min, max;
    int dir;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Contains(name))
        {
            GetComponent<Animator>().Stop();
            Slippers.AddPoint();
            GetComponent<Collider2D>().enabled = false;
            collider.enabled = false;
            StartCoroutine(AlignWithSlipper(collider.transform.position.x));
        }
    }

    IEnumerator AlignWithSlipper(float x)
    {
        while (transform.position.x != x)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(x, transform.position.y, 0), Time.deltaTime * 3);
            yield return null;
        }
    }
}
