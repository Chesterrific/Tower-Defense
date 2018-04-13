using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;

    private float countdown = 2f; //time to spawn first wave
    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime; //countdown goes down by one each frame

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    /* https://www.youtube.com/watch?v=Vrld13ypX_I
     * advanced wave spawner
     */
    IEnumerator SpawnWave()  
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        } 
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); //creates gameobject on given position and rotation
    }
}
