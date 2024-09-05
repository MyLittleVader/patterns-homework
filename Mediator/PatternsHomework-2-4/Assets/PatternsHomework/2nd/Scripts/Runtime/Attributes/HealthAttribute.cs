namespace SecondTask
{
    public class HealthAttribute : ObservableAttribute
    {
        public HealthAttribute(IAttribute attribute) : base(attribute)
        { }
    }
}