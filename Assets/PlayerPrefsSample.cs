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
        print(PlayerPrefs.GetInt(key1, defaultValue)); // 저장된 값 없으므로 100 출력
        //PlayerPrefs.GetFloat(key1); // float
        //PlayerPrefs.GetString(key2);// string

        PlayerPrefs.SetInt(key2, 1); // key2에 1저장
        print(PlayerPrefs.GetInt(key2, defaultValue)); // 기본값 있어도 저장된 키의 값이 있으므로 1출력

        
        PlayerPrefs.Save(); // 파일에 저장하는 로직은 부하가 크다.
                            // 그래서 메모리에 기억하고 있다가 특정 타이밍(앱 종료)에 저장한다.
                            // 프로세스 강제 종료로 끄면 값 저장안됨(예:휴대폰 배터리 부족, 컴퓨터 전원 코드 끄기,..)
                            // 데이터 분실을 막기 위해서 메모리에 있는 값 강제로 저장

        print(PlayerPrefs.HasKey(key2)); // true, 저장된 값이 있는지 확인
        PlayerPrefs.DeleteKey(key2); //저장된 값 삭제
        print(PlayerPrefs.HasKey(key2)); // false

        PlayerPrefs.DeleteAll();// 모든 값 삭제.

        //UnityEditor.EditorPrefs // <- 에디터에서 사용하는 버전 <- 배포되는 게임에 사용불가.
        //Save함수가 엇다. Set할때 바로 저장된다.
    }
}
