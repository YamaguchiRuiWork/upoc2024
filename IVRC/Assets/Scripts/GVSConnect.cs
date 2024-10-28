using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class GVSConnect : MonoBehaviour
{
    // Arduinoとのシリアル通信に使用するポート名    
    [SerializeField] private string portName = "COM3";

    // Arduinoとの通信レート
    [SerializeField] private int baudRate = 9600;

    private float current;

    private bool changeFlg = false;

    private SerialPort serialPort;

    //送信用byte配列
    byte[] sendBytes = new byte[4];
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (changeFlg) SendSignalToArduino();
    }

    public void SetCurrent(float c)
    {
        if (current != c)
        {
            current = c;
            changeFlg = true;
        }
    }

    private void SendSignalToArduino()
    {
        // Arduinoに信号を送信（終端文字 '\n' を付加）
        Debug.Log("current : " + current);
        sendBytes = BitConverter.GetBytes(current);
        serialPort.Write(sendBytes, 0, 4);
        changeFlg = false;
    }


    private void OnApplicationQuit()
    {
        // アプリケーション終了時にシリアルポートを閉じる
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
