using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Базовый класс сущности
public class Entity : MonoBehaviour
{
    [Header("ECS")]
    public List<EntityComponent> Components;
    
    void Start()
    {
        Components = new List<EntityComponent>(GetComponentsInChildren<EntityComponent>());
    }
}
