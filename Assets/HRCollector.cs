using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
//using System.IO.Ports;

public class HRCollector : MonoBehaviour
{
    /**
    SerialPort arduino;
    volatile bool stopCollecting = false;
    public volatile int HeartRate = -1;
    public volatile int IBI = -1;
    Thread collectionThread;
    public string MyPort()
    {
        return (arduino == null) ? "" : arduino.PortName;
    }

    public HRCollector()
    {
    }

    public bool Connect()
    {
        bool connected = false;
        var allPorts = new List<String>(SerialPort.GetPortNames());
        foreach (var item in allPorts)
        {
            if (IsArduino(item))
            {
                //success!
                arduino = PortNamed(item, 115200, Parity.None, StopBits.One, 8);
                connected = true;
                break;
            }
            else
            {
                //couldn't connect to arduino
            }
        }

        return connected;
    }

    public bool IsArduino(string portname)
    {
        int validationTries = 10;
        SerialPort arduino = PortNamed(portname, 115200, Parity.None, StopBits.One, 8);
        try
        {
            arduino.ReadTimeout = 500;
            arduino.Open();
            if (arduino.BytesToRead <= 0)
            {
                Thread.Sleep(500);
            }

            for (int i = 0; i < validationTries; i++)
            {
                string msg = arduino.ReadLine();
                if (msg.StartsWith("B:"))
                {
                    arduino.Close();
                    return true;
                }
            }
        }
        catch
        {
            arduino.Close();
        }

        return false;
    }

    public SerialPort PortNamed(string portName, int baudrate, Parity parity, StopBits stopbits, int bytesize)
    {
        var port = new SerialPort(portName);
        port.BaudRate = baudrate;
        port.Parity = parity;
        port.StopBits = stopbits;
        port.DataBits = bytesize;
        return port;
    }

    public void StartCollecting()
    {
        stopCollecting = false;
        collectionThread = new Thread(new ThreadStart(CollectorTask));
        collectionThread.Start();
    }

    public void StopCollecting()
    {
        stopCollecting = true;
    }

    void CollectorTask()
    {
        arduino.Open();
        while (!stopCollecting)
        {
            if (arduino.BytesToRead > 0)
            {
                ReadData();
            }
        }

        arduino.Close();
    }

    void ReadData()
    {
        //read line from arduino
        string msg = arduino.ReadLine();
        var values = msg.Split('B', 'Q');
        //parse heart rate
        int tmpHR = HeartRate;
        int.TryParse(values[0], out tmpHR);
        HeartRate = tmpHR;
        //parse inter-beat interval
        int tmpIBI = IBI;
        int.TryParse(values[1], out tmpIBI);
        IBI = tmpIBI;
    }
    */
}
