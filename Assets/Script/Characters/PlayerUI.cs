using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Player UI")]
    [SerializeField] private Image HealthBar;
    [SerializeField] private TextMeshProUGUI shotsFired;

    [SerializeField] private float maxHealth;
    private int shotsFiredCounter;
    private float _health;

  /*  private float Health
    {
        get += _health;
    }
*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
