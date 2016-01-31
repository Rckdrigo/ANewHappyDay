using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {

    private bool clickable = true;
    private int level = 0;

	void ToggleClick()
    {
        Debug.Log("Toggle Off:" + gameObject.name);
        clickable = false;
    }

    void OnMouseDown()
    {
        if (gameObject.name.Equals("Return"))
        {
            StartCoroutine(ResetGame());
        }

        if (clickable)
        {
            gameObject.transform.parent.BroadcastMessage("ToggleClick");

            Debug.Log("Toggle On:" + gameObject.name);

            if (gameObject.name.Equals("Bedroom"))
            {
                level = 3;
            }
            if (gameObject.name.Equals("Bathroom"))
            {
                level = 4;
            }
            if (gameObject.name.Equals("Kitchen"))
            {
                level = 5;
            }
            if (gameObject.name.Equals("LivingRoom"))
            {
                level = 6;
            }
            if (gameObject.name.Equals("Closet"))
            {
                level = 7;
            }
        }

        StartCoroutine(LoadLevel());        
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        ToggleClick();
        SceneManager.LoadScene(level);
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2);
        ToggleClick();
        SceneManager.LoadScene(0);
    }
}
