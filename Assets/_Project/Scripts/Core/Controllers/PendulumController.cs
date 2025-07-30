using _Project.Scripts;
using _Project.Scripts.Data;
using UnityEngine;
using Zenject;

public class PendulumController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _arm;
    [SerializeField] private LineRenderer _ropeVisual;
    
    [Inject] private CirclesConfig _circlesConfig;
    [Inject] private PendulumConfig _pendulumConfig;
    [Inject] private DiContainer _container;

    private float _swingTime;
    private GameObject _currentBall;
    private bool _isActive = true;

    private void Start()
    {
        _ropeVisual.positionCount = 2;
        _ropeVisual.useWorldSpace = true;
        
        SpawnNewBall();
    }

    private void Update()
    {
        if (!_isActive) return;
        
        _swingTime += Time.deltaTime;
        float angle = _pendulumConfig.SwingAngle * Mathf.Sin(_swingTime * _pendulumConfig.SwingSpeed);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        UpdateRopeVisual();
    }

    private void UpdateRopeVisual()
    {
        _ropeVisual.SetPosition(0, transform.position);
        _ropeVisual.SetPosition(1, _arm.position);
    }

    private void SpawnNewBall()
    {
        int randomIndex = Random.Range(0, _circlesConfig.Circles.Length);
        GameCircle circlePrefab = _circlesConfig.Circles[randomIndex];
        
        _currentBall = _container.InstantiatePrefab(
            circlePrefab.gameObject,
            _arm.position,
            Quaternion.identity,
            _arm
        );

        Rigidbody2D rb = _currentBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.gravityScale = 0;
        }
        
        var ballController = _currentBall.AddComponent<BallController>();
        ballController.Initialize(this);

        _isActive = true;
        _ropeVisual.enabled = true;
    }

    public void ReleaseBall()
    {
        if (!_isActive || _currentBall == null) return;
        
        _currentBall.transform.SetParent(null);
        
        Rigidbody2D rb = _currentBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.gravityScale = 1;
        }
        
        _isActive = false;
        _ropeVisual.enabled = false;
        
        _currentBall = null;
        
        Invoke(nameof(SpawnNewBall), 2f);
    }
}