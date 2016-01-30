using UnityEngine;
using System.Collections;

public class TapDetect : MonoBehaviour
{
	void OnMouseDown()
    {
        Debug.Log(Input.mousePosition);
        Debug.Log(transform.parent);
        transform.parent.SendMessage("CheckTappedTag", transform.tag);
    }
}
