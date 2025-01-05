using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class MovementScript : MonoBehaviour
{
    public float speed = 1;
    public float additionalHeight = 0.2f;

    private XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController character;
    
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        inputAxis = new Vector2(Mathf.Abs(inputAxis.x)<0.5?0:inputAxis.x, Mathf.Abs(inputAxis.y)<0.5?0:inputAxis.y);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);
    }

    void CapsuleFollowHeadset(){
        character.height = rig.CameraInOriginSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2, capsuleCenter.z);
    }
}
