using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//programmed this whole file

public class CameraManager : MonoBehaviour
{
    private Transform cameraTransform;
    public GameObject pillview;
    public GameObject doorview;
    public GameObject viewer;
    private GameObject active;

    // Start is called before the first frame update
    private void Start()
    {
        viewer = GameObject.Find("Viewer");
        doorview = GameObject.Find("DoorPOV");
        pillview = GameObject.Find("PillPOV");
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Show(GameObject active)
    {
        active.SetActive(true);
        viewer.SetActive(true);

    }

    public void Hide()
    {
        viewer.SetActive(false);
        pillview.SetActive(false);
        doorview.SetActive(false);
    }
}