using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class ObjectGrabber : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    private GameObject grabbedObject;
    private int layerIndex;
    private Vector2 direction = Vector2.right;
    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Interactive");
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.localScale.x == 1 ? Vector2.right : Vector2.left;

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, direction, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex) 
        { 
            if (Keyboard.current.fKey.wasPressedThisFrame && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
        Debug.DrawRay(rayPoint.position, direction * rayDistance);
    }
}
