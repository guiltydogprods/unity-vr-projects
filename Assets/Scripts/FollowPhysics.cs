using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysics : MonoBehaviour
{
    public GameObject target;
    private Rigidbody rb;
    private HandleScript handleScript;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        handleScript = target.GetComponent<HandleScript>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
//        if (handleScript.IsGrabbed == true)
//        {
            rb.MovePosition(target.transform.position);
//        }
    }
}
