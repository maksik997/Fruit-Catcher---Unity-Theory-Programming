using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText, TimeText;
    [SerializeField]
    private GameObject GameoverPanel;

    [SerializeField]
    private List<GameObject> spawnableObjects;
    [SerializeField]
    private int amoutToPool;
    private List<GameObject> pooledObjects;
    
    private float YSpawnPos = 9, XSpawnBound = 8;
    private const float SpawnDelay = 2f;
    
    // ENCAPSULATION
    public float SpawnInterval { get; private set; }
    public int Score { get; private set; }
    public int TimeLeft { get; private set; }

    private void Start()
    {
        Score = 0;
        AddScore(0);
        TimeLeft = 60; // DEPENDS ON DIFFICULTY
        SpawnInterval = 3f; // DEPENDS ON DIFFICULTY

        InitObjectPool();

        StartCoroutine(TimerRoutine());

        InvokeRepeating("SpawnNewObject", SpawnDelay, SpawnInterval);
    }

    private void InitObjectPool()
    {
        pooledObjects = new();
        GameObject tmp;
        foreach (GameObject type in spawnableObjects)
        {
            for (int i = 0; i < amoutToPool; i++)
            {
                tmp = Instantiate(type);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

    }

    public GameObject GetPooledObject()
    {
        if(pooledObjects.Exists(obj => !obj.activeInHierarchy))
        {
            var tmp = pooledObjects.FindAll(obj => !obj.activeInHierarchy);

            return tmp[Random.Range(0, tmp.Count)];
        }

        return null;
    }

    public void AddScore(int value)
    {
        Score += value;
        ScoreText.text = $"Score: {Score}";
    }

    public void AddTime(int value)
    {
        TimeLeft += value;
        TimeText.text = $"Time: {TimeLeft}";
    }

    public void Gameover()
    {
        CancelInvoke("SpawnNewObject");
        StopCoroutine(TimerRoutine());

        GameoverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator TimerRoutine()
    {
        while(TimeLeft >= 0)
        {
            TimeText.text = $"Time: {TimeLeft}";
            yield return new WaitForSeconds(1);
            TimeLeft--;
        }
        Gameover();
    }

    private void SpawnNewObject()
    {
        GameObject obj = GetPooledObject();
        if(obj != null)
        {
            obj.transform.position = new(Random.Range(-XSpawnBound, XSpawnBound), YSpawnPos, 0);
            obj.SetActive(true);
        }
    }
}
