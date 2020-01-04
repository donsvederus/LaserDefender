using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /// setup  ///

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float edgePadding = 1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    /// Start is called before the first frame update  ///

    void Start()
    {
        SetupMoveBoundaries();
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + edgePadding;  // Min x an y move to the left & right side, note we used vector3 on camera
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - edgePadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + edgePadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - edgePadding;  
    }

    /// Update is called once per frame ///

    // Movement functions
    void Update()
    {
        Move();
    }

    private void Move()
        {
            var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; // horizontal & vertical movement, time.deltaTime makes the speed same on all computers
            var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

            var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);  // limits the move with Mathf.clamp and xmin and xmax
            var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);  
  
            transform.position = new Vector2(newXPos, newYPos);     //updated the movement
        }

}
