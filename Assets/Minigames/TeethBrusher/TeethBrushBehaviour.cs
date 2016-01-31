using UnityEngine;
using System.Collections;
using StyloGestures;

public class TeethBrushBehaviour : DragGesture
{

    public override void OnDragDetected(Vector2 actualPosition, Vector2 actualDirection)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(actualPosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        if (actualDirection == Vector2.zero)
        {
            GetComponent<AudioSource>().Pause();
        }
        else
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().time = 0.2f;
                GetComponent<AudioSource>().Play();
            }
                
        }
    }
}
