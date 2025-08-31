using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]       // 꼭 있어야 인스펙터에 보인다
public class SaleItem
{
    public Sprite itemImg;      // 편의점 상품 이미지
    public int itemPrice;       // 편의점 상품 가격
}

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemArr;
    bool isShow;
    public SaleItem[] saleItems;
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

            idx = Random.Range(0, saleItems.Length);
            itemArr[i].GetComponent<Image>().sprite = saleItems[idx].itemImg;
            itemArr[i].gameObject.SetActive(isShow);
            if (isShow)
            {
                count++;
                list.Add(idx);
            }
        }
        if (count == 0)
        {
            idx = Random.Range(0, saleItems.Length);
            itemArr[0].GetComponent<Image>().sprite = saleItems[idx].itemImg;
            itemArr[0].gameObject.SetActive(true);
            count++;
            list.Add(idx);
        }
    }

    public void UpdateSaleText()
    {
        for (int i = 0; i < list.Count; i++)
        {
            saleSum += saleItems[list[i]].itemPrice;
        }
        gameObject.GetComponent<UIManager>().priceText.text = saleSum.ToString() + "원";
    }
}