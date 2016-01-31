using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaterTap : MonoBehaviour
{
    private Vector3 spawnPosition;
    public GameObject streamGO;
    private GameObject stream;
    private GameObject splat;
    [Range(1f, 10f)]
    public float scale;
    public bool grow;
    public bool finish;

    void Awake()
    {
        spawnPosition = transform.position;
        spawnPosition.z += 1;
    }

    void Start()
    {
        Timer.TimeOut += OnTimeOut;
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }

    void OnTimeOut()
    {
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        ScaleStream();
    }

    void OnMouseDown()
    {
        grow = true;

        if (stream == null)
        {
            stream = (GameObject)Instantiate(streamGO, spawnPosition, Quaternion.Euler(Vector3.one));
        }
    }

    void OnMouseUp()
    {
        grow = false;
    }

    void ScaleStream()
    {
        if (stream != null && !finish)
        {
            float scaleY = stream.transform.localScale.y + (scale * (grow ? 1 : -1));
            Vector3 tmp = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
            stream.transform.localScale = Vector3.Lerp(stream.transform.localScale, tmp, Time.fixedDeltaTime);
            scale += (0.1f * (grow ? 1 : -1));

            if (scaleY < 1f)
            {
                scaleY = 1f;
            }
        }       

        if (finish)
        {
            float scaleY = stream.transform.localScale.y + (scale * (grow ? 1 : -1));
            Vector3 tmp = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);           

            if (scaleY > 0)
            {
                stream.transform.localScale = Vector3.Lerp(stream.transform.localScale, tmp, Time.fixedDeltaTime);
                scale += (0.1f * (grow ? 1 : -1));
            }
        }
    }

    void Win()
    {
        Time.timeScale = 0.5f;
        finish = true;
        SceneManager.LoadScene("Map");
    }

    void Die()
    {
        Debug.Log("TODO");
        Time.timeScale = 0;
        SceneManager.LoadScene("Map");
    }
}
