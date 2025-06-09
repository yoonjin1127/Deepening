using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제네릭 기반 싱글톤 패턴 클래스
public class Singleton<T> : MonoBehaviour where T : Component
{
    // 현재 인스턴스를 저장하는 정적 변수
    protected static T _instance;

    // 인스턴스의 존재 여부
    public static bool HasInstance => _instance != null;

    // 인스턴스가 존재하면 반환, 없으면 null 반환
    public static T TryGetInstance() => HasInstance ? _instance : null;

    // 현재 인스턴스 직접 반환
    public static T Current => _instance;

    /// <summary>
    /// 인스턴스를 가져오는 프로퍼티. 없으면 생성
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();  // 씬에 이미 존재하는 T타입 객체 탐색

                if(_instance == null)
                {
                    Create(true);   // 없으면 생성(DontDestroyOnLoad)
                }

                else
                {
                    // 씬에 이미 있었지만 DontDestroyOnLoad가 안 됐을 수 있음
                    DontDestroyOnLoad(_instance.gameObject);
                }
                
            }
            return _instance;
        }
    }

    /// <summary>
    /// 인스턴스가 없으면 새 게임 오브젝트로 생성 (DontDestroyOnLoad 없음)
    /// </summary>
    public static void Create()
    {
        if (_instance == null)
        {
            GameObject obj = new GameObject(typeof(T).Name);
            obj.name = typeof(T).Name + "_AutoCreated";
            _instance = obj.AddComponent<T>();
        }
    }

    /// <summary>
    /// 인스턴스가 없으면 새 게임 오브젝트로 생성, DontDestroyOnLoad 설정 여부 선택 가능
    /// </summary>
    public static void Create(bool dontDestroy)
    {
        if (_instance == null)
        {
            GameObject obj = new GameObject(typeof(T).Name);
            obj.name = typeof(T).Name + "_AutoCreated";
            _instance = obj.AddComponent<T>();

            // 씬 전환시 파괴되지 않도록 설정
            if (dontDestroy) DontDestroyOnLoad(obj);
        }
    }

    /// <summary>
    /// Awake에서 싱글톤 인스턴스를 초기화함
    /// 상속한 클래스에서 Awake를 오버라이드할 경우 base.Awake() 호출 필수
    /// </summary>
    protected virtual void Awake()
    {
        InitializeSingleton();
    }


    /// <summary>
    /// 싱글톤 인스턴스를 설정함
    /// </summary>
    protected virtual void InitializeSingleton()
    {
        if (!Application.isPlaying)
        {
            return; // 에디터 모드에서는 무시
        }

        if (_instance == null)
        {
            _instance = this as T;  // 현재 컴포넌트를 T타입으로 캐스팅하여 저장

            // 씬에 배치되어 있든 자동 생성되든, 무조건 유지
            DontDestroyOnLoad(gameObject);
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
