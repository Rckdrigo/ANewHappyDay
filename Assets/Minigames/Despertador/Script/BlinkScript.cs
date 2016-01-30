using UnityEngine;
using System.Collections;

public class BlinkScript : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    [Range(-1,1)]
    public int direction;
    [Range(1f,3f)]
    public float blinkSpeed;
    private bool awake;
    private bool dead;

    void Awake()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, 4 * direction, 0);
        blinkSpeed *= 3;
        awake = false;
        dead = false;
    }

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (!awake)
            {
                float y = startPosition.y + (Mathf.PingPong(Time.time * blinkSpeed, 4) * direction);
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
            else
            {
                OpenLid();
            }
        }
        else
        {
            CloseLid();
        }
    }

    void Die()
    {
        dead = true;
    }

    void WakeUp()
    {
        awake = true;
    }

    void OpenLid()
    {
        transform.position = Vector3.Lerp(transform.position, endPosition, Time.fixedDeltaTime);
    }

    void CloseLid()
    {
        transform.position = Vector3.Lerp(transform.position, startPosition, Time.fixedDeltaTime);
    }
}
