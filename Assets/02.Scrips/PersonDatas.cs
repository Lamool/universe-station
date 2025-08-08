using System;
using UnityEngine;

//[System.Serializable]
//public class PersonInfo
//{
//    public string name;
//    public string identifyNumber;
//    public string address;
//    public string issueDate;
//    public string issuePlaces;
//    public Sprite face;
//    public Sprite eyes;
//    public Sprite hair;
//    public Sprite mouth;
//    public Sprite nose;
//    public Sprite clothes;
//}

[CreateAssetMenu(fileName = "Person Datas", menuName = "Person/Person Datas")]
public class PersonDatas : ScriptableObject
{
    public string[] names = { "김민수", "이응덕", "최하림" };
    public string[] identifyNumbers = { "123", "456", "789" };
    public string[] addresses = { "수성동", "금성동", "목성동" };
    public string[] issueDates = { "2020/09/09", "2019/03/23", "2001/06/04" };
    public string[] issuePlaces = { "태양계", "안드로메다계", "가우시스계" };

    public Sprite[] faces;
    public Sprite[] eyes;
    public Sprite[] hairs;
    public Sprite[] mouthes;
    public Sprite[] noses;
    public Sprite[] clothes;
}
