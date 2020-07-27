using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArPlaceObjects : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager; //ar session origin
    public GraphicRaycaster raycaster; // canvas
    
    public Toggle toggle;
    public Scrollbar bar;
    public GameObject geniusGameAsset;

    void Start(){
        geniusGameAsset.SetActive(false);
    }
    void Update(){
        PlaceObject();
        SetScale(bar.value);
    }
    public void SetScale(float newScale){
        transform.localScale = Vector3.one * newScale;
    }
    //PLOTAR O OBJETO NO PLANO DETECTADO ULTILIZANDO O TOUCH DO MOUSE E O TOGGLE "SeeXRPlane" COMO VERIFICADORES
    void PlaceObject(){
        if(Input.touchCount > 0 && toggle.isOn){
            geniusGameAsset.SetActive(true);
            if(Input.GetTouch(0).phase == TouchPhase.Moved){
            //CRIA UMA LISTA DE ARRAYCASTS E TRACA RAYCASTS A PARTIR DA POSICAO DO TOUCH ATE ARPLANE
            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            aRRaycastManager.Raycast(Input.GetTouch(0).position, hitPoints,TrackableType.Planes);
            //SE O RAYCAST IDENTIFICAR ALGUM PONTO A POSICAO E A ROTACAO DO OBJETO ATUAL SERA SETADA
            if(hitPoints.Count > 0){
                Pose pose = hitPoints[0].pose;
                transform.rotation = pose.rotation;
                transform.position = pose.position;
                }
            }  
        }
    }
}
