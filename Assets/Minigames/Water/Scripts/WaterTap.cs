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

    public AudioClip winAudio, loseAudio;
    AudioSource audioSource;

    void Awake()
    {
        spawnPosition = transform.position;
        spawnPosition.z += 1;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Timer.TimeOut += OnTimeOut;
    }

    void OnDestroy()
    {
        Timer.TimeOut -= OnTimeOut;
    }

    void OnTimeOut()
    {
        if (CollisionDetector.streaming)
            Win();
        else
            Die();
    }

    void Update()
    {
        ScaleStream();
    }

    void OnMouseDown()
    {
        if (!finish)
        {
            grow = true;

            if (stream == null)
            {
                stream = (GameObject)Instantiate(streamGO, spawnPosition - (Vector3)Vector2.up * 5, Quaternion.identity);
            }
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
            stream.transform.localScale = new Vector2(0.1f, stream.transform.localScale.y);
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
            stream.transform.localScale = new Vector2(0.1f, stream.transform.localScale.y);
        }

    }

    void Win()
    {
        audioSource.clip = winAudio;
        audioSource.Play();
        finish = true;
        StartCoroutine(WaitUntilAudioIsOver());
    }

    void Die()
    {
        audioSource.clip = loseAudio;
        audioSource.Play();
        StartCoroutine(WaitUntilAudioIsOver());
    }

    IEnumerator WaitUntilAudioIsOver()
    {
        yield return new WaitForSeconds(audioSource.clip.length * 1.2f);
        finish = false;
        SceneManager.LoadScene("Minimap");
    }
}
