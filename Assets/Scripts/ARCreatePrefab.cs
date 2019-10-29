using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ARCreatePrefab : MonoBehaviour
{
    [SerializeField] private GameObject environmentPrefab;
    [SerializeField] private ARRaycastManager arRayManager;

    private void Update()
    {
        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(0);
        var hitList = new List<ARRaycastHit>();

        if (!arRayManager.Raycast(touch.position, hitList,
            UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon)) return;
        var obj = Instantiate(environmentPrefab);
        obj.transform.position = hitList[0].pose.position;
    }
}