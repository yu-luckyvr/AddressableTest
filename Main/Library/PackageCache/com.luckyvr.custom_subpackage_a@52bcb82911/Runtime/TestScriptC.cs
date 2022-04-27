using UnityEngine;

public class TestScriptC : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        obj.GetComponent<Renderer>().material.color = Color.green;
    }
}
