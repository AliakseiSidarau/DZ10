using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;
    public string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    private int _lastDirection;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        float result1 = Vector2.SignedAngle(Vector2.up, Vector2.right);
        float result2 = Vector2.SignedAngle(Vector2.up, Vector2.left);
        float result3 = Vector2.SignedAngle(Vector2.up, Vector2.down);
    }

    public void SetDirection(Vector2 _direction)
    {
        string[] directionArray = null;

        if(_direction.magnitude < 0.01)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;
            _lastDirection = DirectionToIdex(_direction);
        }

        _anim.Play(directionArray[_lastDirection]);
    }

    private int DirectionToIdex(Vector2 _direction)
    {
        Vector2 norDir = _direction.normalized;

        float step = 360 / 8;
        float offset = step / 2;

        float angle = Vector2.SignedAngle(Vector2.up, norDir);
        angle += offset;

        if(angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
