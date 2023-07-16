using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSpawn : MonoBehaviour
{
    [SerializeField] public float xLimit;
    [SerializeField] public float[] xPosition;
    [SerializeField] public GameObject objPrefab;
    [SerializeField] public Wave[] wave;

    float currentTime;
    List<float> remainingPositions = new List<float>();
    private int waveIndex;
    float xPos = 0;
    int rand;
    [SerializeField] float gravity = 0.5f;

    void Start() {
        currentTime = 0;
        remainingPositions.AddRange(xPosition);
        
    }
    void Update() {

        if(PlayerMoviment.instance != null && PlayerMoviment.instance.StartMoving == true) {
            currentTime -= Time.deltaTime;
            if(currentTime<=0)
            {
                SelectWave();
            }
        }
        
    }
    void SpawnEnemy (float xPos) {
        GameObject prefabObj = Instantiate(objPrefab, new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        Rigidbody2D rigidbody = prefabObj.GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gravity; 
    }

    void SelectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPosition);

        waveIndex = Random.Range(0, wave.Length);
        currentTime = wave[waveIndex].delayTime;

        if (wave[waveIndex].spawnAmount == 1)
            xPos = Random.Range(-xLimit, xLimit);
        else if (wave[waveIndex].spawnAmount > 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        } 
        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            SpawnEnemy(xPos);
            rand =  Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
    }
}

[System.Serializable]
public class Wave 
{
    public float delayTime; 
    public int spawnAmount;
}