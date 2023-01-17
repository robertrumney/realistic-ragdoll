using UnityEngine;

public class RealisticRagdoll : MonoBehaviour
{
    // Array to hold all of the rigidbodies in the ragdoll
    private Rigidbody[] ragdollRigidbodies;
    
    // Flag to enable/disable the "GutBuster" function
    private bool enableGutBuster = true;
    
    // Time after which the script should be disabled and destroyed
    private float endTime = 5;
    
    // Time when the script starts
    private float startTime;

    private void Awake()
    {
        // Populate the ragdollRigidbodies array with all of the rigidbodies in the ragdoll
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        
        // Save the start time of the script
        startTime = Time.time;
        
        // If the "GutBuster" function is enabled, call it
        if (enableGutBuster)
            GutBuster();
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            // Apply a downward force to each rigidbody in the ragdoll to make it fall realistically
            for (int i = 0; i < ragdollRigidbodies.Length; i++)
            {
                ragdollRigidbodies[i].AddForce(Vector3.down * 9.8f * ragdollRigidbodies[i].mass);
                
                // Check if the current rigidbody has come to a rest
                if (ragdollRigidbodies[i].velocity.magnitude < 1.0f && ragdollRigidbodies[i].angularVelocity.magnitude < 1.0f)
                {
                    // End the script if one of the rigidbodies has come to a rest
                    End();
                }
            }
            //Check if the time passed is more than 5 seconds
            if (Time.time - startTime > endTime)
            {
                // End the script if the time passed is more than 5 seconds
                End();
            }
        }
    }

    // Function to disable and destroy the script
    private void End()
    {
        enabled = false;
        Destroy(this);
    }

    // Function to simulate a punch to the stomach
    public void GutBuster()
    {
        // Variable to hold the force applied to the spine rigidbody
        float force = 500.0f;

        // Find the middle spine rigidbody using the HumanBodyBones enum
        Rigidbody spineRigidbody = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Spine).GetComponent<Rigidbody>();

        // Apply the force to the spine rigidbody to simulate the punch
        spineRigidbody.AddForce(-transform.forward * force, ForceMode.Impulse);
    }
}
