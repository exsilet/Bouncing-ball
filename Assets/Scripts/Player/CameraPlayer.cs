using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _z0ffset = -4;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z + _z0ffset);
    }
}
