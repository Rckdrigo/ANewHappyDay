using UnityEngine;
using System.Collections;
using StyloGestures;

public class Slippers : DragGesture
{
    RaycastHit2D hit;
    static int score = 0;

    public GameObject[] feet, slippers;

    public static void AddPoint()
    {
        score++;
        if (score == 2)
            print("Ganaste");
    }

    public override void OnDragDetected(Vector2 actualPosition, Vector2 actualDirection)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(actualPosition);
        Collider2D temp = Physics2D.OverlapCircle(point, 0.5f);
        if (temp != null)
        if (temp.tag.Equals("Slipper"))
        {
            temp.transform.position = new Vector3(temp.transform.position.x, point.y, 0);
            if (temp.transform.position.y <= -5)
                temp.enabled = false;
        }
    }


}
