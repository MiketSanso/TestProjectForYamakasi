using _Project.Scripts.Core.Controllers;
using _Project.Scripts.Core.Models;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class GameCircle : MonoBehaviour
    {
        private CirclesModel _circlesModel;
        private ParticleController _particleController;
        
        [field: SerializeField] public int ID { get; private set; }
        
        [Inject]
        public void Initialize(ParticleController particleController,
            CirclesModel circlesModel)
        {
            _particleController = particleController;
            _circlesModel = circlesModel;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out GameCircle circle))
            {
                _circlesModel.AddCircle(circle, this);
            }
            else if (collision.gameObject.TryGetComponent(out FloorObject floor))
            {
                _circlesModel.AddCircle(floor.IndexX, this);
            }
        }

        public void DestroyIt()
        {
            _particleController.PlayParticle(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}