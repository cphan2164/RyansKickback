using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//programmed this whole file

public class ColliderTrig : MonoBehaviour
{
    public DialogueTrigger trigger;
    private GameObject gM;
    private CameraManager cM;
    private GameObject ryan;

    void Start()
    {
        ryan = GameObject.Find("RYAN");
        gM = GameObject.Find("GameManager");
        cM = gM.GetComponent<CameraManager>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
        }
    }

    private IEnumerator RyanStandby()
    {
        while (true)
        {
            Debug.Log("waiting for ryan");
            yield return new WaitForSeconds(6.0f);
            cM.Show(cM.doorview);
            Debug.Log("ryan appears. exiting");
            yield return new WaitForSeconds(5.0f);
            cM.Hide();
            SceneManager.LoadScene("Rhythm Game Part");
            yield break;
        }
    }

    private IEnumerator CameraTimeout(float x)
    {
        while (true)
        {

            Debug.Log("waiting for timer");
            yield return new WaitForSeconds(x);
            cM.Hide();
            Debug.Log("done waiting. exiting");
            StartCoroutine("RyanStandby");
            yield break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "hidecam")
        {
            cM.Hide();
        }
        if (gameObject.tag == "pillcam")
        {
            cM.Show(cM.pillview);
            StartCoroutine("CameraTimeout", 3.5f);
        }
    }
}
