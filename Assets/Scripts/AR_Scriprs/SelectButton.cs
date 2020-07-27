using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SelectButton : MonoBehaviour
{
    //list[0] == button0, [...] list[3] == button 3
    public List<GameObject> buttons = new List<GameObject>();
    public GameBehaviours gameBehaviours;
    
    void Update(){
        SelectByClick();
    }
    void SelectByClick(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);;
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,1000)){
            if(Input.GetMouseButtonDown(0))
                ClickButton(hit.collider.gameObject);
        }
    }
    void ClickButton(GameObject go){
        foreach(GameObject btn in buttons){
            if(go == btn)
                gameBehaviours.PontuationList(buttons.IndexOf(btn));
        }
    }
}

