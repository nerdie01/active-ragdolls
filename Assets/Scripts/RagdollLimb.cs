using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollLimb : MonoBehaviour
{
    [SerializeField] private Transform target;

    private ConfigurableJoint joint;
    private Quaternion targetRot;

    private ObjectManager objectManager;

    private void Awake()
    {
        objectManager = GameObject.FindGameObjectWithTag("ObjectManager").GetComponent<ObjectManager>();
        joint = GetComponent<ConfigurableJoint>();
    }

    private void Start()
    {
        targetRot = this.target.transform.localRotation;
    }

    private void FixedUpdate()
    {
        joint.targetRotation = Quaternion.Inverse(target.localRotation) * targetRot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (objectManager.Controller.IsJumping)
        {
            objectManager.Controller.IsJumping = false;
        }
    }
}
