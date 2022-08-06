using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ������ ���� ����
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
            print($"������ ���� {haveItemData.version}");
        }
        else
            print($"������ ���� {haveItemData.version}");

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
        print($"���� ����:{haveItemData.version}");
        UpdateVersionText();
    }

    private void UpdateVersionText()
    {
        text.text = haveItemData.version.ToString();
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
        string json = JsonUtility.ToJson(haveItemData);
        PlayerPrefs.SetString(HaveItemData.Key, json);
        PlayerPrefs.Save();
    }
}
