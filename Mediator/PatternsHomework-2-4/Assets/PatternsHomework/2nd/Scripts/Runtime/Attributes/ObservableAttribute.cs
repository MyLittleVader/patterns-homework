namespace SecondTask
{
    public class ObservableAttribute : AttributeDecorator
    {
        public delegate void OnAttributeValueChanged(float oldValue, float newValue);
        private OnAttributeValueChanged _onChanged;

        public ObservableAttribute(IAttribute attribute) : base(attribute)
        { }

        public override void SetValue(float value)
        {
            float oldValue = Underlying.GetValue();
            
            Underlying.SetValue(value);

            float newValue = Underlying.GetValue();
            
            if (oldValue != newValue)
            {
                _onChanged?.Invoke(oldValue, newValue);
            }
            
        }

        public void Subscribe(OnAttributeValueChanged onValueChanged)
        {
            _onChanged += onValueChanged;
        }

        public void Unsubscribe(OnAttributeValueChanged onValueChanged)
        {
            _onChanged -= onValueChanged;
        }
    }
}