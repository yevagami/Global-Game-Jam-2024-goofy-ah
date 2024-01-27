using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenuButtons : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas inGameCanvas;

    public void ReturnToTheGameCallback() {
       
        if (pauseCanvas.enabled)
        {
            pauseCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(true);
        }

    }
    public void quitGameCallback() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
        Application.Quit();
        #endif
    }

}
