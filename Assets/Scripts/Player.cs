using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float gravity = 1;
    [SerializeField] private float jumpHeight = 15;
    [SerializeField] private int coins = 0;
    private int lives=3;
    

    private bool canDoubleJump = false;
    
    private float yVelocity;
    
    private CharacterController _characterController;
    private UIManager _uıManager;
    
    void Start()
    {
        _characterController = FindObjectOfType<CharacterController>();
        _uıManager = FindObjectOfType<UIManager>();
        
        _uıManager.UpdateLivesDisplay(lives);

    }

    // Update is called once per frame
    void Update()
    {
        
        float horizantalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizantalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (_characterController.isGrounded==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
                canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canDoubleJump==true)
                {
                    yVelocity += jumpHeight;
                    canDoubleJump = false;
                }
            }
            yVelocity -= gravity;
        }

        velocity.y = yVelocity;
        _characterController.Move(velocity*Time.deltaTime);
       
        
    }

    public void AddCoins()
    {
        coins++;
        _uıManager.UpdateCoinDisplay(coins);
    }

    public void Damage()
    {
        lives--;
        _uıManager.UpdateLivesDisplay(lives);
        if (lives <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
    
    
    
}
