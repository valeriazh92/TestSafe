using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SafeController : MonoBehaviour
{

    public static event Action PuzzleCompliteHandler;
    [SerializeField] private SafeData m_safeData;
    public List<PinController> pin;
    private List <int> safecode;
    private List<int> enteredCode;
    private List<int> startPinPos;
    int pinN;
    private void Start()
    {
        safecode = new List<int>();
        for (int i = 0; i < pin.Count; i++)
        {
            safecode.Add(m_safeData.Pin[i]);
        }
        
        startPinPos = new List<int>();
        for (int i = 0; i < pin.Count; i++)
        {
            startPinPos.Add(m_safeData.PinstartPos[i]);
        }
       
        for (int i = 0; i < pin.Count; i++)
        {
            safecode[i] = Mathf.Clamp(safecode[i], 1, 6);
            startPinPos[i] = Mathf.Clamp(startPinPos[i], 1, 6);
        }
       
        SetStartPositions();
        for (int i = 0; i < pin.Count; i++)
        {
            Debug.Log("safe" + safecode[i]);
            
        }
        PinController.CodeChanged += CheckResults;
        SafeDoorController.WindowOpenHandler += SetStartPositions;
    }

    private void CheckResults(string pinNum, int number)
    {
        pinNum = pinNum.Substring(4);
        pinNum = pinNum.Substring(0, pinNum.Length - 1);
        if (Int32.TryParse(pinNum, out pinN))
        {
            Debug.Log("It's pin "+ pinN);
        }
        enteredCode[pinN] = number;

        for (int i = 0; i < pin.Count; i++)
        {
            Debug.Log(pin[i]+" "+enteredCode[i]);
        }
        int rightelements = 0;
        for (int i = 0; i < pin.Count; i++)
        {
            if (safecode[i] == enteredCode[i]) { rightelements++; }
        }
        if(rightelements== pin.Count)
        {
            Debug.Log("It's opened!");
            PuzzleCompliteHandler.Invoke();
        }
    }

    private void SetStartPositions()
    {
        enteredCode = new List<int>();
       
       
        for (int i = 0; i < pin.Count; i++)
        {
            enteredCode.Add(startPinPos[i]);
            pin[i].SetStartPosition(startPinPos[i]);
        }
    }
}
