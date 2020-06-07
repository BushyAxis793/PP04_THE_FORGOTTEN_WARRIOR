using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    [SerializeField] float scrollSpeed = .2f;

    private void Update()
    {
        transform.Translate(new Vector2(0f, scrollSpeed * Time.deltaTime));
    }
}
