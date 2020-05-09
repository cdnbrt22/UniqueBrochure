using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class Controll_Player : MonoBehaviour, ITrackableEventHandler
{
    public GameObject Videoplayer, Playvideo_button, Pausevideo_button, Stopvideo_button;
    public void OnTrackableStateChanged(
   TrackableBehaviour.Status previousStatus,
   TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            Debug.Log("Trackable " + TrackableBehaviour.TrackableName + " found");

            if (TrackableBehaviour.TrackableName == "Video_Maker")
            {
                Videoplayer.GetComponent<VideoPlayer>().Stop();
            }
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                  newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + TrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    protected TrackableBehaviour TrackableBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        TrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (TrackableBehaviour)
        {
            TrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                //case 1
                if (hit.collider.tag == "Playvideo")
                {
                    Videoplayer.GetComponent<VideoPlayer>().Play();
                    Playvideo_button.SetActive(false);
                    Pausevideo_button.SetActive(true);
                    Stopvideo_button.SetActive(true);
                }

                //case 2
                if (hit.collider.tag == "Stopvideo")
                {
                    Videoplayer.GetComponent<VideoPlayer>().Stop();
                    Playvideo_button.SetActive(true);
                    Pausevideo_button.SetActive(true);
                    Stopvideo_button.SetActive(false);
                }
                //case 3
                if (hit.collider.tag == "Pausevideo")
                {
                    Videoplayer.GetComponent<VideoPlayer>().Pause();
                    Playvideo_button.SetActive(true);
                    Pausevideo_button.SetActive(false);
                    Stopvideo_button.SetActive(true);
                }
            }
        }
    }
}
