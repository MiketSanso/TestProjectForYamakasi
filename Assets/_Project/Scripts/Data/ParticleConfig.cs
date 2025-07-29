using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(fileName = "ParticleConfig", menuName = "ParticleConfig", order = 0)]
    public class ParticleConfig : ScriptableObject
    {
        [field: SerializeField] public int ParticleCount { get; private set; }   
        [field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
    }
}