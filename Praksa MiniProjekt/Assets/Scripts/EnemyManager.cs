using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> wavesOfEnemys;

    int currentWave = 0;
    bool spawning = false;

    public TextMeshProUGUI dialogText;

    public GameObject winScreen;

    private void Start()
    {

        Time.timeScale = 1;
        
    }

    public void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && !spawning && currentWave < wavesOfEnemys.Count)
        {
            spawning = true;
            StartCoroutine(StartConflict());
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null && !spawning && currentWave == wavesOfEnemys.Count)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    IEnumerator StartConflict()
    {
        if (currentWave < wavesOfEnemys.Count)
        {
            dialogText.text = "GET READY A WAVE OF ENEMIES IS COMMING YOUR WAY!";
            
            yield return new WaitForSeconds(5f);
        }
        else
        {
            dialogText.text = "BOSS IS COMMING AND HE IS BRINGING BACKUP !!!";
            
            yield return new WaitForSeconds(6f);
        }

        dialogText.text = "";


        wavesOfEnemys[currentWave].SetActive(true);
        spawning = false;
        currentWave++;

        //Debug.Log(currentWave);

        yield return new WaitForSeconds(1f);

    }
}
