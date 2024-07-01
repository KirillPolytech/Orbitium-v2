using UnityEngine;

public interface ITrajectoryChanger
{
    public void AddTrajectory(Vector3 gravityDirection, Rigidbody otherRb, float gravityConst);
    public void AddTrajectory(Vector3 direction);
}
