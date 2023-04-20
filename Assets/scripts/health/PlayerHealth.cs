using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthbar;
    public ui_change u;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth= health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        u.change();
    }
}
