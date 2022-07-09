using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //inspector values
    [SerializeField] private float rotSpeedMultiplier = 20F;
    [SerializeField] private float jumpForce = 1000F;
    [SerializeField] private float jumpStiffness = 2F;
    [SerializeField] private Vector3 ragdollStabilizationForce = new Vector3(0F, 150F, 0F);

    private bool isJumping = false;

    private ObjectManager objectManager;
    
    private void Awake()
    {
        objectManager = GameObject.FindGameObjectWithTag("ObjectManager").GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        objectManager.ControllerAnimator.SetFloat("input", Input.GetAxis("Vertical"));

        objectManager.RagdollHips.AddTorque(0, Input.GetAxis("Horizontal") * rotSpeedMultiplier, 0);
        objectManager.RagdollHead.AddForce(ragdollStabilizationForce);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;

            ragdollStabilizationForce = Vector3.zero;
            objectManager.RagdollHips.AddForce(Vector3.up * jumpForce);

            for (int i = 0; i < objectManager.Joints.Length; i++)
            {
                JointDrive j = objectManager.Joints[i].angularXDrive;
                j.positionSpring /= jumpStiffness;
                objectManager.Joints[i].angularXDrive = j;
                objectManager.Joints[i].angularYZDrive = j;
            }
        }

        Debug.Log(isJumping);
    }

    public bool IsJumping { get { return isJumping; } set { isJumping = value; } }
}
