using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth;
    //public Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
