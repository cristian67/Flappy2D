using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 5;
    public GameObject columnPrefab;

    //Variables de instancia Start
    private GameObject[] columns; //array de objeto
    private Vector2 objectPoolPosition = new Vector2(-14, 0);

    //Varibles update
    private float timeSinceLastSpawned;
    public float spawnRate;

    // Y maximo/minimo
    public float ColumnMin = -2f;
    public float ColumnMax = 2f;
    private float spawnXPosition = 10f;

    //Saber que columna es elegida
    private int currentColumn = 0;

    void Start(){
        columns = new GameObject[columnPoolSize]; //objecto columns = [5] => [0,1,2,3,4]
        for (int i = 0; i < columnPoolSize; i++)
        {  
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);     
        }
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(ColumnMin, ColumnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize) {
                currentColumn = 0;
            }
        }
    }
}
