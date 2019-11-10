using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoublardRagdoll : MonoBehaviour
{
    public Quaternion angleDirection;
    public Vector3 vecDirection;
    public int controllerNumber;
    public float jumpMultiplicator = 1f, punchMultiplicator = 1f, speedMultiplicator = 1f;
    public float punchForce = 150f, jumpForce = 1500f;

    void ReinitJumpMultiplicator()
    {
        jumpMultiplicator = 1f;
    }
    void ReinitPunchMultiplicator()
    {
        punchMultiplicator = 1f;
    }
    void ReinitSpeedMultiplicator()
    {
        speedMultiplicator = 1f;
    }

    public void ChangeJumpMultiplicator(float newMultiplicator = 1.5f, float time = 15f)
    {
        jumpMultiplicator = newMultiplicator;
        CancelInvoke("ReinitJumpMultiplicator");
        Invoke("ReinitJumpMultiplicator", time);
    }
    public void ChangePunchMultiplicator(float newMultiplicator = 3f, float time = 15f)
    {
        punchMultiplicator = newMultiplicator;
        CancelInvoke("ReinitPunchMultiplicator");
        Invoke("ReinitPunchMultiplicator", time);
    }
    public void ChangeSpeedMultiplicator(float newMultiplicator = 2f, float time = 15f)
    {
        jumpMultiplicator = newMultiplicator;
        CancelInvoke("ReinitSpeedMultiplicator");
        Invoke("ReinitSpeedMultiplicator", time);
    }
}
