using UnityEngine;


public class PlatformQuad : MonoBehaviour
{
    public PlatformType platformID;
    public PlatformQuad[] platformQuads;

    public Vector3 GetMoveDirection()
    {
        // Check For the adjesent platforms,
        // if found some adjesent platforms return the direction
        return Vector3.zero;
    }
}
