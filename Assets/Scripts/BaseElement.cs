using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseElement : MonoBehaviour
{
    public App app{
        get {
            return GameObject.FindObjectOfType<App>();
        }
    }
}
