using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class ShowPlanes : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public ARPointCloudManager PointCloudManager;
    public Toggle toggle;

    public void OnValueChaged(){
        
        VizualizePlanes(toggle.isOn);
        VizualizePoints(toggle.isOn);
    }
    void VizualizePlanes(bool active){
        planeManager.enabled = active;
        foreach(ARPlane plane in planeManager.trackables){
            plane.gameObject.SetActive(active);
        }
    }
    void VizualizePoints(bool active){
        PointCloudManager.enabled = active;
        foreach(ARPointCloud point in PointCloudManager.trackables){
            point.gameObject.SetActive(active);
        }
    }
}
