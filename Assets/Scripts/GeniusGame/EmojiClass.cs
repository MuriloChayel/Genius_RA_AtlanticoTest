using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EmojiClass : MonoBehaviour
{
    public GameObject emojiObject;
    public List<Material> shameEmojiMaterials;
    public List<Material> happyEmojiMaterials;

    [HideInInspector]public bool lose;
    [HideInInspector]public float duration;

    void Start(){
        //emojiObject = GetComponentInChildren<GameObject>();  
        if(lose){
            duration = 3;
            emojiObject.GetComponent<MeshRenderer>().material = shameEmojiMaterials[Random.Range(0,shameEmojiMaterials.Count)];
            GetComponent<AudioSource>().Play();
        }else{
            duration = .5f;
            emojiObject.GetComponent<MeshRenderer>().material = happyEmojiMaterials[Random.Range(0,happyEmojiMaterials.Count)];
        }
    }
    void LateUpdate(){
        emojiObject.transform.LookAt(Camera.main.transform.position);
    }
}
