using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform Player_position;
    private Vector3 distance;

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        distance = new Vector3(Player_position.position.x, transform.position.y, Player_position.position.z - 5.6f);

        transform.position = Vector3.Lerp(transform.position, distance, GameValues.Instance.Camrera_speed*Time.deltaTime);
    }
}
