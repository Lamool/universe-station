using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersonInfo
{
    public string name;
    public string identifyNumber;
    public string address;
    public string issueDate;
    public string issuePlaces;
    public Sprite face;
    public Sprite eyes;
    public Sprite hair;
    public Sprite mouth_front;
    public Sprite mouth_back;
    public Sprite nose;
}

[CreateAssetMenu(fileName = "Person Datas Ver2", menuName = "Person/Person Datas Ver2")]
public class PersonData_ver2 : ScriptableObject
{
    public string[] names = { "김민수", "이응덕", "최하림", "박민재", "줄리킴", "유명한" };
    public string[] identifyNumbers = { "123", "456", "789", "135", "246", "579"};
    public string[] addresses = { "수성동", "금성동", "목성동", "토성동", "천왕동", "해왕동" };
    public string[] issueDates = { "2020/09/09", "2019/03/23", "2001/06/04", "2023/07/24", "2013/09/22", "2018/11/13" };
    public string[] issuePlaces = { "태양계", "안드로메다계", "가우시스계", "이오계", "카시오페아계", "마젤란계" };
    public Sprite[] faces;
    public Sprite[] eyes;
    public Sprite[] hairs_front;
    public Sprite[] hairs_back;
    public Sprite[] mouths;
    public Sprite[] noses;
}
