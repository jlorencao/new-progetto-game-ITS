using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    int lifes = 3;
    [SerializeField] Text lifesText;
    string EnemyTag = "Enemy";
    Rigidbody2D myrigidbody;
    Animator animator;
    

    private void Start() {
        myrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (lifes > 0 && collision.gameObject.CompareTag(EnemyTag))
        {
            Destroy(collision.gameObject);
            lifes--;
            lifesText.text = "Lifes: " + lifes;
        }   
        if (lifes == 0) {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);     
    }

}
