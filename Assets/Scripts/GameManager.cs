using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject preFabPlayer;
    public GameObject preFabEnemy;
    public GameObject endCanvas;

    private int playerAmount;
    private int progress;
    [SerializeField] int deaths;
    [SerializeField] GameObject[] enemies;


    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance==null)
            {
                Debug.LogError(message: "GameManager is null");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        var coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach(var coin in coins)
        {
            coin.gameObject.SetActive(true);
        }
        endCanvas.SetActive(false);
        _instance = this;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void Update()
    {
        var player = preFabPlayer.GetComponent<Player>();
        if(player!=null)
        {
            if(player.HP<=0)
            {
                playerAmount = player.playerwallet;
                ShowEnd();
                if (progress == 1)
                {
                    Application.LoadLevel(0);
                }
                else if (progress == 2)
                {
                    Application.Quit();
                }
            }
        }
        if(deaths==enemies.Length)
        {
            ShowEnd();
            if (progress == 1)
            {
                Application.LoadLevel(0);
            }
            else if(progress==2)
            {
                Application.Quit();
            }
        }

        for(int i=deaths; i<enemies.Length; i++)
        {
            var enemy = enemies[deaths].GetComponent<Enemy>();
            if (enemy != null)
            {
                if (enemy.Dead == true)
                {
                    deaths++;
                }

            }
        }
    }

    public void ShowEnd()
    {
        endCanvas.SetActive(true);
    }

    public void Choice(int choice)
    {
        progress = choice;
    }
}
