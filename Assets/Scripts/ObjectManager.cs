using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody ragdollHips;
    private Rigidbody ragdollHead;
    private ConfigurableJoint[] joints;

    private MovementScript movementScript;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("GameControllerAnimator").GetComponent<Animator>();
        ragdollHips = GameObject.FindGameObjectWithTag("ControllerHips").GetComponent<Rigidbody>();
        ragdollHead = GameObject.FindGameObjectWithTag("ControllerHead").GetComponent<Rigidbody>();
        joints = ragdollHips.GetComponentsInChildren<ConfigurableJoint>();

        movementScript = animator.gameObject.GetComponent<MovementScript>();
    }

    public Animator ControllerAnimator { get { return animator; } set { animator = value; } }
    public Rigidbody RagdollHips { get { return ragdollHips; } set { ragdollHips = value;} }
    public Rigidbody RagdollHead { get { return ragdollHead; } set { ragdollHead = value;} }
    public ConfigurableJoint[] Joints { get { return joints; } set { joints = value; } }

    public MovementScript Controller { get { return movementScript; } set { movementScript = value; } }
}
