using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestManager_CreateGameObjects : MonoBehaviour
{
    const float WIDTH = 200f;
    const float HEIGHT = 100f;

    List<GameObject> ObjectList = new List<GameObject>();

    private void OnGUI()
    {
        //TestButton_CreateObjects();
        TestButton_CreateComponent();
    }
    CreateComponent addComponent;
    void TestButton_CreateComponent()
    {
        if (GUI.Button(new Rect(0, 0, WIDTH, HEIGHT), "Create"))
        {
            addComponent=    this.gameObject.AddComponent<CreateComponent>();
        }
        if (GUI.Button(new Rect(WIDTH, 0, WIDTH, HEIGHT), "Destroy"))
        {
            Destroy(addComponent);
            GC.Collect();

        }
    }


    void TestButton_CreateObjects()
    {
        if (GUI.Button(new Rect(0, 0, WIDTH, HEIGHT), "Destroy"))
        {
            DestroyGameObject();
        }
        if (GUI.Button(new Rect(WIDTH, 0, WIDTH, HEIGHT), "100"))
        {
            CreateGameObject(100);
        }
        if (GUI.Button(new Rect(WIDTH * 2, 0, WIDTH, HEIGHT), "1000"))
        {
            CreateGameObject(1000);
        }
        if (GUI.Button(new Rect(WIDTH * 3, 0, WIDTH, HEIGHT), "10000"))
        {
            CreateGameObject(10000);
        }
    }
    void DestroyGameObject()
    {
        if (ObjectList.Count > 0)
        {
            for (int i = 0; i < ObjectList.Count; i++)
                GameObject.Destroy(ObjectList[i]);

            ObjectList.Clear();
        }
    }
    void CreateGameObject(int _amount)
    {
        for (int i = 0; i < _amount; i++)
            ObjectList.Add(new GameObject(i.ToString()));
    }

}
