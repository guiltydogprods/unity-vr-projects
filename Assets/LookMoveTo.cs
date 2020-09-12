using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    private Transform camera;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        layerMask = 1 << 8;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
//        RaycastHit hit;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        //        Physics.Raycast(ray, out hit, 20.0f, layerMask);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                Debug.Log("Hit (x, y, z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }
        }
    }
}
