using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    private float spawnWait = 0.5f;
    public int SpawnCount;   // 5 yazarsak 5 kere d�nd�recek.
    public float StartSpawn;
    public float waveWait;
    public Mover speedUp;
    public Text scoreText;
    private int score;
    public Text GameOverText;
    public Text restartText;
    public Text QuitText;
    bool gameOver;
    bool restart;


    private void Update()
    {
        if(restart == true)
        {
            speedUp.speed = -3;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
                Debug.Log("Oyun Kapand�");
            } 
        }
    }
    void Start()
    {
        StartCoroutine(SpawnValues());
        GameOverText.text = "";
        restartText.text = "";
        QuitText.text = "";
        gameOver = false;
        restart = false;

    }
    
    public void IncreaseScore()
    {
        score += 10;
        scoreText.text = "Score : " + score;
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(StartSpawn); // Oyun 1 saniye sonra ba�las�n (1 girilecek)
        while (true) // Devaml� kodun �al��mas�n� sa�lar.
        {
            for (int i = 0; i < SpawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 1, 2.71f);  //yumurtlama pozisyonu
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                //Coroutine
                //1.Enumerator d�nd�rmek zorundad�r.
                //2.En az bir adet yield ifadesi bulunmak zorundad�r.
                //3.Coroutineler �a�r�l�rken mutlaka StartCoroutine methoduyla �a�r�lmal�d�r.

                yield return new WaitForSeconds(spawnWait);  // spawnWait de�eri kadar beklesin ve obje tekrar olu�sun.
                
            }
            speedUp.speed -= 1;
            yield return new WaitForSeconds(waveWait); // D�ng� bittikten sonra 4 saniye beklesin.
            if(gameOver == true)
            {
                restartText.text = "Press 'R' for restart ";
                QuitText.text = "Press 'Q' for Quit";
                restart = true;
                break;   // Objelerin d��mesini durdurmak i�in 
            }
        }
       
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        gameOver = true;
        
    }
 


}
