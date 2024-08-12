using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MicAudioFallDownTrees : MonoBehaviour
{
    [SerializeField] private string m_DeviceName;
    [SerializeField] private GameObject[] Treearray = new GameObject[3];
    [SerializeField] private int TreeNumberMax = 3;
    //[SerializeField] private float nowTime;
    private int TreeNumber = 0;
    private const int SAMPLE_RATE = 48000;
    private const float MOVING_AVE_TIME = 0.05f;
    private Animator anim;  //Animatorをanimという変数で定義する
    private bool FallDownFlag;

    //MOVING_AVE_TIMEに相当するサンプル数
    private const int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);

    private AudioSource m_MicAudioSource;

    //[SerializeField] private GameObject m_Cube;
    [SerializeField, Range(10, 300)] private float m_AmpGain = 100;
    [SerializeField] private float AudioScale;

    private void Awake()
    {
        m_MicAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        string targetDevice = "";

        foreach (var device in Microphone.devices)
        {
            Debug.Log($"Device Name: {device}");
            if (device.Equals(m_DeviceName))
            {
                targetDevice = device;
            }
        }

        Debug.Log($"=== Device Set: {targetDevice} ===");
        MicStart(targetDevice);
        Shuffle(Treearray);
        //nowTime = 0;
        //anim = gameObject.GetComponent<Animator>();
        //anim = Treearray[TreeNumber].GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(TreeNumber);
        if (!m_MicAudioSource.isPlaying) return;

        //FallDownFlag = anim.GetBool("FallDownFlag");
        //Debug.Log(FallDownFlag);

        float[] waveData = new float[MOVING_AVE_SAMPLE];
        m_MicAudioSource.GetOutputData(waveData, 0);

        //バッファ内の平均振幅を取得（絶対値を平均する）
        float audioLevel = waveData.Average(Mathf.Abs);
        //m_Cube.transform.localScale = new Vector3(1, 1 + m_AmpGain * audioLevel, 1);
        //Debug.Log(audioLevel);
        if (m_AmpGain * audioLevel > AudioScale && TreeNumber < TreeNumberMax)
        {
            anim = Treearray[TreeNumber].GetComponent<Animator>();
            anim.SetBool("FallDownFlag", true);
            Debug.Log("AnimStart");

            //if (TreeNumber < 2)
            //{
            //TreeNumber++;
            // }
        }

    }

    private void MicStart(string device)
    {
        if (device.Equals("")) return;

        m_MicAudioSource.clip = Microphone.Start(device, true, 1, SAMPLE_RATE);

        //マイクデバイスの準備ができるまで待つ
        while (!(Microphone.GetPosition("") > 0)) { }

        m_MicAudioSource.Play();
    }
    public int TreeNumberGetter()
    {
        // _piyppiyoの値を返す
        return TreeNumber;
    }
    public int TreeNumberMaxGetter()
    {
        return TreeNumberMax;
    }
    /// <summary>
    /// _piyopiyoのセッター
    /// </summary>
    /// <param name="value">_piyopiyoに代入する値</param>
    public void TreeNumberSetter(int value)
    {
        // _piyopiyoに値を代入する
        TreeNumber = value;
    }

    void Shuffle(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i]; // 現在の要素を預けておく
            int randomIndex = Random.Range(0, num.Length); // 入れ替える先をランダムに選ぶ
            num[i] = num[randomIndex]; // 現在の要素に上書き
            num[randomIndex] = temp; // 入れ替え元に預けておいた要素を与える
        }
    }
    /*void DestroyTree()
    {
        Debug.Log("Destroy!");
        Destroy(this.gameObject);
    }/*
    /*
    void AddTreeNumber()
    {
        if (TreeNumber < 2)
        {
            TreeNumber++;
            Debug.Log(TreeNumber);
        }
    }
    */
}
