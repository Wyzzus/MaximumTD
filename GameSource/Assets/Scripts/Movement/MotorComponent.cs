using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct MovementParameters
{
    public float MoveSpeed;

    public MovementParameters(MovementParameters parameters)
    {
        this.MoveSpeed = parameters.MoveSpeed;
    }
}

public class MotorComponent : EntityComponent
{
    [Header ("Navigation")]
    NavMeshPath Path;
    public LayerMask PathMask = -1;
    [Header("Movement Chars")]
    public MovementParameters CurrentParameters;

    //Current variables
    public float CurrentMoveSpeed = 0;
    public float CurrentTurnSpeed = 0;

    public override void Start()
    {
        base.Start();
        Path = new NavMeshPath();
    }

    public void Setup(MovementParameters parameters)
    {
        this.CurrentParameters = new MovementParameters(parameters);
    }

    public void MoveTo(Vector3 point)
    {
        Vector3 direction = (GetPointOfPath(point) - transform.position).normalized;
        direction = new Vector3(direction.x, 0, direction.z);
        transform.position += direction * CurrentParameters.MoveSpeed / 100f;
    }
    public Vector3 GetPointOfPath(Vector3 point)
    {
        NavMesh.CalculatePath(transform.position, point, PathMask, Path);
        if ((Path != null && Path.corners.Length > 1) && Vector3.Distance(point, transform.position) > 2)
        {
            return Path.corners[1];
        }
        else
        {
            return point;
        }
    }

    public float Distance2D(Vector3 point)
    {
        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
        return Vector3.Distance(pos, new Vector3(point.x, 0, point.z));
    }
}
