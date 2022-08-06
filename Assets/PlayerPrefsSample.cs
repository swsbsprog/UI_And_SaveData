using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSample : MonoBehaviour
{
    public int defaultValue = 100;
    string key1 = "key1";
    string key2 = "key2";

    void Start()
    {
        print(PlayerPrefs.GetInt(key1, defaultValue)); // ����� �� �����Ƿ� 100 ���
        //PlayerPrefs.GetFloat(key1); // float
        //PlayerPrefs.GetString(key2);// string

        PlayerPrefs.SetInt(key2, 1); // key2�� 1����
        print(PlayerPrefs.GetInt(key2, defaultValue)); // �⺻�� �־ ����� Ű�� ���� �����Ƿ� 1���

        
        PlayerPrefs.Save(); // ���Ͽ� �����ϴ� ������ ���ϰ� ũ��.
                            // �׷��� �޸𸮿� ����ϰ� �ִٰ� Ư�� Ÿ�̹�(�� ����)�� �����Ѵ�.
                            // ���μ��� ���� ����� ���� �� ����ȵ�(��:�޴��� ���͸� ����, ��ǻ�� ���� �ڵ� ����,..)
                            // ������ �н��� ���� ���ؼ� �޸𸮿� �ִ� �� ������ ����

        print(PlayerPrefs.HasKey(key2)); // true, ����� ���� �ִ��� Ȯ��
        PlayerPrefs.DeleteKey(key2); //����� �� ����
        print(PlayerPrefs.HasKey(key2)); // false

        PlayerPrefs.DeleteAll();// ��� �� ����.

        //UnityEditor.EditorPrefs // <- �����Ϳ��� ����ϴ� ���� <- �����Ǵ� ���ӿ� ���Ұ�.
        //Save�Լ��� ����. Set�Ҷ� �ٷ� ����ȴ�.
    }
}
