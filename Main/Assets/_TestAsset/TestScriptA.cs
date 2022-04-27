using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using VrGamesDev.DDuA;

public class TestScriptA : MonoBehaviour
{

    [SerializeField] 
    protected string catalog;


    [SerializeField]
    protected  List<string> addresses;
    private int index;
    
    [SerializeField]
    protected VRG_Addressable m_Addressable = null;
    private VRG_AddressableScene m_Scene = new VRG_AddressableScene("VRG_DDuA_Proxy");

    public IEnumerator Start()
    {
        if (string.IsNullOrEmpty(catalog)) yield break;
        
       AsyncOperationHandle<IResourceLocator> handle
            = Addressables.LoadContentCatalogAsync(catalog, true);
    
        yield return handle;
    }
    
     
    public void Create()
    {
        this.m_Addressable.Play(addresses[index]);
        index++;
        if (index >= addresses.Count) index = 0;
    }

    public void Destroy()
    {
        this.m_Addressable.Destroy();
        
        
    }
}
