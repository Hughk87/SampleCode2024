using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateComponent : MonoBehaviour
{
    
    public CreateComponent()
    {
        Debug.Log("CreateComponent :: Creator");
    }
     ~CreateComponent()
    {
        Debug.Log("CreateComponent :: Destructor");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    void Awake()
    {
        Debug.Log("Awake");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
