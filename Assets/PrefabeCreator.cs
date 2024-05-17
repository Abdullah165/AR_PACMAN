using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabeCreator : MonoBehaviour
{ 
    public GameObject pacmanPlanePerfab;
    public Vector3 prefabOffset;

    private GameObject pacmanPlane;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += ARTrackedImageManager_trackedImagesChanged;
    }

    private void ARTrackedImageManager_trackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            pacmanPlane = Instantiate(pacmanPlanePerfab, image.transform);

            pacmanPlane.transform.position += prefabOffset;
        }
    }

}
