using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MicAudioFallDown : MonoBehaviour
{
    [SerializeField] private string m_DeviceName;
    private const int SAMPLE_RATE = 48000;
    private const float MOVING_AVE_TIME = 0.05f;
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����

    //MOVING_AVE_TIME�ɑ�������T���v����
    private const int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);

    private AudioSource m_MicAudioSource;

    //[SerializeField] private GameObject m_Cube;
    [SerializeField, Range(10, 300)] private float m_AmpGain = 100;
    [SerializeField] private int AudioScale;

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
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!m_MicAudioSource.isPlaying) return;

        float[] waveData = new float[MOVING_AVE_SAMPLE];
        m_MicAudioSource.GetOutputData(waveData, 0);

        //�o�b�t�@���̕��ϐU�����擾�i��Βl�𕽋ς���j
        float audioLevel = waveData.Average(Mathf.Abs);
        //m_Cube.transform.localScale = new Vector3(1, 1 + m_AmpGain * audioLevel, 1);
        if (m_AmpGain * audioLevel > AudioScale)
        {
            anim.SetBool("FallDownFlag", true);
            Debug.Log("AnimStart");
        }

    }

    private void MicStart(string device)
    {
        if (device.Equals("")) return;

        m_MicAudioSource.clip = Microphone.Start(device, true, 1, SAMPLE_RATE);

        //�}�C�N�f�o�C�X�̏������ł���܂ő҂�
        while (!(Microphone.GetPosition("") > 0)) { }

        m_MicAudioSource.Play();
    }

    void DestroyTree()
    {
        Debug.Log("Destroy!");
        Destroy(this.gameObject);
    }
}
