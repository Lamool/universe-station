using System.Collections;
using System.Collections.Generic;
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

    //주민정보 관련된 메모 생성
    public Text textName;
    public Text textINumText;
    public Text textINum;
    public Text textEtc;

    //테스트
    public PersonData_ver2 personData;
    public PersonData_ver2 alienData;
    bool isAlien = false;
    bool isTroubleMaker = false;

    public Font nanumFont;
    public Font pyeongChangFont;
    public infoDatas infoData;

    /*
     * 에일리언 나타날 확률 조정
     * true : 0.7
     * false : 1.3
    */

    public bool isAlianCheck()
    {
        float alienProbability = Random.Range(0.0f, 2.0f);
        isAlien = (alienProbability < 1.3f) ? false : true;
        return isAlien;
    }
    public void GenerateCustormer()
    {
        GameManager.Instance.DayCount++;
        int len = 6;
        float alienProbability = Random.Range(0.0f, 2.0f);
        isAlien = (alienProbability < 1.3f) ? false : true;

        CustomerTypeCheck(); //일반 손님/진상/외계인 종류별 집계 - 결말을 위한 정답률 계산에 필요

        int[] idx = new int[len - 1];
        int countStar = 3;
        for (int i = 0; i < idx.Length; i++)
        {
            idx[i] = Random.Range(0, 6);
            //Debug.Log(idx[i]);
        }
        string address = GenerateAddress();
        string INum = isAlianCheck() ? FalsifyINum() : GenerateINum();
        string name = GenerateName();
        string pubDate = GenerateIDate(INum.Substring(0, 8), isAlianCheck());

        if (!isAlien)
            infoTextINum.font = nanumFont;

        // 난이도 1 2 3 에 따른 주민등록증 정보 공개 범위 설정
        /* 난이도1: 이름
         * 난이도2: 이름, 주민번호
         * 난이도3: 이름, 주민번호, 주소, 발급일자
         * 이름, 주소의 경우 isAlianCheck() = true면 기존정보와 다른 값으로 생성
            */

        countStar = 1; //*************
        if (countStar == 1)
        {
            //Debug.Log("1번");
            infoTextName.text = $"이름 : {name}"; //*************
            //infoTextName.text = $"이름 : {(isAlianCheck() ? GenerateName() : name)}";
            infoTextINumText.text = "주민 번호 : ";
            infoTextINum.text = $"{INum}";
            infoTextEtc.text = $"주소 : {address}\n" +
                $"발급 일자 : {pubDate}\n" +
                $"발급 장소 : {address}청";
        }

        else if (countStar == 2)
        {
            //Debug.Log("2번");
            //Debug.Log("2번 GenerateName" + GenerateName());
            //Debug.Log("2번 name" + name);
            infoTextName.text = $"이름 : {(isAlianCheck() ? GenerateName() : name)}";
            infoTextINumText.text = "주민 번호 : ";
            infoTextINum.text = $"{INum}";

            infoTextEtc.text = $"주소 : {address}\n" +
                $"발급 일자 : {pubDate}\n" +
                $"발급 장소 : {address}청";
        }
        else if (countStar == 3)
        {
            //Debug.Log("3번 GenerateName" + GenerateName());
            //Debug.Log("3번 name" + name);
            //Debug.Log("3번 pubDate" + pubDate);
            infoTextName.text = $"이름 : {(isAlianCheck() ? GenerateName() : name)}";

            infoTextINumText.text = "주민 번호 : ";
            infoTextINum.text = $"{INum}";
            //Debug.Log("3번 infoTextName.text" + infoTextName.text);
            infoTextEtc.text = $"주소 : {address}\n" +
                $"발급 일자 : {pubDate}\n" +
                $"발급 장소 : {(isAlianCheck() ? GenerateAddress() : address)}청";

            //Debug.Log("3번 infoTextEtc.text" + infoTextEtc.text);
        }
        else
        {
            Debug.Log("잘못된 설정입니다.");
        }
        //주민등록증 값 설정
        /*infoTextName.text = $"이름 : {name}";
        infoTextINumText.text = "주민 번호 : ";
        infoTextINum.text = $"{INum}";
        infoTextEtc.text = $"주소 : {address}\n" +
            $"발급 일자 : {pubDate}\n" +
            $"발급 장소 : {address}청";*/

        string MemoNum = GenerateINum();

        //메모값 설정
        textName.text = $"이름 : {name}";
        textINumText.text = "주민 번호 : ";
        textINum.text = $"{MemoNum}";
        textEtc.text = $"주소 : {address}\n" +
            $"발급 일자 : {GenerateIDate(MemoNum.Substring(0, 8), false)}\n" +
            $"발급 장소 : {address}청";

        for (int i = 0; i < faceImgArr.Length; i++)
        {
            if (isAlien && i == 1)
            { //i==1: 메인 손님 이미지 인덱스
                faceImgArr[i].sprite = alienData.faces[Random.Range(0, 7)];
                eyeImgArr[i].sprite = alienData.eyes[Random.Range(0, 7)];
                noseImgArr[i].sprite = alienData.noses[Random.Range(0, 7)];
                mouthImgArr[i].sprite = alienData.mouths[Random.Range(0, 7)];
                hairFrontImgArr[i].sprite = personData.hairs_front[idx[2]];
                hairBackImgArr[i].sprite = personData.hairs_back[idx[2]];//앞 머리와 뒷 머리 랜덤 선택 인덱스 값 같음
            }
            else
            {
                faceImgArr[i].sprite = personData.faces[idx[0]];
                eyeImgArr[i].sprite = personData.eyes[idx[1]];
                hairFrontImgArr[i].sprite = personData.hairs_front[idx[2]];
                hairBackImgArr[i].sprite = personData.hairs_back[idx[2]];//앞 머리와 뒷 머리 랜덤 선택 인덱스 값 같음
                noseImgArr[i].sprite = personData.noses[idx[3]];
                mouthImgArr[i].sprite = personData.mouths[idx[4]];
            }
        }

    }

    private void CustomerTypeCheck()
    {
        if (isAlien) GameManager.Instance.TotalAlien++;
        else
        {
            if (isTroubleMaker) GameManager.Instance.TotalTM++;
            else GameManager.Instance.TotalNP++;
        }
    }

    public string GenerateName()
    {
        string name = "";
        int fnLen = infoData.firstName.Length;
        int lnLen = infoData.lastName.Length;
        name += infoData.firstName[Random.Range(0, fnLen)];
        name += infoData.lastName[Random.Range(0, lnLen)];
        return name;
    }

    public string GenerateINum() // 생년월일, 성별 정상값 생성
    {
        string birthYear;
        bool isBornAfter2000 = (Random.Range(0, 2) == 1);
        if(isBornAfter2000)
            birthYear = Random.Range(0,7).ToString("D2");
        else
            birthYear = Random.Range(60, 100).ToString("D2");
        string birthMonth = Random.Range(01, 13).ToString("D2");
                                                //특정 달 인덱스 접근 위해 - 1 해 줌
        string birthDay = Random.Range(1, infoData.days[int.Parse(birthMonth) - 1 ] +1).ToString("D2");
        string gender = (Random.Range(1,3) + (isBornAfter2000 ? 2 : 0)).ToString();
        
        return $"{birthYear}{birthMonth}{birthDay}-{gender}******";
    }

    public string GenerateAddress()
    {
        int cityIdx = Random.Range(0, infoData.city.Length);
        int districtIdx = Random.Range(0, infoData.districts[cityIdx].Length);
        return $"{infoData.city[cityIdx]} {infoData.districts[cityIdx][districtIdx]}";
    }

    public string GenerateIDate(string birthDate, bool isAlien)
    {
        int birthYear;
        int birthMonth;
        int birthDay;
        int year;
        int month=0;
        int day=0;

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
            birthDay = int.Parse(birthDate.Substring(4, 2));
            //Debug.Log(birthDate+" "+birthYear+" "+birthMonth+" "+birthDay);
            //민증은 만 17세가 된 생일날 다음 날부터 1년 간 발급 가능
            year = Random.Range(birthYear + 17, birthYear + 17 + 2);
            //만 17세가 된 해에 발급 받음
            if (year == (birthYear + 17))
            {
                month = Random.Range(birthMonth, 13); // 생일이 있는 달 ~ 12월 발급
                if (month == birthMonth) day = Random.Range(birthDay + 1, infoData.days[month - 1] + 1);
                else
                {
                    try
                    {
                        day = Random.Range(1, infoData.days[month - 1] + 1);
                    }
                    catch
                    {
                        Debug.Log("오류 발생 : " + month + ", "+day);
                    }
                }
            }
            //그 다음 해에 발급 받음
            else
            {
                month = Random.Range(1, birthMonth + 1); //1월 ~ 생일이 있는 달
                if (month == birthMonth) day = Random.Range(1, birthDay + 1);
                else
                {
                    try
                    {
                        day = Random.Range(1, infoData.days[month - 1] + 1);
                    }
                    catch
                    {
                        Debug.Log("오류 발생 : " + month + ", " + day);
                    }
                }
            }
        }

        return $"{year.ToString()}. {month.ToString("D2")}. {day.ToString("D2")}";
    }

    public void CheckCustomer(int type)
    {
        if(type == 2) //일반 손님인지 체크
        {
            if (isAlien == false && isTroubleMaker == false) GameManager.Instance.NPCheck++;
            Debug.Log($"일반 손님 정답 수 : {GameManager.Instance.NPCheck}");
        }
        else if(type == 3) //진상인지 체크
        {
            if (isAlien == false && isTroubleMaker == true) GameManager.Instance.TMCheck++;
            Debug.Log($"진상 손님 정답 수 : {GameManager.Instance.TMCheck}");

        }
        else if(type == 4) //외계인인지 체크
        {
            if (isAlien == true) GameManager.Instance.AlienCheck++;
            Debug.Log($"외계인 정답 수 : {GameManager.Instance.AlienCheck / GameManager.Instance.TotalAlien}");
        }
        
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
