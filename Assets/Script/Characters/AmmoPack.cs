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
            if (playerScript.shotsFiredCounter > 5)
            {
                return;
            }

            Debug.Log("AmmoPack Hit!");
            playerScript.shotsFiredCounter = playerScript.shotsFiredCounter + 5;
            Destroy(gameObject);
        }
    }
}
