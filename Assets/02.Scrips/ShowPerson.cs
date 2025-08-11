<<<<<<< HEAD

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

    public Text textName;
    public Text textINumText;
    public Text textINum;
    public Text textEtc;

        //ì§€í”¼í‹° í™œìš©í•´ ìˆ˜ì§‘í•¨.
    string[] firstName =
        {"ê¹€", "ì´", "ë°•", "ìµœ", "ì •", "ê°•", "ì¡°", "ìœ¤", "ìž¥", "ìž„",
        "ì˜¤", "í•œ", "ì‹ ", "ì„œ", "ê¶Œ", "í™©", "ì•ˆ", "ì†¡", "ë¥˜", "í™",
        "ì „", "ê³ ", "ë¬¸", "ì–‘", "ì†", "ë°°", "ë°±", "í—ˆ", "ìœ ", "ë‚¨"
    };

    string[] lastName = {
    // 1950~70ë…„ëŒ€ í”í•œ ì´ë¦„
    "ì˜í¬", "ì² ìˆ˜", "ìˆœìž", "ì˜ìˆ˜", "ì˜¥ìž", "ëª…ìˆ˜", "ë§ìž", "ì •ìž", "ìš©ì‹", "ì˜ìž",
    "ì¶˜ìž", "ìƒì² ", "ì¢…ìˆ˜", "ë¯¸ìž", "ë³µìž", "ì˜í˜¸", "ë³‘í˜¸", "ê¸°ìˆœ", "ë™ìˆ˜", "í˜•ì‹",
    
    // 1980~90ë…„ëŒ€ í”í•œ ì´ë¦„
    "ì§€í˜œ", "ì§€ì€", "ì§€í˜„", "ë¯¼ì •", "ìˆ˜ì§„", "ì€ì •", "ìœ ì§„", "ì˜ë¯¼", "ìƒí›ˆ", "í˜„ìš°",
    "ìž¬í˜„", "í˜„ì •", "ì„ ì˜", "ì€ì˜", "ì •í›ˆ", "ì •ìš°", "ì€ì§€", "ì •ë¯¼", "ì§€í›ˆ", "ì§€ìˆ˜",
    
    // 2000ë…„ëŒ€ ì´í›„ í”í•œ ì´ë¦„
    "ì„œì—°", "ì§€ìš°", "ë„ìœ¤", "í•˜ìœ¤", "í•˜ì€", "ì§€ë¯¼", "ì„œì¤€", "ì˜ˆì€", "í•˜ìœ¨", "ì—°ìš°",
    "ì‹œìš°", "ë¯¼ì„œ", "ì˜ˆì§„", "ë‹¤ì€", "ì§€ì•ˆ", "ë¯¼ì¤€", "ì„œìœ¤", "ì§€ìœ¨", "ìˆ˜ì•„", "ìœ¤ì„œ",
    
    // ì¤‘ì„±ì /ë²”ì„¸ëŒ€ ì´ë¦„
    "ì€í¬", "íƒœí˜„", "ìž¬ì˜", "í•˜ì§„", "ìŠ¹ë¯¼", "ìž¬ë¯¼", "ì§€í™˜", "ì§€ì„±", "ìŠ¹í˜¸", "ì£¼ì—°",
    "ì„±í›ˆ", "ì„¸ì˜", "ì˜í›ˆ", "ë‚˜ì˜", "ì§€ì—°", "ì†Œì—°", "ìœ ë¦¼", "ì„¸ì§„", "ì˜ˆë¦¼", "ê°€ì˜",
    
    // ê¸°íƒ€ (ì¡°ê¸ˆ í”í•˜ì§€ ì•Šì§€ë§Œ í•œêµ­ì  ì´ë¦„)
    "ìœ¤ì§€", "í•˜ì—°", "ì±„ì˜", "ì˜ˆìŠ¬", "í•˜ëŠ˜", "ì§€íš¨", "ì†Œì˜", "ì •í˜„", "ë‹¤ì˜", "ì„±ì€"
};
    string[] city = {
    "ì„œìš¸íŠ¹ë³„ì‹œ", "ë¶€ì‚°ê´‘ì—­ì‹œ", "ëŒ€êµ¬ê´‘ì—­ì‹œ",
    "ì¸ì²œê´‘ì—­ì‹œ", "ê´‘ì£¼ê´‘ì—­ì‹œ", "ëŒ€ì „ê´‘ì—­ì‹œ", "ìš¸ì‚°ê´‘ì—­ì‹œ"
};

    string[][] districts = new string[][]{
    // ì„œìš¸íŠ¹ë³„ì‹œ
    new string [] { "ê°•ë‚¨êµ¬", "ê°•ë™êµ¬", "ê°•ë¶êµ¬", "ê°•ì„œêµ¬", "ê´€ì•…êµ¬", "ê´‘ì§„êµ¬", "êµ¬ë¡œêµ¬", "ê¸ˆì²œêµ¬",
      "ë…¸ì›êµ¬", "ë„ë´‰êµ¬", "ë™ëŒ€ë¬¸êµ¬", "ë™ìž‘êµ¬", "ë§ˆí¬êµ¬", "ì„œëŒ€ë¬¸êµ¬", "ì„œì´ˆêµ¬", "ì„±ë™êµ¬",
      "ì„±ë¶êµ¬", "ì†¡íŒŒêµ¬", "ì–‘ì²œêµ¬", "ì˜ë“±í¬êµ¬", "ìš©ì‚°êµ¬", "ì€í‰êµ¬", "ì¢…ë¡œêµ¬", "ì¤‘êµ¬", "ì¤‘ëž‘êµ¬" },

    // ë¶€ì‚°ê´‘ì—­ì‹œ
    new string[] { "ì¤‘êµ¬", "ì„œêµ¬", "ë™êµ¬", "ì˜ë„êµ¬", "ë¶€ì‚°ì§„êµ¬", "ë™ëž˜êµ¬", "ë‚¨êµ¬", "ë¶êµ¬",
      "í•´ìš´ëŒ€êµ¬", "ì‚¬í•˜êµ¬", "ê¸ˆì •êµ¬", "ê°•ì„œêµ¬", "ì—°ì œêµ¬", "ìˆ˜ì˜êµ¬", "ì‚¬ìƒêµ¬", "ê¸°ìž¥êµ°" },

    // ëŒ€êµ¬ê´‘ì—­ì‹œ
    new string[] { "ì¤‘êµ¬", "ë™êµ¬", "ì„œêµ¬", "ë‚¨êµ¬", "ë¶êµ¬", "ìˆ˜ì„±êµ¬", "ë‹¬ì„œêµ¬", "ë‹¬ì„±êµ°" },

    // ì¸ì²œê´‘ì—­ì‹œ
     new string[]{ "ì¤‘êµ¬", "ë™êµ¬", "ë¯¸ì¶”í™€êµ¬", "ì—°ìˆ˜êµ¬", "ë‚¨ë™êµ¬", "ë¶€í‰êµ¬", "ê³„ì–‘êµ¬", "ì„œêµ¬", "ê°•í™”êµ°", "ì˜¹ì§„êµ°" },

    // ê´‘ì£¼ê´‘ì—­ì‹œ
     new string[]{ "ë™êµ¬", "ì„œêµ¬", "ë‚¨êµ¬", "ë¶êµ¬", "ê´‘ì‚°êµ¬" },

    // ëŒ€ì „ê´‘ì—­ì‹œ
    new string[] { "ë™êµ¬", "ì¤‘êµ¬", "ì„œêµ¬", "ìœ ì„±êµ¬", "ëŒ€ë•êµ¬" },

    // ìš¸ì‚°ê´‘ì—­ì‹œ
     new string[]{ "ì¤‘êµ¬", "ë‚¨êµ¬", "ë™êµ¬", "ë¶êµ¬", "ìš¸ì£¼êµ°" }
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
        string name = GenerateName();
        string pubDate = GenerateIDate(INum.Substring(0,8), isAlien);
        
        if (!isAlien)
            infoTextINum.font = nanumFont;

        infoTextName.text = $"ì´ë¦„ : {name}";
        infoTextINumText.text = "ì£¼ë¯¼ ë²ˆí˜¸ : ";
        infoTextINum.text = $"{INum}";
        infoTextEtc.text = $"ì£¼ì†Œ : {address}\n" +
            $"ë°œê¸‰ ì¼ìž : {pubDate}\n" +
            $"ë°œê¸‰ ìž¥ì†Œ : {address}ì²­";

        //ë©”ëª¨
        textName.text = $"ì´ë¦„ : {name}";
        textINumText.text = "ì£¼ë¯¼ ë²ˆí˜¸ : ";
        textINum.text = $"{INum}";
        textEtc.text = $"ì£¼ì†Œ : {address}\n" +
            $"ë°œê¸‰ ì¼ìž : {pubDate}\n" +
            $"ë°œê¸‰ ìž¥ì†Œ : {address}ì²­";  

        for(int i = 0; i < faceImgArr.Length; i++)
        {
            faceImgArr[i].sprite = personData.faces[idx[0]];
            if (isAlien == true &&  i==1) //ì¸ë±ìŠ¤ 1ì— ë³€ì¡°ëœ ì™¸ê³„ì¸ ì†ë‹˜ ì´ë¯¸ì§€ ë“±ìž¥
            {
                faceImgArr[i].color = Color.green;
            }
            else
            {
                faceImgArr[i].color = Color.white;
            }
            eyeImgArr[i].sprite = personData.eyes[idx[1]];
            hairFrontImgArr[i].sprite = personData.hairs_front[idx[2]];
            hairBackImgArr[i].sprite = personData.hairs_back[idx[2]];//ì•ž ë¨¸ë¦¬ì™€ ë’· ë¨¸ë¦¬ ëžœë¤ ì„ íƒ ì¸ë±ìŠ¤ ê°’ ê°™ìŒ
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
                                                //íŠ¹ì • ë‹¬ ì¸ë±ìŠ¤ ì ‘ê·¼ ìœ„í•´ - 1 í•´ ì¤Œ
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
            //ë¯¼ì¦ì€ ë§Œ 17ì„¸ê°€ ëœ ìƒì¼ë‚  ë‹¤ìŒ ë‚ ë¶€í„° 1ë…„ ê°„ ë°œê¸‰ ê°€ëŠ¥
            year = Random.Range(birthYear + 17, birthYear + 17 + 2);
            //ë§Œ 17ì„¸ê°€ ëœ í•´ì— ë°œê¸‰ ë°›ìŒ
            if (year == (birthYear + 17))
            {
                month = Random.Range(birthMonth, 13); // ìƒì¼ì´ ìžˆëŠ” ë‹¬ ~ 12ì›” ë°œê¸‰
                if (month == birthMonth) day = Random.Range(birthDay + 1, days[month - 1] + 1);
                else day = Random.Range(1, days[month - 1] + 1);
            }
            //ê·¸ ë‹¤ìŒ í•´ì— ë°œê¸‰ ë°›ìŒ
            else
            {
                month = Random.Range(1, birthMonth + 1); //1ì›” ~ ìƒì¼ì´ ìžˆëŠ” ë‹¬
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

    // ì£¼ë¯¼ë²ˆí˜¸ ë³€ì¡°
    public string FalsifyINum()
    {
        int randomNum = (Random.Range(1, 4));    // ë³€ì¡°ì‹œí‚¬ ë°©ë²• ì„¸ ê°€ì§€ ì¤‘ ì–´ë–¤ ê²ƒìœ¼ë¡œ í• ì§€ 1 ~ 3 ì¤‘ ëžœë¤ê°’ì„ êµ¬í•¨
        string INum;    // ì£¼ë¯¼ë²ˆí˜¸

        switch (randomNum)
        {
            case 1: // ì²« ë²ˆì§¸, í˜„ìž¬ ë‚ ì§œ ê¸°ì¤€ì— ë§žì§€ ì•ŠëŠ” ìˆ˜ (ex. 13ì›” 43ì¼)
                string birthYear;
                bool isBornAfter2000 = (Random.Range(0, 2) == 1);       // ëžœë¤ê°’ì´ 0ì´ë©´ 1900ë…„ëŒ€ìƒìœ¼ë¡œ false ê°’ ëŒ€ìž…, ëžœë¤ê°’ì´ 1ì´ë©´ 2000ë…„ëŒ€ìƒìœ¼ë¡œ true ê°’ ëŒ€ìž…
                if (isBornAfter2000)    // 2000ë…„ëŒ€ìƒì´ë©´
                    birthYear = Random.Range(0, 10).ToString("D2");     // ì£¼ë¯¼ë²ˆí˜¸ ì•ž ë‘ ìžë¦¬ 00 ~ 09
                else                    // 1900ë…„ëŒ€ìƒì´ë©´ 
                    birthYear = Random.Range(0, 100).ToString("D2");    // ì£¼ë¯¼ë²ˆí˜¸ ì•ž ë‘ ìžë¦¬ 00 ~ 99
                int birthMonth = Random.Range(0, 100);   // ì›” ë¶€ë¶„ 00 ~ 99

                string birthDay;

                if (birthMonth >= 1 && birthMonth <= 12)  // ì›”ì´ 1ì›” ~ 12ì›”ì´ë©´
                    birthDay = Random.Range(32, 100).ToString("D2");   // ì¼ì„ 32 ~ 99ë¡œ
                else
                    birthDay = Random.Range(0, 100).ToString("D2");   // ì¼ì„ 00 ~ 99ë¡œ
                string gender = Random.Range(0, 10).ToString();     // ì£¼ë¯¼ë²ˆí˜¸ ë’·ìžë¦¬ ì²« ë²ˆì§¸ ìˆ«ìžëŠ” 0 ~ 9

                return $"{birthYear}{birthMonth.ToString("D2")}{birthDay}-{gender}******";
            case 2: // ë‘ ë²ˆì§¸, ì •ìƒì ì¸ ì£¼ë¯¼ë²ˆí˜¸ì§€ë§Œ, ë©”ëª¨ì™€ ê°’ì´ ë‹¤ë¥¸ ê²½ìš°
                INum = GenerateINum();   // ì •ìƒì ì¸ ì£¼ë¯¼ë²ˆí˜¸ ìƒì„±
                string memoINum = GenerateINum();

                while (INum.Equals(memoINum))   // ì£¼ë¯¼ë²ˆí˜¸ì™€ ë©”ëª¨ì˜ ìƒë…„ì›”ì¼ì´ ì¼ì¹˜í•˜ë‹¤ë©´
                {
                    INum = GenerateINum();   // ë‹¤ì‹œ ì£¼ë¯¼ë²ˆí˜¸ ìƒˆë¡œ ë°œê¸‰
                }

                return INum;
            case 3: // ì„¸ ë²ˆì§¸, í°íŠ¸ë¥¼ ë‹¤ë¥´ê²Œ í•˜ëŠ” ë°©ë²•
                INum = GenerateINum();

                // í°íŠ¸ ë³€ê²½
                infoTextINum.font = pyeongChangFont;

                return INum;
            default:
                return "ì—ëŸ¬";
        }
    }

}
=======

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
    public PersonData_ver2 alienData;
    bool isAlien = false;

    public Font nanumFont;
    public Font pyeongChangFont;

    //ÁöÇÇÆ¼ È°¿ëÇØ ¼öÁýÇÔ.
    string[] firstName =
        {"±è", "ÀÌ", "¹Ú", "ÃÖ", "Á¤", "°­", "Á¶", "À±", "Àå", "ÀÓ",
        "¿À", "ÇÑ", "½Å", "¼­", "±Ç", "È²", "¾È", "¼Û", "·ù", "È«",
        "Àü", "°í", "¹®", "¾ç", "¼Õ", "¹è", "¹é", "Çã", "À¯", "³²"
    };

    string[] lastName = {
    // 1950~70³â´ë ÈçÇÑ ÀÌ¸§
    "¿µÈñ", "Ã¶¼ö", "¼øÀÚ", "¿µ¼ö", "¿ÁÀÚ", "¸í¼ö", "¸»ÀÚ", "Á¤ÀÚ", "¿ë½Ä", "¿µÀÚ",
    "ÃáÀÚ", "»óÃ¶", "Á¾¼ö", "¹ÌÀÚ", "º¹ÀÚ", "¿µÈ£", "º´È£", "±â¼ø", "µ¿¼ö", "Çü½Ä",
    
    // 1980~90³â´ë ÈçÇÑ ÀÌ¸§
    "ÁöÇý", "ÁöÀº", "ÁöÇö", "¹ÎÁ¤", "¼öÁø", "ÀºÁ¤", "À¯Áø", "¿µ¹Î", "»óÈÆ", "Çö¿ì",
    "ÀçÇö", "ÇöÁ¤", "¼±¿µ", "Àº¿µ", "Á¤ÈÆ", "Á¤¿ì", "ÀºÁö", "Á¤¹Î", "ÁöÈÆ", "Áö¼ö",
    
    // 2000³â´ë ÀÌÈÄ ÈçÇÑ ÀÌ¸§
    "¼­¿¬", "Áö¿ì", "µµÀ±", "ÇÏÀ±", "ÇÏÀº", "Áö¹Î", "¼­ÁØ", "¿¹Àº", "ÇÏÀ²", "¿¬¿ì",
    "½Ã¿ì", "¹Î¼­", "¿¹Áø", "´ÙÀº", "Áö¾È", "¹ÎÁØ", "¼­À±", "ÁöÀ²", "¼ö¾Æ", "À±¼­",
    
    // Áß¼ºÀû/¹ü¼¼´ë ÀÌ¸§
    "ÀºÈñ", "ÅÂÇö", "Àç¿µ", "ÇÏÁø", "½Â¹Î", "Àç¹Î", "ÁöÈ¯", "Áö¼º", "½ÂÈ£", "ÁÖ¿¬",
    "¼ºÈÆ", "¼¼¿µ", "¿µÈÆ", "³ª¿µ", "Áö¿¬", "¼Ò¿¬", "À¯¸²", "¼¼Áø", "¿¹¸²", "°¡¿µ",
    
    // ±âÅ¸ (Á¶±Ý ÈçÇÏÁö ¾ÊÁö¸¸ ÇÑ±¹Àû ÀÌ¸§)
    "À±Áö", "ÇÏ¿¬", "Ã¤¿µ", "¿¹½½", "ÇÏ´Ã", "ÁöÈ¿", "¼Ò¿µ", "Á¤Çö", "´Ù¿µ", "¼ºÀº"
};
    string[] city = {
    "¼­¿ïÆ¯º°½Ã", "ºÎ»ê±¤¿ª½Ã", "´ë±¸±¤¿ª½Ã",
    "ÀÎÃµ±¤¿ª½Ã", "±¤ÁÖ±¤¿ª½Ã", "´ëÀü±¤¿ª½Ã", "¿ï»ê±¤¿ª½Ã"
};

    string[][] districts = new string[][]{
    // ¼­¿ïÆ¯º°½Ã
    new string [] { "°­³²±¸", "°­µ¿±¸", "°­ºÏ±¸", "°­¼­±¸", "°ü¾Ç±¸", "±¤Áø±¸", "±¸·Î±¸", "±ÝÃµ±¸",
      "³ë¿ø±¸", "µµºÀ±¸", "µ¿´ë¹®±¸", "µ¿ÀÛ±¸", "¸¶Æ÷±¸", "¼­´ë¹®±¸", "¼­ÃÊ±¸", "¼ºµ¿±¸",
      "¼ººÏ±¸", "¼ÛÆÄ±¸", "¾çÃµ±¸", "¿µµîÆ÷±¸", "¿ë»ê±¸", "ÀºÆò±¸", "Á¾·Î±¸", "Áß±¸", "Áß¶û±¸" },

    // ºÎ»ê±¤¿ª½Ã
    new string[] { "Áß±¸", "¼­±¸", "µ¿±¸", "¿µµµ±¸", "ºÎ»êÁø±¸", "µ¿·¡±¸", "³²±¸", "ºÏ±¸",
      "ÇØ¿î´ë±¸", "»çÇÏ±¸", "±ÝÁ¤±¸", "°­¼­±¸", "¿¬Á¦±¸", "¼ö¿µ±¸", "»ç»ó±¸", "±âÀå±º" },

    // ´ë±¸±¤¿ª½Ã
    new string[] { "Áß±¸", "µ¿±¸", "¼­±¸", "³²±¸", "ºÏ±¸", "¼ö¼º±¸", "´Þ¼­±¸", "´Þ¼º±º" },

    // ÀÎÃµ±¤¿ª½Ã
     new string[]{ "Áß±¸", "µ¿±¸", "¹ÌÃßÈ¦±¸", "¿¬¼ö±¸", "³²µ¿±¸", "ºÎÆò±¸", "°è¾ç±¸", "¼­±¸", "°­È­±º", "¿ËÁø±º" },

    // ±¤ÁÖ±¤¿ª½Ã
     new string[]{ "µ¿±¸", "¼­±¸", "³²±¸", "ºÏ±¸", "±¤»ê±¸" },

    // ´ëÀü±¤¿ª½Ã
    new string[] { "µ¿±¸", "Áß±¸", "¼­±¸", "À¯¼º±¸", "´ë´ö±¸" },

    // ¿ï»ê±¤¿ª½Ã
     new string[]{ "Áß±¸", "³²±¸", "µ¿±¸", "ºÏ±¸", "¿ïÁÖ±º" }
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

        infoTextName.text = $"ÀÌ¸§ : {GenerateName()}";
        infoTextINumText.text = "ÁÖ¹Î ¹øÈ£ : ";
        infoTextINum.text = $"{INum}";
        infoTextEtc.text = $"ÁÖ¼Ò : {address}\n" +
            $"¹ß±Þ ÀÏÀÚ : {GenerateIDate(INum.Substring(0,8), isAlien)}\n" +
            $"¹ß±Þ Àå¼Ò : {address}Ã»";

        for(int i = 0; i < faceImgArr.Length; i++)
        {
            if (isAlien && i==1) { //i==1: ¸ÞÀÎ ¼Õ´Ô ÀÌ¹ÌÁö ÀÎµ¦½º
                faceImgArr[i].sprite = alienData.faces[Random.Range(0, 6)];
                eyeImgArr[i].sprite = alienData.eyes[Random.Range(0, 6)];
                noseImgArr[i].sprite = alienData.noses[Random.Range(0, 6)];
                mouthImgArr[i].sprite = alienData.mouths[Random.Range(0, 6)];
                hairFrontImgArr[i].sprite = personData.hairs_front[idx[2]];
                hairBackImgArr[i].sprite = personData.hairs_back[idx[2]];//¾Õ ¸Ó¸®¿Í µÞ ¸Ó¸® ·£´ý ¼±ÅÃ ÀÎµ¦½º °ª °°À½
            }
            else {
                faceImgArr[i].sprite = personData.faces[idx[0]];
                eyeImgArr[i].sprite = personData.eyes[idx[1]];
                hairFrontImgArr[i].sprite = personData.hairs_front[idx[2]];
                hairBackImgArr[i].sprite = personData.hairs_back[idx[2]];//¾Õ ¸Ó¸®¿Í µÞ ¸Ó¸® ·£´ý ¼±ÅÃ ÀÎµ¦½º °ª °°À½
                noseImgArr[i].sprite = personData.noses[idx[3]];
                mouthImgArr[i].sprite = personData.mouths[idx[4]];
            }
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
                                                //Æ¯Á¤ ´Þ ÀÎµ¦½º Á¢±Ù À§ÇØ - 1 ÇØ ÁÜ
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
            //¹ÎÁõÀº ¸¸ 17¼¼°¡ µÈ »ýÀÏ³¯ ´ÙÀ½ ³¯ºÎÅÍ 1³â °£ ¹ß±Þ °¡´É
            year = Random.Range(birthYear + 17, birthYear + 17 + 2);
            //¸¸ 17¼¼°¡ µÈ ÇØ¿¡ ¹ß±Þ ¹ÞÀ½
            if (year == (birthYear + 17))
            {
                month = Random.Range(birthMonth, 13); // »ýÀÏÀÌ ÀÖ´Â ´Þ ~ 12¿ù ¹ß±Þ
                if (month == birthMonth) day = Random.Range(birthDay + 1, days[month - 1] + 1);
                else day = Random.Range(1, days[month - 1] + 1);
            }
            //±× ´ÙÀ½ ÇØ¿¡ ¹ß±Þ ¹ÞÀ½
            else
            {
                month = Random.Range(1, birthMonth + 1); //1¿ù ~ »ýÀÏÀÌ ÀÖ´Â ´Þ
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

    // ÁÖ¹Î¹øÈ£ º¯Á¶
    public string FalsifyINum()
    {
        int randomNum = (Random.Range(1, 4));    // º¯Á¶½ÃÅ³ ¹æ¹ý ¼¼ °¡Áö Áß ¾î¶² °ÍÀ¸·Î ÇÒÁö 1 ~ 3 Áß ·£´ý°ªÀ» ±¸ÇÔ
        string INum;    // ÁÖ¹Î¹øÈ£

        switch (randomNum)
        {
            case 1: // Ã¹ ¹øÂ°, ÇöÀç ³¯Â¥ ±âÁØ¿¡ ¸ÂÁö ¾Ê´Â ¼ö (ex. 13¿ù 43ÀÏ)
                string birthYear;
                bool isBornAfter2000 = (Random.Range(0, 2) == 1);       // ·£´ý°ªÀÌ 0ÀÌ¸é 1900³â´ë»ýÀ¸·Î false °ª ´ëÀÔ, ·£´ý°ªÀÌ 1ÀÌ¸é 2000³â´ë»ýÀ¸·Î true °ª ´ëÀÔ
                if (isBornAfter2000)    // 2000³â´ë»ýÀÌ¸é
                    birthYear = Random.Range(0, 10).ToString("D2");     // ÁÖ¹Î¹øÈ£ ¾Õ µÎ ÀÚ¸® 00 ~ 09
                else                    // 1900³â´ë»ýÀÌ¸é 
                    birthYear = Random.Range(0, 100).ToString("D2");    // ÁÖ¹Î¹øÈ£ ¾Õ µÎ ÀÚ¸® 00 ~ 99
                int birthMonth = Random.Range(0, 100);   // ¿ù ºÎºÐ 00 ~ 99

                string birthDay;

                if (birthMonth >= 1 && birthMonth <= 12)  // ¿ùÀÌ 1¿ù ~ 12¿ùÀÌ¸é
                    birthDay = Random.Range(32, 100).ToString("D2");   // ÀÏÀ» 32 ~ 99·Î
                else
                    birthDay = Random.Range(0, 100).ToString("D2");   // ÀÏÀ» 00 ~ 99·Î
                string gender = Random.Range(0, 10).ToString();     // ÁÖ¹Î¹øÈ£ µÞÀÚ¸® Ã¹ ¹øÂ° ¼ýÀÚ´Â 0 ~ 9

                return $"{birthYear}{birthMonth.ToString("D2")}{birthDay}-{gender}******";
            case 2: // µÎ ¹øÂ°, Á¤»óÀûÀÎ ÁÖ¹Î¹øÈ£Áö¸¸, ¸Þ¸ð¿Í °ªÀÌ ´Ù¸¥ °æ¿ì
                INum = GenerateINum();   // Á¤»óÀûÀÎ ÁÖ¹Î¹øÈ£ »ý¼º
                string memoINum = GenerateINum();

                while (INum.Equals(memoINum))   // ÁÖ¹Î¹øÈ£¿Í ¸Þ¸ðÀÇ »ý³â¿ùÀÏÀÌ ÀÏÄ¡ÇÏ´Ù¸é
                {
                    INum = GenerateINum();   // ´Ù½Ã ÁÖ¹Î¹øÈ£ »õ·Î ¹ß±Þ
                }

                return INum;
            case 3: // ¼¼ ¹øÂ°, ÆùÆ®¸¦ ´Ù¸£°Ô ÇÏ´Â ¹æ¹ý
                INum = GenerateINum();

                // ÆùÆ® º¯°æ
                infoTextINum.font = pyeongChangFont;

                return INum;
            default:
                return "¿¡·¯";
        }
    }
}
>>>>>>> Dory
