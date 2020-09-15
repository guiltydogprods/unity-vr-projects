using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAfterDelay : MonoBehaviour
{
    public float delaySeconds = 5.0f;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;    
    }

    public void Reset()
    {
        StartCoroutine(AfterDelay());
    }

    IEnumerator AfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        transform.position = startPosition;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
