using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SecondTask
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _lvlText;
        [SerializeField] private ProgressBar _healthBar;
        [SerializeField] private Button _restartButton;

        private float _maxHealth;
        
        public void Initialize(float currentLevel, float currentHealth, float maxHealth)
        {
            _maxHealth = maxHealth;
            
            _lvlText.text = $"{currentLevel}";
            _healthBar.SetFillAmount(currentHealth / _maxHealth);
        }

        public void UpdateLevelUI(float newLevel)
        {
            _lvlText.text = $"{newLevel}";
        }
        
        public void UpdateHealthBar(float newHealth)
        {
            _healthBar.SetFillAmount(newHealth / _maxHealth);
        }

        public void ShowRestartOption()
        {
            Debug.Log("Player is dead");
            _restartButton.gameObject.SetActive(true);
        }

        public void HideRestartOption()
        {
            Debug.Log("Player is revived");
            _restartButton.gameObject.SetActive(false);
        }
    }
}