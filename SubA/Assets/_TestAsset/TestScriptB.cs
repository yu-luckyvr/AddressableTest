using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptB : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        obj.GetComponent<Renderer>().material.color = Color.red;
    }
}
