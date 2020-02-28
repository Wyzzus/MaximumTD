using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public MovableEntity ME;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        //Just For Testing
        MovementParameters mp = new MovementParameters();
        mp.MoveSpeed = 5f;

        Vector3 direction = transform.position + ME.Body.forward * y + ME.Body.right * x;

        ME.MoveTo(direction);
    }
}
