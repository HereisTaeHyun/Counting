using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public Transform sphere;
    public Transform[] spheres;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
        spheres = sphere.GetComponentsInChildren<Transform>();
        foreach(var elem in spheres)
        {
            Vector3 newPos = elem.position;
            newPos.x += Random.Range(-0.1f, 0.1f);
            newPos.z += Random.Range(-0.1f, 0.1f);
            elem.position = newPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
    }

    private void Update()
    {
        // spheres가 있고 space 눌리면 공을 다시 올리기
        if(spheres != null && Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var elem in spheres)
            {
                Vector3 newPos = elem.position;
                newPos.x += Random.Range(-0.1f, 0.1f);
                newPos.y += Random.Range(11.0f, 14.0f);
                newPos.z += Random.Range(-0.1f, 0.1f);
                elem.position = newPos;
            }
            // Count 초기화
            Count = 0;
            CounterText.text = "Count : " + Count;
        }
    }
}
