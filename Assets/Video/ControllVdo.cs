using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class ControllVdo : MonoBehaviour, ITrackableEventHandler
{
    public GameObject videoplayer, Playvideo_button, Pausevideo_button, Stopvideo_button;
    protected TrackableBehaviour mTrackableBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            if (mTrackableBehaviour.TrackableName == "Video_marker")
            {
                videoplayer.GetComponent<VideoPlayer>().Play();
            }
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                  newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            videoplayer.GetComponent<VideoPlayer>().Stop();
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
    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
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
                    videoplayer.GetComponent<VideoPlayer>().Play();
                    Playvideo_button.SetActive(false);
                    Pausevideo_button.SetActive(true);
                    Stopvideo_button.SetActive(true);
                }

                //case 2
                if (hit.collider.tag == "Pausevideo")
                {
                    videoplayer.GetComponent<VideoPlayer>().Pause();
                    Playvideo_button.SetActive(true);
                    Pausevideo_button.SetActive(false);
                    Stopvideo_button.SetActive(true);
                }
                //case 3
                if (hit.collider.tag == "Stopvideo")
                {
                    videoplayer.GetComponent<VideoPlayer>().Stop();
                    Playvideo_button.SetActive(true);
                    Pausevideo_button.SetActive(true);
                    Stopvideo_button.SetActive(false);
                }
            }
        }
    }
}
