using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Stats playerStats = new Stats();

    public int curHealth;
    public int numOfHearts = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            DamagePlayer(1);
            Destroy(other.gameObject);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStats.SetHealth();
        curHealth = numOfHearts;
    }

    // Update is called once per frame
    void Update()
    {

        curHealth = playerStats.Health;
        numOfHearts = playerStats.maxHP;

        if (curHealth>numOfHearts){
            curHealth = numOfHearts;
        }
        if(curHealth <= 0){

            Die();

        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < curHealth){
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
            
        }
    }

    



    void Die(){
        //Restart
        Application.LoadLevel(Application.loadedLevel);
    }


}
