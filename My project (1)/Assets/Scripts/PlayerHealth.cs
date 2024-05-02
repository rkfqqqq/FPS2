using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
  private float health;
  public float maxHealth = 100f;
  public float chipSpeed = 2f;
  private float lerpTimer;
  public Image frontHealthBar;
  public Image backHealthBar;
  void Start()
  {
    health = maxHealth;
  }
  void Update()
  {
    health = Mathf.Clamp(health, 0, maxHealth);
    UpdateHealthUI();
    if(Input.GetKeyDown(KeyCode.A))
    {
        TakeDamage(Random.Range(5, 10));
    }
  }
  public void UpdateHealthUI()
  {
    Debug.Log(health);
    float fillF = frontHealthBar.fillAmount;
    float fillB = backHealthBar.fillAmount;
    float hFraction = health/maxHealth;
    if(fillB > hFraction)
    {
        frontHealthBar.fillAmount = hFraction;
        backHealthBar.color = Color.red;
        lerpTimer += Time.deltaTime;
        float percentComplete = lerpTimer/chipSpeed;
        backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
    }
  }
  public void TakeDamage(float damage)
  {
    health -= damage;
    lerpTimer = 0f;
  }
  }
