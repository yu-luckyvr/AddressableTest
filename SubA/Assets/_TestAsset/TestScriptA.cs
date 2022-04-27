using System.Collections.Generic;
using UnityEngine;
using VrGamesDev.DDuA;

public class TestScriptA : MonoBehaviour
{

    [SerializeField]
    protected  List<string> addresses;
    private int index;
    
    [SerializeField]
    protected VRG_Addressable m_Addressable = null;
    
     
    public void Create()
    {
        this.m_Addressable.Play("TesObject2");
        
        
        
        this.m_Addressable.Play(addresses[index]);
        index++;
        if (index >= addresses.Count) index = 0;
    }

    public void Destroy()
    {
        this.m_Addressable.Destroy();
    }
}
