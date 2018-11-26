using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DestroyOnContact))]
public abstract class Animal : MonoBehaviour 
{
    public abstract void Effect();
}
