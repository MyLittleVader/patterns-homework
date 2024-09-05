namespace SecondTask
{
    // For convenient creation of decorator classes
    public abstract class AttributeDecorator : IAttribute
    {
        protected readonly IAttribute Underlying;

        public AttributeDecorator(IAttribute attribute)
        {
            Underlying = attribute;
        }
        
        public virtual float GetValue()
        {
            return Underlying.GetValue();
        }

        public virtual void SetValue(float value)
        {
            Underlying.SetValue(value);
        }
    }
}