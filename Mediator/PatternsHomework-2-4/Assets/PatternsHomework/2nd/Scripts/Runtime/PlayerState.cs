using UnityEngine;

namespace SecondTask
{
    [RequireComponent(typeof(AttributesManager))]
    public class PlayerState : MonoBehaviour
    {
        [SerializeField] private AttributesManager _attributesManager;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private MovementComponent _movementComponent;
        [SerializeField] private PlayerUI _playerUI;
        
        [SerializeField, Range(0f, 100f)] private float _startingLevel = 0f;
        [SerializeField, Range(0f, 100f)] private float _maxLevel = 20f;
        [SerializeField, Range(0f, 100f)] private float _maxHealth = 100f;

        private void OnValidate()
        {
            if (_startingLevel >= _maxLevel)
            {
                _maxLevel = _startingLevel;
            }
            
            _attributesManager = GetComponent<AttributesManager>();
            _playerInput = GetComponentInChildren<PlayerInput>();
            _movementComponent = GetComponentInChildren<MovementComponent>();
            _playerUI = GetComponentInChildren<PlayerUI>();
        }

        public void Initialize()
        {
            InitializeAttributes();

            InitializeUI();

            _playerInput.enabled = true;
        }

        private void InitializeAttributes()
        {
            LevelAttribute levelAttribute =
                new LevelAttribute(new ClampedAttribute(new Attribute(_startingLevel), 0f, _maxLevel));
            _attributesManager.AddAttribute(levelAttribute);
            
            HealthAttribute healthAttribute =
                new HealthAttribute(new ClampedAttribute(new Attribute(_maxHealth), 0f, _maxHealth));
            _attributesManager.AddAttribute(healthAttribute);
            
            _attributesManager.SubscribeToAttributeChange<LevelAttribute>(OnLevelChange);
            _attributesManager.SubscribeToAttributeChange<HealthAttribute>(OnHealthChange);
        }

        private void InitializeUI()
        {
            var currentLevel = _attributesManager.GetAttributeValue<LevelAttribute>();
            var currentHealth = _attributesManager.GetAttributeValue<HealthAttribute>();
            
            _playerUI.Initialize(currentLevel, currentHealth, _maxHealth);
        }
        
        private void OnDestroy()
        {
            _attributesManager.UnsubscribeFromAttributeChange<LevelAttribute>(OnLevelChange);
            _attributesManager.UnsubscribeFromAttributeChange<HealthAttribute>(OnHealthChange);
        }

        public void Restart()
        {
            _movementComponent.transform.localPosition = Vector3.zero;
            
            _attributesManager.SetAttributeValue<LevelAttribute>(_startingLevel);
            _attributesManager.SetAttributeValue<HealthAttribute>(_maxHealth);

            _playerUI.HideRestartOption();
            
            _playerInput.enabled = true;
        }

        public void UpgradeLevel()
        {
            _attributesManager.IncrementAttributeValue<LevelAttribute>();
        }
        
        public void AddHealth(float value)
        {
            _attributesManager.AddToAttributeValue<HealthAttribute>(value);
        }

        public void SubtractHealth(float value)
        {
            _attributesManager.AddToAttributeValue<HealthAttribute>(-value);
        }

        private void OnLevelChange(float oldValue, float newValue)
        {
            _playerUI.UpdateLevelUI(newValue);
        }
        
        private void OnHealthChange(float oldValue, float newValue)
        {
            _playerUI.UpdateHealthBar(newValue);

            if (newValue > 0f)
                return;
            
            _playerUI.ShowRestartOption();
            
            // Disable player input on death
            _playerInput.enabled = false;
        }
    }
}
