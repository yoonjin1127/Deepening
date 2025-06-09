using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���׸� ��� �̱��� ���� Ŭ����
public class Singleton<T> : MonoBehaviour where T : Component
{
    // ���� �ν��Ͻ��� �����ϴ� ���� ����
    protected static T _instance;

    // �ν��Ͻ��� ���� ����
    public static bool HasInstance => _instance != null;

    // �ν��Ͻ��� �����ϸ� ��ȯ, ������ null ��ȯ
    public static T TryGetInstance() => HasInstance ? _instance : null;

    // ���� �ν��Ͻ� ���� ��ȯ
    public static T Current => _instance;

    /// <summary>
    /// �ν��Ͻ��� �������� ������Ƽ. ������ ����
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();  // ���� �̹� �����ϴ� TŸ�� ��ü Ž��

                if(_instance == null)
                {
                    Create(true);   // ������ ����(DontDestroyOnLoad)
                }

                else
                {
                    // ���� �̹� �־����� DontDestroyOnLoad�� �� ���� �� ����
                    DontDestroyOnLoad(_instance.gameObject);
                }
                
            }
            return _instance;
        }
    }

    /// <summary>
    /// �ν��Ͻ��� ������ �� ���� ������Ʈ�� ���� (DontDestroyOnLoad ����)
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
    /// �ν��Ͻ��� ������ �� ���� ������Ʈ�� ����, DontDestroyOnLoad ���� ���� ���� ����
    /// </summary>
    public static void Create(bool dontDestroy)
    {
        if (_instance == null)
        {
            GameObject obj = new GameObject(typeof(T).Name);
            obj.name = typeof(T).Name + "_AutoCreated";
            _instance = obj.AddComponent<T>();

            // �� ��ȯ�� �ı����� �ʵ��� ����
            if (dontDestroy) DontDestroyOnLoad(obj);
        }
    }

    /// <summary>
    /// Awake���� �̱��� �ν��Ͻ��� �ʱ�ȭ��
    /// ����� Ŭ�������� Awake�� �������̵��� ��� base.Awake() ȣ�� �ʼ�
    /// </summary>
    protected virtual void Awake()
    {
        InitializeSingleton();
    }


    /// <summary>
    /// �̱��� �ν��Ͻ��� ������
    /// </summary>
    protected virtual void InitializeSingleton()
    {
        if (!Application.isPlaying)
        {
            return; // ������ ��忡���� ����
        }

        if (_instance == null)
        {
            _instance = this as T;  // ���� ������Ʈ�� TŸ������ ĳ�����Ͽ� ����

            // ���� ��ġ�Ǿ� �ֵ� �ڵ� �����ǵ�, ������ ����
            DontDestroyOnLoad(gameObject);
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
