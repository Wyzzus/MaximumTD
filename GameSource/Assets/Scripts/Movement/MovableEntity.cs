using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MotorComponent))]
public class MovableEntity : Entity
{
    public MotorComponent Motor;
    public Transform Body;

    void Start()
    {
        if (!Body)
            Body = transform;
        if (!Motor)
            Motor = GetComponentInChildren<MotorComponent>();
    }

    public void Setup(MovementParameters parameters)
    {
        Motor.Setup(parameters); 
    }

    public void MoveTo(Vector3 point)
    {
        Motor.MoveTo(point);
    }
}
