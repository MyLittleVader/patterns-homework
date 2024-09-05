using UnityEngine;

namespace SecondTask
{
    public enum FireMode
    {
        single,
        infinite,
        multishot
    }
    
    [RequireComponent(typeof(Gun))]
    public class GunConfig : MonoBehaviour
    {
        [SerializeField] private FireMode _fireMode;
        [SerializeField, Range(0f, 1f)] private float _strayFactor = 0f;
        [SerializeField, Range(1f, 255f)] private float _range = 10f;
        
        [Header("For fire strategies with ammo supply")]
        [SerializeField, Range(0, 255)] private int _ammo = 255;
        
        [Header("Multishot fire strategy")]
        [SerializeField, Range(1, 10)] private int _burst = 1;
        
        private void Start()
        {
            var gun = GetComponent<Gun>();

            if (_fireMode == FireMode.single)
            {
                gun.SetFireStrategy(new SingleshotFireStrategy(_ammo, _strayFactor, _range));
            }
            else if (_fireMode == FireMode.infinite)
            {
                gun.SetFireStrategy(new InfiniteFireStrategy(_strayFactor, _range));
            }
            else if (_fireMode == FireMode.multishot)
            {
                gun.SetFireStrategy(new MultishotFireStrategy(_ammo, _strayFactor, _range, _burst));
            }
        }
    }
}