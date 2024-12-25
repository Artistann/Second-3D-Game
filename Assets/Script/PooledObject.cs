using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PooledObject : MonoBehaviour
{
    public float lifeTime = 5f; 

    void OnEnable()
    {
        
        Invoke("Deactivate", lifeTime);
    }

    void Deactivate()
    {
        
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        
        CancelInvoke();
    }
}
