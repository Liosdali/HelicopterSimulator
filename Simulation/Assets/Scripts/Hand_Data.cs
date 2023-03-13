using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Data : MonoBehaviour
{
    public enum HandModelType {Right , Left}

     public HandModelType handType;
    public Transform root;
    public Animator animator;
    public Transform[] fingerBones;  
}
