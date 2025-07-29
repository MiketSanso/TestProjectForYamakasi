using _Project.Scripts.Data;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Controllers
{
    public class ParticleController : IInitializable
    {
        private ParticleSystem[] _particleSystems;
        
        private readonly ParticleConfig _particleConfig;

        public ParticleController(ParticleConfig particleConfig)
        {
            _particleConfig = particleConfig;
        }
        
        public void Initialize()
        {
            CreateMassiveParticles();
        }

        private void CreateMassiveParticles()
        {
            _particleSystems = new ParticleSystem[_particleConfig.ParticleCount];

            for (int i = 0; i < _particleConfig.ParticleCount; i++)
            {
                _particleSystems[i] = Object.Instantiate(_particleConfig.ParticleSystem);
                _particleSystems[i].gameObject.SetActive(false);
            }
        }

        public void PlayParticle(Vector3 position)
        {
            for (int i = 0; i < _particleConfig.ParticleCount; i++)
            {
                if (_particleSystems[i].gameObject.activeSelf == false)
                {
                    _particleSystems[i].gameObject.transform.position = position;
                    _particleSystems[i].gameObject.SetActive(true);
                    _particleSystems[i].Play();
                }
            }
        }
    }
}