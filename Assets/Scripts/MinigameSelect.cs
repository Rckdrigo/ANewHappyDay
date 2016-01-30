using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MinigameSelect : MonoBehaviour
{

    public string scene;

    void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }
}
