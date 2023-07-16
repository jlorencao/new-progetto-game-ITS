using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int points = 0;
    [SerializeField] Text pointsText;
    string rewardTag = "Reward";

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag(rewardTag))
        {
            Destroy(collision.gameObject);
            points = points + 10;
            pointsText.text = "Points: " + points;
        }
    }
}

