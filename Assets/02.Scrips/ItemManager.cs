
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemArr;
    bool isShow;
    int[] itemPrice = { 6800 };
    int saleSum = 0;
    int count = 0;
    public void ShowRandomItems()
    {
        count = 0;
        for (int i = 0; i < itemArr.Length; i++)
        {
            isShow = Random.Range(0, 10) > 6;
            itemArr[i].SetActive(isShow);
            if (isShow) count++;
        }
        if (count == 0)
        {
            itemArr[0].SetActive(true);
            count++;
        }
    }

    public void UpdateSaleText(int itemNum)
    {
        saleSum += (itemPrice[itemNum] * count);
        gameObject.GetComponent<UIManager>().priceText.text = saleSum.ToString() + "¿ø";
    }
}
