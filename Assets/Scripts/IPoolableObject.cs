using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableObject 
{
    public delegate void OnDisable(IPoolableObject poolableObject);
    public event OnDisable OnDestroy;
}
