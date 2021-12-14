using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SafeCode", menuName = "ScriptableObjects/SafeCode", order = 1)]
public class SafeData : ScriptableObject
{
   
    [Tooltip("Enter start position here")]
    [SerializeField] private List<int> pinDefoultPos;
    [Tooltip("Enter right code here")]
    [SerializeField] private List<int> pinCode;


    public List<int>PinstartPos
    {
        get
        { return pinDefoultPos; }
       
    }
    public List<int> Pin
    {
        get
        { return pinCode; }
        
    }

}
