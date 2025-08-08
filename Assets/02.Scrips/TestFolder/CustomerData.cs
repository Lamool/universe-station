using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alien Data", menuName = "Alien/Alien Data")]
public class CustomerData : ScriptableObject
{
    public string planet; //출신 행성
    public string raceName; //종족명
    public string accent; //끝맺음 말투
    public string nature; //성격
    public Sprite characterImg; //캐릭터 이미지
}
