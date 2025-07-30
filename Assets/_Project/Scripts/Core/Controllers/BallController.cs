using UnityEngine;

public class BallController : MonoBehaviour
{
    private PendulumController _pendulum;

    public void Initialize(PendulumController pendulum)
    {
        _pendulum = pendulum;
    }

    private void OnMouseDown()
    {
        if (_pendulum != null)
        {
            _pendulum.ReleaseBall();
        }
    }
}