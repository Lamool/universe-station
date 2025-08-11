using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerGenerator : MonoBehaviour
{
    public Image image;
    public Text infoText;
    public CustomerData[] alienDataArr;
    int idx = -1;

    public void GenerateCustormer()
    {
        int temp = -1;
        //중복 등장 막음
        do
        {
            temp = Random.Range(0, alienDataArr.Length);
        }
        while (temp == idx);
        idx = temp;
        Debug.Log(idx);
        CustomerData alienData = alienDataArr[idx];
        
        image.sprite = alienData.characterImg;
        infoText.text = $"출신 행성 : {alienData.planet}\n" +
            $"종족 이름 : {alienData.raceName}\n" +
            $"말투 : {alienData.accent}\n" +
            $"성격 : {alienData.nature}";
    }
}
