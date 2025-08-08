
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShowPerson : MonoBehaviour
{
    public Image[] faceImgArr;
    public Image[] eyeImgArr;
    public Image[] hairBackImgArr;
    public Image[] hairFrontImgArr;
    public Image[] noseImgArr;
    public Image[] mouthImgArr;

    public Text infoTextName;
    public Text infoTextINumText;
    public Text infoTextINum;
    public Text infoTextEtc;
    public PersonData_ver2 personData;
    bool isAlien = false;

    public Font nanumFont;
    public Font pyeongChangFont;

    //지피티 활용해 수집함.
    string[] firstName =
        {"김", "이", "박", "최", "정", "강", "조", "윤", "장", "임",
        "오", "한", "신", "서", "권", "황", "안", "송", "류", "홍",
        "전", "고", "문", "양", "손", "배", "백", "허", "유", "남"
    };

    string[] lastName = {
    // 1950~70년대 흔한 이름
    "영희", "철수", "순자", "영수", "옥자", "명수", "말자", "정자", "용식", "영자",
    "춘자", "상철", "종수", "미자", "복자", "영호", "병호", "기순", "동수", "형식",
    
    // 1980~90년대 흔한 이름
    "지혜", "지은", "지현", "민정", "수진", "은정", "유진", "영민", "상훈", "현우",
    "재현", "현정", "선영", "은영", "정훈", "정우", "은지", "정민", "지훈", "지수",
    
    // 2000년대 이후 흔한 이름
    "서연", "지우", "도윤", "하윤", "하은", "지민", "서준", "예은", "하율", "연우",
    "시우", "민서", "예진", "다은", "지안", "민준", "서윤", "지율", "수아", "윤서",
    
    // 중성적/범세대 이름
    "은희", "태현", "재영", "하진", "승민", "재민", "지환", "지성", "승호", "주연",
    "성훈", "세영", "영훈", "나영", "지연", "소연", "유림", "세진", "예림", "가영",
    
    // 기타 (조금 흔하지 않지만 한국적 이름)
    "윤지", "하연", "채영", "예슬", "하늘", "지효", "소영", "정현", "다영", "성은"
};
    string[] city = {
    "서울특별시", "부산광역시", "대구광역시",
    "인천광역시", "광주광역시", "대전광역시", "울산광역시"
};

    string[][] districts = new string[][]{
    // 서울특별시
    new string [] { "강남구", "강동구", "강북구", "강서구", "관악구", "광진구", "구로구", "금천구",
      "노원구", "도봉구", "동대문구", "동작구", "마포구", "서대문구", "서초구", "성동구",
      "성북구", "송파구", "양천구", "영등포구", "용산구", "은평구", "종로구", "중구", "중랑구" },

    // 부산광역시
    new string[] { "중구", "서구", "동구", "영도구", "부산진구", "동래구", "남구", "북구",
      "해운대구", "사하구", "금정구", "강서구", "연제구", "수영구", "사상구", "기장군" },

    // 대구광역시
    new string[] { "중구", "동구", "서구", "남구", "북구", "수성구", "달서구", "달성군" },

    // 인천광역시
     new string[]{ "중구", "동구", "미추홀구", "연수구", "남동구", "부평구", "계양구", "서구", "강화군", "옹진군" },

    // 광주광역시
     new string[]{ "동구", "서구", "남구", "북구", "광산구" },

    // 대전광역시
    new string[] { "동구", "중구", "서구", "유성구", "대덕구" },

    // 울산광역시
     new string[]{ "중구", "남구", "동구", "북구", "울주군" }
};
int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public void GenerateCustormer()
    {
        GameManager.Instance.DayCount++;
        int len = 6;
        float alienProbability = Random.Range(0.0f, 2.0f);
        isAlien = (alienProbability < 1.3f) ? false : true; 
        int[] idx = new int[len-1];
        for(int i = 0; i < idx.Length; i++)
        {
            idx[i] = Random.Range(0, 6);
            //Debug.Log(idx[i]);
        }
        string address = GenerateAddress();
        string INum = isAlien ? FalsifyINum() : GenerateINum();

        if (!isAlien)
            infoTextINum.font = nanumFont;

        infoTextName.text = $"이름 : {GenerateName()}";
        infoTextINumText.text = "주민 번호 : ";
        infoTextINum.text = $"{INum}";
        infoTextEtc.text = $"주소 : {address}\n" +
            $"발급 일자 : {GenerateIDate(INum.Substring(0,8), isAlien)}\n" +
            $"발급 장소 : {address}청";

        for(int i = 0; i < faceImgArr.Length; i++)
        {
            faceImgArr[i].sprite = personData.faces[idx[0]];
            if (isAlien == true &&  i==1) //인덱스 1에 변조된 외계인 손님 이미지 등장
            {
                faceImgArr[i].color = Color.green;
            }
            else
            {
                faceImgArr[i].color = Color.white;
            }
            eyeImgArr[i].sprite = personData.eyes[idx[1]];
            hairFrontImgArr[i].sprite = personData.hairs_front[idx[2]];
            hairBackImgArr[i].sprite = personData.hairs_back[idx[2]];//앞 머리와 뒷 머리 랜덤 선택 인덱스 값 같음
            noseImgArr[i].sprite = personData.noses[idx[3]];
            mouthImgArr[i].sprite = personData.mouths[idx[4]];
        }
        
    }

    public string GenerateName()
    {
        string name = "";
        int fnLen = firstName.Length;
        int lnLen = lastName.Length;
        name += firstName[Random.Range(0, fnLen)];
        name += lastName[Random.Range(0, lnLen)];
        return name;
    }

    public string GenerateINum()
    {
        string birthYear;
        bool isBornAfter2000 = (Random.Range(0, 2) == 1);
        if(isBornAfter2000)
            birthYear = Random.Range(0,7).ToString("D2");
        else
            birthYear = Random.Range(60, 100).ToString("D2");
        string birthMonth = Random.Range(01, 13).ToString("D2");
                                                //특정 달 인덱스 접근 위해 - 1 해 줌
        string birthDay = Random.Range(1,days[int.Parse(birthMonth) - 1 ] +1).ToString("D2");
        string gender = (Random.Range(1,3) + (isBornAfter2000 ? 2 : 0)).ToString();
        
        return $"{birthYear}{birthMonth}{birthDay}-{gender}******";
    }

    public string GenerateAddress()
    {
        int cityIdx = Random.Range(0, city.Length);
        int districtIdx = Random.Range(0, districts[cityIdx].Length);
        return $"{city[cityIdx]} {districts[cityIdx][districtIdx]}";
    }

    public string GenerateIDate(string birthDate, bool isAlien)
    {
        int birthYear;
        int birthMonth;
        int birthDay;
        int year;
        int month;
        int day;

        if (isAlien)
        {
            year = Random.Range(1900, 2100);
            month = Random.Range(1, 13);
            day = Random.Range(1, 32);
        }
        else
        {
            birthYear = (int.Parse(birthDate[7] + " ") > 2 ? 2000 : 1900) + int.Parse(birthDate.Substring(0, 2));
            birthMonth = int.Parse(birthDate.Substring(2, 2));
            birthDay = int.Parse(birthDate.Substring(4, 2)); ;
            //민증은 만 17세가 된 생일날 다음 날부터 1년 간 발급 가능
            year = Random.Range(birthYear + 17, birthYear + 17 + 2);
            //만 17세가 된 해에 발급 받음
            if (year == (birthYear + 17))
            {
                month = Random.Range(birthMonth, 13); // 생일이 있는 달 ~ 12월 발급
                if (month == birthMonth) day = Random.Range(birthDay + 1, days[month - 1] + 1);
                else day = Random.Range(1, days[month - 1] + 1);
            }
            //그 다음 해에 발급 받음
            else
            {
                month = Random.Range(1, birthMonth + 1); //1월 ~ 생일이 있는 달
                if (month == birthMonth) day = Random.Range(1, birthDay + 1);
                else day = Random.Range(1, days[month - 1] + 1);
            }
        }

        return $"{year.ToString()}. {month.ToString("D2")}. {day.ToString("D2")}";
    }

    public void CheckAlien(bool answer)
    {
        if (isAlien != answer) GameManager.Instance.ReduceLife();
    }

    // 주민번호 변조
    public string FalsifyINum()
    {
        int randomNum = (Random.Range(1, 4));    // 변조시킬 방법 세 가지 중 어떤 것으로 할지 1 ~ 3 중 랜덤값을 구함
        string INum;    // 주민번호

        switch (randomNum)
        {
            case 1: // 첫 번째, 현재 날짜 기준에 맞지 않는 수 (ex. 13월 43일)
                string birthYear;
                bool isBornAfter2000 = (Random.Range(0, 2) == 1);       // 랜덤값이 0이면 1900년대생으로 false 값 대입, 랜덤값이 1이면 2000년대생으로 true 값 대입
                if (isBornAfter2000)    // 2000년대생이면
                    birthYear = Random.Range(0, 10).ToString("D2");     // 주민번호 앞 두 자리 00 ~ 09
                else                    // 1900년대생이면 
                    birthYear = Random.Range(0, 100).ToString("D2");    // 주민번호 앞 두 자리 00 ~ 99
                int birthMonth = Random.Range(0, 100);   // 월 부분 00 ~ 99

                string birthDay;

                if (birthMonth >= 1 && birthMonth <= 12)  // 월이 1월 ~ 12월이면
                    birthDay = Random.Range(32, 100).ToString("D2");   // 일을 32 ~ 99로
                else
                    birthDay = Random.Range(0, 100).ToString("D2");   // 일을 00 ~ 99로
                string gender = Random.Range(0, 10).ToString();     // 주민번호 뒷자리 첫 번째 숫자는 0 ~ 9

                return $"{birthYear}{birthMonth.ToString("D2")}{birthDay}-{gender}******";
            case 2: // 두 번째, 정상적인 주민번호지만, 메모와 값이 다른 경우
                INum = GenerateINum();   // 정상적인 주민번호 생성
                string memoINum = GenerateINum();

                while (INum.Equals(memoINum))   // 주민번호와 메모의 생년월일이 일치하다면
                {
                    INum = GenerateINum();   // 다시 주민번호 새로 발급
                }

                return INum;
            case 3: // 세 번째, 폰트를 다르게 하는 방법
                INum = GenerateINum();

                // 폰트 변경
                infoTextINum.font = pyeongChangFont;

                return INum;
            default:
                return "에러";
        }
    }
}
