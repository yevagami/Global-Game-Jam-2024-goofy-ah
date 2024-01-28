using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenuButtons : MonoBehaviour
{
    public Canvas pauseCanvas;



    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            pauseCanvas.gameObject.SetActive(true);
        }
    }

    public void ReturnToTheGameCallback() {
       
        if (pauseCanvas.enabled){
            pauseCanvas.gameObject.SetActive(false);
        }

    }
    public void quitGameCallback() {
        SceneManager.LoadScene("Main Menu");
    }

}
