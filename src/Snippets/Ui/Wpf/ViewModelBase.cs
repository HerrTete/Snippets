namespace Snippets.Ui.Wpf
{
    using System;
    using System.ComponentModel;

    /// <summary> Grundlage für ViewModels; bietet allgemeine Basisfunktionalitäten </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Geworfen, wenn sich eine Eigenschaft ändert
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Wird aufgerufen, um PropertyChanged-Event zu werden.
        /// </summary>
        /// <param name="property">Die geänderte Eigenschaft</param>
        public virtual void OnPropertyChanged(string property)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        protected bool SetProperty(string propertyName,
                           ref bool backingField,
                           bool newValue)
        {
            if (backingField != newValue)
            {
                backingField = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool SetProperty(string propertyName,
                                   ref int backingField,
                                   int newValue)
        {
            if (backingField != newValue)
            {
                backingField = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool SetProperty(string propertyName,
                                   ref string backingField,
                                   string newValue)
        {
            if (backingField != newValue)
            {
                backingField = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool SetProperty(string propertyName,
                                   ref double backingField,
                                   double newValue)
        {
            if (!backingField.Equals(newValue))
            {
                backingField = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool SetProperty(string propertyName,
                                   ref DateTime backingField,
                                   DateTime newValue)
        {
            if (backingField != newValue)
            {
                backingField = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool SetProperty<T>(string propertyName,
                                      ref T backingField,
                                      T newValue)
        {
            bool changed;
            if (newValue == null && backingField != null || newValue != null && backingField == null)
            {
                changed = true;
            }
            else if ((newValue == null && backingField == null) || backingField.Equals(newValue))
            {
                changed = false;
            }
            else
            {
                changed = true;
            }
            if (changed)
            {
                backingField = newValue;
                OnPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
