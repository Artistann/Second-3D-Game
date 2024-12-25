using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPrefabMoveBack : MonoBehaviour
{
    public PlayerController controller;
    public float speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGameOver==false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }        
    }
}
