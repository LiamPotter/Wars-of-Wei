using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBase_Movement
{
    
    float Speed { get; set; }
    int RotationSpeed { get; set; }
    
    float MovementCap { get; set; }

    Vector3 MovementVector { get; set; }

    Transform Model { get; set; }

    CharacterController CharacterController{ get; set; }

    void Movement();
    void Rotation();
}
