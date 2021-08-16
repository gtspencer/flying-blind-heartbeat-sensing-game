using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class USBListener : MonoBehaviour
{
    SerialPort serial;
    public int baseLineCount = 10;
    int count;
    float total = 0f;
    bool baselineCalculated = false;
    public PlaneBehavior plane;
    public Moving move;
    public String usbPortName = "";
    // Start is called before the first frame update
    void Start()
    {
        //serial = new SerialPort("COM5", 9600);    //windows
        serial = new SerialPort("/dev/cu.usbmodem" + usbPortName, 9600);    //mac
        ////serial.DataReceived += serial_DataReceived;
        serial.ReadTimeout = 1;
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            //Debug.Log(serial.ReadLine());
            processData(serial.ReadLine());
        }
        catch (TimeoutException ex)
        {
            
        }
        if (count == baseLineCount && !baselineCalculated)
        {
            baselineCalculated = true;
            total = total / baseLineCount;
            Debug.Log("Baseline: " + total);
            move.StartMove();
        }
        /**
        foreach (string str in System.IO.Ports.SerialPort.GetPortNames())
        {
            Debug.Log(str);
        }
        
        string[] str = SerialPort.GetPortNames();
        foreach (string st in str)
        {
            Debug.Log(st);
        }
        */  
    }

    void processData(string data)
    {
        if (!baselineCalculated)
        {
            int num1;
            bool success1 = Int32.TryParse(data, out num1);
            if (num1 > 30 && count < baseLineCount && success1)
            {
                Debug.Log("HeartBeat: " + num1);
                total += num1;
                count++;
            }
        }
        if (baselineCalculated)
        {
            int num;
            bool success = Int32.TryParse(data, out num);
            if (success)
            {
                if (num > total && num > 30)
                {
                    sendUpMessage();
                    Debug.Log("HeartBeat: " + num);
                    total = total * count;
                    total += num;
                    count++;
                    total = total / count;
                    Debug.Log("Avg: " + total);
                }
                else if (num < total && num > 30)
                {
                    sendDownMessage();
                    Debug.Log("HeartBeat: " + num);
                    total = total * count;
                    total += num;
                    count++;
                    total = total / count;
                    Debug.Log("Avg: " + total);
                }
            }
        }
    }

    void sendUpMessage()
    {
        Debug.Log("Go Up");
        plane.sendUp();
    }

    void sendDownMessage()
    {
        Debug.Log("Go Down");
        plane.sendDown();
    }
}
