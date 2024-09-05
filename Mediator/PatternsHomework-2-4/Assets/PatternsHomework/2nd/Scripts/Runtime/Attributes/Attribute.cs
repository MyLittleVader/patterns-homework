namespace SecondTask
{
    // Default attribute class
    public class Attribute : IAttribute
    {
        private float _value;
        
        public Attribute(float value = 0f)
        {
            SetValue(value);
        }

        public float GetValue()
        {
            return _value;
        }

        public void SetValue(float value)
        {
            _value = value;
        }
    }
}