 using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] UIArr; //Toggle할 UI 담아놓을 배열
    bool[] isShowUIArr; //UI 활성화 체크용 bool 변수
    public Text ConversationText; //대화 텍스트
    string[] conversation = { "안녕하세요.", "민증 확인하겠습니다.", "계산됐습니다.", "나가주세요.", "외계인 신고합니다." };
    bool[] conversationBoolArr = {false, false, false, false};
    public Text priceText; //판매 금액 텍스트
    public Image StoryImage;
    public Sprite[] storySpriteArr;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this) Destroy(gameObject);
        isShowUIArr = new bool[UIArr.Length];
        for (int i = 0; i < UIArr.Length; i++) //UI들 가리기
        {
            UIArr[i].SetActive(false);
        }
        ResetConversation();
    }

    void Start()
    {
        //ToggleUI(3);
        //StartCoroutine(ShowStory());
    }

    public void ResetConversation()
    {
        for (int i = 0; i < conversationBoolArr.Length; i++) conversationBoolArr[i] = false;
        if (GameManager.Instance.IsGameOver)
        {
            ConversationText.text = "게임 오버";
            return;
        }
        ConversationText.text = $"{conversation[0]}\n";
        gameObject.GetComponent<ShowPerson>().GenerateCustormer();
        gameObject.GetComponent<ItemManager>().ShowRandomItems();
    }

    public void ToggleUI(int idx)//0:진상찾기 UI 1: 민증 UI 2: OUT 상세 버튼
    {
        if (GameManager.Instance.IsGameOver) //게임 오버인 경우 UI ON/Off 작동시키지 않음
        {
            //isShowIDCard = false;
            return;
        }
        else isShowUIArr[idx] = !isShowUIArr[idx];
        UIArr[idx].gameObject.SetActive(isShowUIArr[idx]);
    }

    public void ShowPassAction()
    {
        if (GameManager.Instance.IsGameOver) return;
        gameObject.GetComponent<ShowPerson>().CheckAlien(false);
        ShowConversation(2);
        StartCoroutine(WaitReset());
        gameObject.GetComponent<ItemManager>().UpdateSaleText(0);
    }

    public void ShowTroubleMakerOutAction()
    {
        if (GameManager.Instance.IsGameOver) return;
        ShowConversation(3);
        StartCoroutine(WaitReset());
    }

    public void ShowAlienOutAction()
    {
        if (GameManager.Instance.IsGameOver) return;
        ShowConversation(4);
        StartCoroutine(WaitReset());
    }

    public void ShowConversation(int idx)
    {
        if(GameManager.Instance.IsGameOver) return;
        if (conversationBoolArr[idx-1] == false)
        {
            conversationBoolArr[idx-1] = true;
            StartCoroutine(WaitShowConversation(idx));
        }
    }

    IEnumerator WaitShowConversation(int idx)
    {
        yield return new WaitForSeconds(0.1f);
        ConversationText.text += $"{conversation[idx]}\n";
    }

    IEnumerator WaitReset()
    {
        yield return new WaitForSeconds(1f);
        ResetConversation();
        gameObject.GetComponent<ShowPerson>().GenerateCustormer();
    }

    IEnumerator ShowStory()
    {
        for (int i = 0; i < storySpriteArr.Length; i++)
        {
            StoryImage.sprite = storySpriteArr[i];
            yield return new WaitForSeconds(1f);
        }
        ToggleUI(3);
    }
}
