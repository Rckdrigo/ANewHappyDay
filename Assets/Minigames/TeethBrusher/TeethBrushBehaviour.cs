using UnityEngine;
using System.Collections;
using StyloGestures;

public class TeethBrushBehaviour : DragGesture
{

	public override void OnDragDetected (Vector2 actualPosition, Vector2 actualDirection)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint (actualPosition);
		transform.position = new Vector3 (pos.x, pos.y, 0);
	}
}
