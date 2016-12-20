using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Camera_Base {

	int FollowSpeed { get; set; }
    float RotationSpeed { get; set; }
    Transform Target { get; set; }

}
