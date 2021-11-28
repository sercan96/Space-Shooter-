using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamController : MonoBehaviour
{
    public GameObject hazard;
    private float spawnWait = 0.5f;
    public int SpawnCount;   // 5 yazarsak 5 kere döndürecek.

    void Start()
    {
        StartCoroutine(SpawnValues());
    }
    private void Update()
    {
        
    }

    IEnumerator SpawnValues()
    {
        for(int i = 0; i < SpawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 1, 2.71f);  //yumurtlama pozisyonu
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);

            //Coroutine
            //1.Enumerator döndürmek zorundadır.
            //2.En az bir adet yield ifadesi bulunmak zorundadır.
            //3.Coroutineler çağrılırken mutlaka StartCoroutine methoduyla çağrılmalıdır.

            yield return new WaitForSeconds(spawnWait);  // spawnWait değeri kadar beklesin.
        }
         

    }
}
