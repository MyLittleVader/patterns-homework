using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SecondTask
{
    public class AttributesManager : MonoBehaviour
    {
        private List<ObservableAttribute> _attributes = new();

        public void TryAddAttribute<T>(T attributeToAdd) where T : ObservableAttribute
        {
            if (attributeToAdd == null)
                throw new ArgumentNullException(nameof(attributeToAdd));
            
            var attribute = _attributes.FirstOrDefault(attribute => attribute is T);

            if (attribute != null)
            {
                Debug.LogError($"There is already an added {attribute.GetType().Name}");
                return;
            }
            
            _attributes.Add(attributeToAdd);
        }

        public void TryRemoveAttribute<T>() where T : ObservableAttribute
        {
            var attributeIndex = _attributes.FindIndex(attribute => attribute is T);
            
            if (attributeIndex == -1)
                throw new ArgumentNullException(typeof(T).Name);
            
            _attributes.RemoveAt(attributeIndex);
        }

        public void TrySetAttribute<T>(float value) where T : ObservableAttribute
        {
            var attribute = _attributes.FirstOrDefault(attribute => attribute is T);
            
            if (attribute == null)
                throw new ArgumentNullException(typeof(T).Name);
            
            attribute.SetValue(value);
        }

        public float TryAddToAttribute<T>(float value) where T : ObservableAttribute
        {
            var attribute = _attributes.FirstOrDefault(attribute => attribute is T);

            if (attribute == null)
                throw new ArgumentNullException(typeof(T).Name);

            var newValue = attribute.GetValue();
            newValue += value;
            attribute.SetValue(newValue);

            return attribute.GetValue();
        }

        public float TryIncrementAttribute<T>() where T : ObservableAttribute
        {
            return TryAddToAttribute<T>(1f);
        }

        public float TryGetAttributeValue<T>() where T : ObservableAttribute
        {
            var attribute = _attributes.FirstOrDefault(attribute => attribute is T);

            if (attribute == null)
                throw new ArgumentNullException(typeof(T).Name);
            
            return attribute.GetValue();
        }

        public void TrySubscribeToAttribute<T>(ObservableAttribute.OnAttributeValueChanged onChanged) 
            where T : ObservableAttribute
        {
            ObservableAttribute attribute = _attributes.FirstOrDefault(attribute => attribute is T);

            if (attribute == null)
                throw new ArgumentNullException(typeof(T).Name);
            
            attribute.Subscribe(onChanged);
        }
        
        public void TryUnsubscribeFromAttribute<T>(ObservableAttribute.OnAttributeValueChanged onChanged) 
            where T : ObservableAttribute
        {
            ObservableAttribute attribute = _attributes.FirstOrDefault(attribute => attribute is T);

            if (attribute == null)
                throw new ArgumentNullException(typeof(T).Name);
            
            attribute.Unsubscribe(onChanged);
        }
    }
}
