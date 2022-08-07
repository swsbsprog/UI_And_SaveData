using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 데이터 저장 샘플
public class SaveDataSample : MonoBehaviour
{
    public TMP_Text text;

    public UserData userData;

    void Awake()
    {
        string json = PlayerPrefs.GetString(UserData.Key);
        if (!string.IsNullOrEmpty(json))
        {
            userData = JsonUtility.FromJson<UserData>(json);
            print($"데이터 읽음 {userData.version}");
        }
        else
            print($"데이터 없음 {userData.version}");

        UpdateVersionText();
    }

    public void VersionUp()
    {
        userData.version++;
        print($"버전 증가:{userData.version}");
        UpdateVersionText();
    }

    private void UpdateVersionText() => text.text = userData.version.ToString();

    // 에디터에서 사용, 휴대폰에서 작동안함(프로세스가 죽어서 저장 못함)
    private void OnDestroy() => SaveSerializeData();


    // 휴대폰에서 사용.(앱 끄기 위해서 비활성화 할때 저장)
    void OnApplicationPause(bool pauseStatus) // pauseStatus == true -> 앱이 멈췄다
    {
        print($"pauseStatus:{(pauseStatus ? "멈췄다" : "다시시작")}");
        if (pauseStatus)
            SaveSerializeData();
    }

    private void SaveSerializeData()
    {
        print($"데이터 저장");
        string json = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString(UserData.Key, json);
        PlayerPrefs.Save();
    }
    [System.Serializable]
    public class UserData
    {
        public const string Key = nameof(UserData); //"UserData"
        public int version = 1;
        public int gold;
        public int score;
        public bool useSound;
        public List<string> haveItem = new List<string>();
        //public Dictionary<string, string> haveItemDic = new(); //직열화 안됨
        //public HashSet<string> haveItemSet = new(); 직열화 안됨
    }
}
