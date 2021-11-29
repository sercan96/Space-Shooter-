using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
                Debug.Log("Oyun Kapandý");
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
            if(gameOver == true)
            {
                restartText.text = "Press 'R' for restart ";
                QuitText.text = "Press 'Q' for Quit";
                restart = true;
                break;   // Objelerin düþmesini durdurmak için 
            }
        }
       
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        gameOver = true;
        
    }
 


}
