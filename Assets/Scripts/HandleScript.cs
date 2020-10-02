using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class HandleScript : MonoBehaviour
{
    public Transform handle;

    [SerializeField] private Text text = default;
    private XRSimpleInteractable interactable;
    private Rigidbody rigidbody;
    private bool isGrabbing;
    private bool applyFix;
    private Vector3 handPosition;

    // Start is called before the first frame update
    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        isGrabbing = false;
        applyFix = false;
        text.text = "Fix not applied";
    }

    public void Grab()
    {
        isGrabbing = true;
        rigidbody.isKinematic = true;
        handPosition = InteractorPosition();
    }

    public bool IsGrabbed
    {
        get { return isGrabbing; }
    }

    private Vector3 InteractorPosition()
    {
        List<XRBaseInteractor> interactors = interactable.hoveringInteractors;
        if (interactors.Count > 0)
        {
            return interactors[0].transform.position;
        }
        else
        {
            return handPosition;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGrabbing)
        {
            handPosition = InteractorPosition();
            transform.position = handPosition;
            //            Debug.DrawLine(transform.position, CurrentInteractor.transform.position, Color.white);
//            Debug.DrawLine(transform.position, transform.position + transform.forward * 0.05f, Color.red);
//            Debug.DrawLine(transform.position, transform.position + transform.up * 0.05f, Color.green);
//            Debug.DrawLine(transform.position, transform.position + transform.right * 0.05f, Color.blue);

        }
        if (Input.GetButtonDown("XRI_Left_PrimaryButton"))
        {
            applyFix ^= true;
            if (applyFix == true)
            {
                text.text = "Fix applied";
            }
            else
            {
                text.text = "Fix not applied";
            }
        }
        else if (Input.GetButtonUp("XRI_Left_PrimaryButton"))
        {
        }
    }

    public void Release()
    {
        isGrabbing = false;
// CLR - Comment out these two lines to remove the Grabbable Handle position reset on release.  It feels nicer when letting go of the handle but doesn't reset the 
//       grabbable handle position.  With these two lines in, the position is reset, but letting go of the door handle causes the door to move in a bad way. I'm sure
//       it's fixable but requires a bit more work to figure out what is going on.
        if (applyFix)
        {
            transform.position = handle.transform.position;
            transform.rotation = handle.transform.rotation;
        }
        //        rigidbody.velocity = Vector3.zero;
        //        rigidbody.angularVelocity = Vector3.zero;
        //        rigidbody.isKinematic = false;
    }
}
