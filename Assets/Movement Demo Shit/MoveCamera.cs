using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform camPos;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        transform.position = camPos.position;
    }
}
