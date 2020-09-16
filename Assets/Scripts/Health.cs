using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimations animations;
    public GameObject gameOverPanel;

    [SerializeField]
    private Image healthUI = null;
    public void Awake()
    {
        animations = GetComponent<CharacterAnimations>();
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        healthUI.fillAmount = 1f;
    }
    
    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (healthUI != null)
        {
            healthUI.fillAmount = health / 100f;
        }
        if(health <= 0)
        {
            print("ded");
            animations.Death();
            
            Invoke("EndGame",3f);
            

        }
    }

   

    void EndGame()
    {
        gameOverPanel.SetActive(true);
        
        Time.timeScale = 0f;
        
    }
}
