using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour
{
    [SerializeField]GameObject dialogueBox;
    [SerializeField]TextMeshProUGUI dialogueText;

    [SerializeField]GameObject announceBox;
    [SerializeField]TextMeshProUGUI announceText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
       
    }

    //Function to print stuff to the screen
    //Returns true when it is done
    public bool PrintDialogue(string text, float duration) {
        dialogueBox.SetActive(true); 
        dialogueText.text = text;
        bool status = false;

        //if (Input.anyKeyDown) {
        //    dialogueBox.SetActive(false);
        //    dialogueText.text = "";
        //    return true;
        //}

        StartCoroutine(DialogueBoxTimer(duration, status));

        return status;
    }

    public bool PrintAnnouncement(string text, float duration) {
        announceBox.SetActive(true);
        announceText.text = text;
        bool status = false;
        
        //if (Input.anyKeyDown) {
        //    announceBox.SetActive(false);
        //    announceText.text = "";
        //    return true;
        //}

        StartCoroutine(AnnouncementBoxTimer(duration, status));

        return status;
    }

    IEnumerator DialogueBoxTimer(float duration, bool status) {
        yield return new WaitForSeconds(duration);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        status = true;
    }

    IEnumerator AnnouncementBoxTimer(float duration, bool status) {
        yield return new WaitForSeconds(duration);
        announceBox.SetActive(false);
        announceText.text = "";
        status = true;
    }
}
