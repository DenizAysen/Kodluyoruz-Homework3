using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AnimationController animatonController;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    Rigidbody rg;
    GameValues gameValues;
    bool left;
    bool right;
    bool isJumped=false;
    bool stopped = false;
    int score;
    void Start()
    {
        score = 0;
        gameValues = GameValues.Instance;
        rg = GetComponent<Rigidbody>();
        _scoreText.text = "Current score : " + score;
        _maxScoreText.text = "Max score : " + SaveManager.Instance().GetMaxScore();
    }

    private void OnCollisionStay(Collision collision)
    {
        isJumped = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isJumped = true;
    }

    void Update()
    {      
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.deltaPosition.x > 100f)
            {
                right = true;
                left = false;
            }
            if (touch.deltaPosition.x < -100f)
            {
                right = false;
                left = true;
            }         
        }
        if (right == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(gameValues.Right_X_Boundary, transform.position.y, transform.position.z),
                gameValues.Run_Speed * Time.deltaTime);
        }
        if (left == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(gameValues.Left_X_Boundary, transform.position.y, transform.position.z),
                gameValues.Run_Speed * Time.deltaTime);
        }
        transform.Translate(0, 0, gameValues.Run_Speed * Time.deltaTime);
    }

    public void Jump()
    {
        if(isJumped == false)
        {
            animatonController.JumpAnimation();
            rg.velocity = Vector3.zero;
            rg.velocity = Vector3.up * gameValues.Jump_Force;
        }     
    }

    private void ChangeScore()
    {
        score += gameValues.Point_Value;
        SaveManager.Instance().SetMaxScore(score);
        _scoreText.text = "Current score : " + score;                 
        _maxScoreText.text = "Max score : " + SaveManager.Instance().GetMaxScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            ChangeScore();
            other.gameObject.SetActive(false);
        }
    }
}
