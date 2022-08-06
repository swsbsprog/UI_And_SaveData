using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� ����
public class SaveData : MonoBehaviour
{
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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            haveItemData.version++;
            print($"���� ����:{haveItemData.version}");
        }
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
