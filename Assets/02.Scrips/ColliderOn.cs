using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOn : MonoBehaviour
{
    public GameObject UICollider;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UICollider.SetActive(!UICollider.activeSelf);
            UIManager.instance.UIArr[0].SetActive(UICollider.activeSelf);
            UIManager.instance.UIArr[4].SetActive(!UICollider.activeSelf);
        }
    }
}
