using UnityEngine;

namespace SecondTask
{
    public class ClampedAttribute : AttributeDecorator
    {
        private float _min;
        private float _max;

        public ClampedAttribute(IAttribute attribute, float min = 0f, float max = 0f) : base(attribute)
        {
            _min = min;
            _max = max;
            
            // Ensure that min value is not higher than max value
            _max = Mathf.Max(_max, _min);
            
            SetValue(attribute.GetValue());
        }

        public sealed override void SetValue(float value)
        {
            float newValue = Mathf.Clamp(value, _min, _max);
            
            base.SetValue(newValue);
        }
    }
}