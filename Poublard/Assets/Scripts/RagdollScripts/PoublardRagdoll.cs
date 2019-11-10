using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoublardRagdoll : MonoBehaviour
{
    public Quaternion angleDirection;
    public Vector3 vecDirection;
    public int controllerNumber;
    public float jumpModificator = 1f, punchMultiplicator = 1f, speedMultiplicator = 1f;

    void ReinitJumpModificator()
    {
        jumpModificator = 1f;
    }
    void ReinitPunchModificator()
    {
        punchMultiplicator = 1f;
    }
    void ReinitSpeedModificator()
    {
        speedMultiplicator = 1f;
    }
}
