using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ������ ���� ����
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
            print($"������ ���� {userData.version}");
        }
        else
            print($"������ ���� {userData.version}");

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
        userData.version++;
        print($"���� ����:{userData.version}");
        UpdateVersionText();
    }

    private void UpdateVersionText()
    {
        text.text = userData.version.ToString();
    }

    // �����Ϳ��� ���, �޴������� �۵�����(���μ����� �׾ ���� ����)
    private void OnDestroy() => SaveSerializeData();


    // �޴������� ���.(�� ���� ���ؼ� ��Ȱ��ȭ �Ҷ� ����)
    void OnApplicationPause(bool pauseStatus) // pauseStatus == true -> ���� �����
    {
        print($"pauseStatus:{(pauseStatus?"�����":"�ٽý���")}");
        if(pauseStatus)
            SaveSerializeData();
    }

    private void SaveSerializeData()
    {
        print($"������ ����");
        string json = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString(UserData.Key, json);
        PlayerPrefs.Save();
    }
    [System.Serializable]
    public class UserData
    {
        public const string Key = nameof(UserData);
        public int version = 1;
        public int gold;
        public int score;
        public bool useSound;
        public List<string> haveItem = new List<string>();
    }
}
