using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private bool _isChopped;
    private Rigidbody _rigidbody;

    [SerializeField] private String _axeTag;

    private void Awake()
    {
        _isChopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AddComponent<Rigidbody>();
        _isChopped = true;
    }
}
