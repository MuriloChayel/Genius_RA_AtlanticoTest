using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public SelectButton selectButton;
    public GameBehaviours gameBehaviours;
    public GameObject tutorial;
    
    public bool canClickSequence = false;
    [HideInInspector] public MeshCollider col;
    
    private Animator an;
    int gameLayerIndex,layerMask;

    void Start(){
        gameLayerIndex = LayerMask.NameToLayer("Game");
        layerMask = (1 << gameLayerIndex);
        col = GetComponent<MeshCollider>();
        an = GetComponent<Animator>();
        StartCoroutine(StartPatter()); // PADRAO PARA 'ASCENDER' OS BOTOES
    }
    void Update(){
        if(tutorial.gameObject.activeSelf)
            PressHere();
    }
    void OnMouseDown(){
        GetComponent<AudioSource>().Play();
        StartCoroutine(Press());
        an.SetTrigger("pressed");
        canClickSequence = true;
        StopAllCoroutines();
        StartCoroutine(SetButtonsColors());
        gameBehaviours.DefaultValues();
        col.enabled = false;
        tutorial.SetActive(false);
    }
    public IEnumerator StartPatter(){
        foreach(var item in selectButton.buttons){
            selectButton.buttons[selectButton.buttons.IndexOf(item)].GetComponent<MeshRenderer>().material.SetFloat("_Intensity",2);
            yield return new WaitForSeconds(.05f);
            selectButton.buttons[selectButton.buttons.IndexOf(item)].GetComponent<MeshRenderer>().material.SetFloat("_Intensity",0);
        }
        StartCoroutine(StartPatter());
    }
    public IEnumerator SetButtonsColors(){
        foreach(var item in selectButton.buttons){
            selectButton.buttons[selectButton.buttons.IndexOf(item)].GetComponent<MeshRenderer>().material.SetFloat("_Intensity",0);
        }
        yield return null;
    }
    IEnumerator Press(){
        GetComponent<MeshRenderer>().material.SetFloat("_Intensity",2);
        yield return new WaitForSeconds(.5f);
        GetComponent<MeshRenderer>().material.SetFloat("_Intensity",0);
    }
    void PressHere(){
        RaycastHit hit;
        bool active = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity,layerMask);
        if(active){
            print("func");
        }
        tutorial.GetComponent<Animator>().SetBool("enable",active);
        tutorial.transform.LookAt(Camera.main.transform.position);
    }
}
