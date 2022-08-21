using System;
using UnityEngine;
using Weapons;

public class Tree : MonoBehaviour
{
    private bool _isChopped;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _isChopped = false;
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (_isChopped) return;
    //     
    //     if (collision.gameObject.TryGetComponent<IWeapon>(out var _))
    //     {
    //         var weaponRigidbody = collision.gameObject.GetComponent<Rigidbody>();
    //         Break(weaponRigidbody);
    //     }
    // }

    private void Break(Rigidbody weaponRigidbody)
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.drag = 0.25f;
        _rigidbody.angularDrag = 0.5f;
        _rigidbody.velocity = weaponRigidbody.velocity;

        _isChopped = true;
    }
}