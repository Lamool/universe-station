using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBtnForEnterCounterUI : MonoBehaviour
{
    bool isExit = false;

    bool IsExit
    {
        get { return isExit; }
        set
        {
            isExit = value;
            UIManager.instance.UIArr[0].SetActive(!isExit);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && IsExit == true)
        {
            IsExit = false;
            Debug.Log("플레이어 들어옴");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        IsExit = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && IsExit == false)
        {
            IsExit = true;
            Debug.Log("플레이어 나감");
        }
    }
}
