using UnityEngine;
using System.Collections;

public class DirtSpotBehaviour : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Timer.TimeOut += OnTimeOut;
    }

    void OnTimeOut()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }

    void OnMouseOver()
    {
        sprite.color -= new Color(0, 0, 0, 0.2f);
        if (sprite.color.a <= 0)
        {
            TeethBrusher.Instance.RemoveStain(gameObject);
            Destroy(gameObject);
        }

    }
}
