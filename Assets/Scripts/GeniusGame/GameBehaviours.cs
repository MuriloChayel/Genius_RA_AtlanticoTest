using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class GameBehaviours : MonoBehaviour
{
    private SelectButton selectButton;
    private StartGame startGame;
    private int count;
    
    [HideInInspector]public List<int> points;
    [HideInInspector]public List<int> sequenceList;
    
    public List<Color> colors = new List<Color>();
    public GameObject emoji;
    public TextMeshProUGUI text;
    int pontuation;

    void Start(){
        startGame = GetComponentInChildren<StartGame>();
        selectButton = Camera.main.GetComponent<SelectButton>();
        //ARMAZENA AS CORES INICIAIS DOS BOTOES DA LISTA
        foreach(var item in selectButton.buttons){
            colors.Add(item.GetComponent<MeshRenderer>().material.GetColor("_Color"));
        }
    }
    //INICIALIZA A LISTA DE SEQUENCIA E ANIMA O PRIMEIRO BOTADO DE ACORDO COM O INDEX(INT) DELE NA LISTA
    public void DefaultValues(){
        sequenceList = new List<int> {Random.Range(0,4)};
        StartCoroutine(ShowColorSequence());
    }
    // RECEBE O INDEX DE UM BOTAO DA LISTA DE BOTOES, CHECA SE ELE EXISTE NA LISTA E COMPARA AS DUAS LISTAS
    public void PontuationList(int index){
        if(sequenceList.Count > 0 &&  startGame.canClickSequence){ 
            selectButton.buttons[index].GetComponent<Animator>().SetTrigger("pressed");
            if(index == sequenceList[count]){
                points.Add(index);                
                count++;
                //SE AS LISTAS FOREM IGUAIS LIMPA A LISTA 1(ACERTOS) E ADD UM NOVO VALOR A LISTA 2
                //VEVIFICA SE O PLAYER ACERTOU A SEQUENCE
                if(CompareList(points, sequenceList)){
                    ActiveEmojis(false);
                    pontuation++;
                    count = 0;
                    points.Clear();
                    sequenceList.Add(Random.Range(0,4));
                    StartCoroutine(ShowColorSequence());
                }
            //INICIA A CORROTINA "ERROR" CASO O INDEX NAO EXISTA NAQUELA POSICAO DA LISTA
            //VERIFICA SE O PLAYER ERROU A SEQUENCIA
            }else{
                StartCoroutine(Error());
                count = 0;
                pontuation = 0;
                sequenceList.Clear();
                points.Clear();
                sequenceList.Add(Random.Range(0,4));
            }
        }else
        {
            count = 0;
        }
        //EXIBE A PONTUACAO DE JOGADAS CONSECUTIVAS DO PLAYER
        text.text = "SCORE: " + pontuation;
    }
    //EXECULTA A ANIMACAO PARA CADA BOTAO DA LISTA SEGUINDO A ORDEM DE ACORDO COM A LISTA "sequenceList"
    IEnumerator ShowColorSequence(){
        startGame.canClickSequence = false;
        yield return new WaitForSeconds(.5f);
        for(int a = 0; a < selectButton.buttons.Count; a++){
            selectButton.buttons[a].GetComponent<MeshRenderer>().material.color = colors[a];
        }
        foreach (int item in sequenceList)
        {
            yield return new WaitForSeconds(.5f);
            selectButton.buttons[item].GetComponent<Animator>().SetTrigger("pressed"); 
        }
        startGame.canClickSequence = true;   
    }
    IEnumerator Error(){
        //MUDA A COR DOS BOTOES PARA VERMELHO
        ActiveEmojis(true);
        startGame.canClickSequence = false;
        for(int a = 0; a < selectButton.buttons.Count; a++){
            selectButton.buttons[a].GetComponent<MeshRenderer>().material.color = new Color(255,0,0);
        }
        yield return new WaitForSeconds(3);
        //RETOMA A COR ORIGINAL DOS BOTOES
        for(int a = 0; a < selectButton.buttons.Count; a++){
            selectButton.buttons[a].GetComponent<MeshRenderer>().material.color = colors[a];
        }
        startGame.col.enabled = true;
        StartCoroutine(startGame.StartPatter()); 
    }  

    bool CompareList(List<int> list1, List<int> list2){
        bool result = true;
        if(list1.Count != list2.Count)
            return false;
        for(int a = 0; a < list1.Count; a++){
            if(list1[a] != list2[a])
                result = false;    
        }
        return result;
    }    
    void ActiveEmojis(bool lose){
        GameObject go = GameObject.Instantiate(emoji)as GameObject;
        go.GetComponent<EmojiClass>().lose = lose;
        go.transform.SetParent(this.transform);
        go.transform.localPosition = new Vector3(0,0,0);
        for(int a = 0; a < selectButton.buttons.Count; a++){
            selectButton.buttons[a].GetComponent<MeshRenderer>().material.color = new Color(0,255,0);
        }
    }
}       