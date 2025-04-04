using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoRipe : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        // Quand le joueur touche le cube, ajouter un point au GameManager et détruire le cube
        if (other.gameObject.tag == "Player")
        {
            GameManager.AddScore(true); // Signaler au GameManager qu'une pièce a été récoltée
            Destroy(gameObject);
        }
    }

    // Assets/Scripts/Coin.cs

    void Update()
    {
        // Faire tourner le cube sur lui-même
        transform.Rotate(
            0,
            180f * Time.deltaTime,
            0
        );
    }
}
