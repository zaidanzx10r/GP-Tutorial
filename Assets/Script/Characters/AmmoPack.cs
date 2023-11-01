using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    Player playerScript;
    [SerializeField] GameObject player;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("AmmoPack Hit!");
            playerScript.shotsFiredCounter = playerScript.shotsFiredCounter + 5;
            Destroy(gameObject);

            if (playerScript.shotsFiredCounter > 10)
            {
                playerScript.shotsFiredCounter = 10;
            }
        }
    }
}
