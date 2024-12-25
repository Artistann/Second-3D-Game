using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> carPrefabs;
    public int poolSize = 15;
    private List<GameObject> carPool;

    
    // Start is called before the first frame update
    void Awake()
    {
        InitializePool();
        StartCoroutine(SpawnCar());              
    }  
        void InitializePool()
        {
            carPool = new List<GameObject>(); for (int i = 0; i < carPrefabs.Count; i++)
            {
                GameObject obj = Instantiate(carPrefabs[i]);
                obj.SetActive(false);
                carPool.Add(obj);
            }
        }
    GameObject GetPooledCar()
    {
        for (int i = 0; i < carPool.Count; i++)
        {
            if (!carPool[i].activeInHierarchy)
            {
                return carPool[i];
            }
        }

        int index = Random.Range(0, carPrefabs.Count);
        GameObject newObj = Instantiate(carPrefabs[index]);
        carPool.Add(newObj);
        return newObj;
    }
        
            IEnumerator SpawnCar()
            {
                while (true)
                {
                    yield return new WaitForSeconds(1);
                    Vector3 spawnPos = new Vector3(Random.Range(-5, 5), 0, Random.Range(40, 50));
                    GameObject car = GetPooledCar(); 
                    if (car != null)
                    {
                        car.transform.position = spawnPos; car.transform.rotation = Quaternion.identity;
                        car.SetActive(true);
                    }
                }
            }
    

     
    
}
