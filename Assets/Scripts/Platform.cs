using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float platformSpeed = 1f;
    [SerializeField] Transform nextPositionPoint;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - platformSpeed * Time.deltaTime, transform.position.y, 0f);
    }

    private void OnBecameInvisible()
    {
        transform.position = nextPositionPoint.position;
    }
}
