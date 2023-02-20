using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Character
{
    public Movement playerMovement;
    public TMP_Text hp;
    public TMP_Text coins;
    public int playerwallet;
    private void Start()
    {
        playerMovement = this.gameObject.GetComponent<Movement>();
    }
    private void Update()
    {
        CheckDist();
        TextStates();
        if(playerMovement!=null)
        {
            attack = playerMovement.attack;
        }
        if(attack && copydelay<=0)
        {
            copydelay = 0;
            CoolDown();
        }
        else if(copydelay>0)
        {
            copydelay -= Time.deltaTime;
        }

    }

    public void TextStates()
    {
        hp.text = "HP: " + HP;
        coins.text = "Coins: " + playerwallet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Coin")
        {
            other.gameObject.SetActive(false);
            var wallet = other.transform.GetComponent<Coin>();
            playerwallet += wallet.value;
        }
    }

}
