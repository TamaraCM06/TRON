using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MotoScript : MonoBehaviour

{
    public float speed = 1;
    public Image fuelBar;
    public float fuel, maxfuel;
    public float movingCost;


    Vector2 direction = Vector2.right;


    public void Start()
    {
        speed = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        fuel -= movingCost * Time.deltaTime;
        if (fuel < 0) fuel = 0;
        fuelBar.fillAmount = fuel / maxfuel;
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(
            this.transform.position.x + (direction.x / 2) * (speed / 2),
            this.transform.position.y + (direction.y / 2) * (speed / 2),
            0);
    }






}