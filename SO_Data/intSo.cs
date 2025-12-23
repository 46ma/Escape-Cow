using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

[CreateAssetMenu]
public class intSo : ScriptableObject //ScriptableObject intSo
{
    [SerializeField]
    private int _value;

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
