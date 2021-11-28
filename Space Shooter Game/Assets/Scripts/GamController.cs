using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamController : MonoBehaviour
{
    public GameObject hazard;
    private float spawnWait = 0.5f;
    public int SpawnCount;   // 5 yazarsak 5 kere d�nd�recek.

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
            //1.Enumerator d�nd�rmek zorundad�r.
            //2.En az bir adet yield ifadesi bulunmak zorundad�r.
            //3.Coroutineler �a�r�l�rken mutlaka StartCoroutine methoduyla �a�r�lmal�d�r.

            yield return new WaitForSeconds(spawnWait);  // spawnWait de�eri kadar beklesin.
        }
         

    }
}
