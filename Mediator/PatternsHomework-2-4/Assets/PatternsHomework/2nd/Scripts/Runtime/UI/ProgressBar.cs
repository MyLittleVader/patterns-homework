using UnityEngine;
using UnityEngine.UI;

namespace SecondTask
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void SetFillAmount(float fillAmount)
        {
            Debug.Log($"Set new fill amount. New value: {fillAmount}");
            _image.fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
        }
    }
}
