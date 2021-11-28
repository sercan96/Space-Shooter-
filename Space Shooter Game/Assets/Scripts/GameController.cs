using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    private float spawnWait = 0.5f;
    public int SpawnCount;   // 5 yazarsak 5 kere döndürecek.
    public float StartSpawn;
    public float waveWait;
    public Mover speedUp;
    public Text scoreText;
    private int score;
    void Start()
    {
        StartCoroutine(SpawnValues());
    }
    
    public void IncreaseScore()
    {
        score += 10;
        scoreText.text = "Score : " + score;
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(StartSpawn); // Oyun 1 saniye sonra baþlasýn (1 girilecek)
        while (true) // Devamlý kodun çalýþmasýný saðlar.
        {
            for (int i = 0; i < SpawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 1, 2.71f);  //yumurtlama pozisyonu
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                //Coroutine
                //1.Enumerator döndürmek zorundadýr.
                //2.En az bir adet yield ifadesi bulunmak zorundadýr.
                //3.Coroutineler çaðrýlýrken mutlaka StartCoroutine methoduyla çaðrýlmalýdýr.

                yield return new WaitForSeconds(spawnWait);  // spawnWait deðeri kadar beklesin ve obje tekrar oluþsun.
                
            }
            speedUp.speed -= 1;
            yield return new WaitForSeconds(waveWait); // Döngü bittikten sonra 4 saniye beklesin.
        }
       
    }
}
