using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 데이터 저장 샘플
public class SaveData : MonoBehaviour
{
    public TMP_Text text;

    [System.Serializable]
    public class HaveItemData
    {
        public const string Key = "MyData";
        public int version = 1;
        public int gold;
        public int score;
        public bool useSound;
    }
    public HaveItemData haveItemData;

    void Start()
    {
        string json = PlayerPrefs.GetString(HaveItemData.Key);
        if (!string.IsNullOrEmpty(json))
        {
            haveItemData = JsonUtility.FromJson<HaveItemData>(json);
            print($"데이터 읽음 {haveItemData.version}");
        }
        else
            print($"데이터 없음 {haveItemData.version}");

        UpdateVersionText();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            VersionUp();
        }
    }

    public void VersionUp()
    {
        haveItemData.version++;
        print($"버전 증가:{haveItemData.version}");
        UpdateVersionText();
    }

    private void UpdateVersionText()
    {
        text.text = haveItemData.version.ToString();
    }

    // 에디터에서 사용, 휴대폰에서 작동안함(프로세스가 죽어서 저장 못함)
    private void OnDestroy() => SaveSerializeData();


    // 휴대폰에서 사용.(앱 끄기 위해서 비활성화 할때 저장)
    void OnApplicationPause(bool pauseStatus) // pauseStatus == true -> 앱이 멈췄다
    {
        print($"pauseStatus:{(pauseStatus?"멈췄다":"다시시작")}");
        if(pauseStatus)
            SaveSerializeData();
    }

    private void SaveSerializeData()
    {
        print($"데이터 저장");
        string json = JsonUtility.ToJson(haveItemData);
        PlayerPrefs.SetString(HaveItemData.Key, json);
        PlayerPrefs.Save();
    }
}
