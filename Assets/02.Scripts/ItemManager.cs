
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemArr;
    bool isShow;
    public Sprite[] saleItem;       // 상품을 담은 배열
    int[] itemPrice = { 1600, 2500, 2700, 2000, 1000, 300, 1000, 1500, 1700, 1500, 1200, 4500, 1600 };      // 상품 가격을 담은 배열
    int saleSum = 0;
    int count = 0;
    List<int> list;

    public void ShowRandomItems()
    {
        int idx;
        list = new List<int>();     // 계산하고자 하는 상품(saleItem 배열)의 인덱스를 담을 리스트
        count = 0;

        for (int i = 0; i < itemArr.Length; i++)
        {
            isShow = Random.Range(0, 10) > 6;

            idx = Random.Range(0, saleItem.Length);
            itemArr[i].GetComponent<Image>().sprite = saleItem[idx];
            itemArr[i].gameObject.SetActive(isShow);
            if (isShow)
            {
                count++;
                list.Add(idx);
            }
        }
        if (count == 0)
        {
            idx = Random.Range(0, saleItem.Length);
            itemArr[0].GetComponent<Image>().sprite = saleItem[idx];
            itemArr[0].gameObject.SetActive(true);
            count++;
            list.Add(idx);
        }
    }

    public void UpdateSaleText()
    {
        for (int i = 0; i < list.Count; i++)
        {
            saleSum += itemPrice[list[i]];
        }
        gameObject.GetComponent<UIManager>().priceText.text = saleSum.ToString() + "원";
    }
}
