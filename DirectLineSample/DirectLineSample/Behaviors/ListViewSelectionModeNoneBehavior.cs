using System;
using Xamarin.Forms;

namespace DirectLineSample.Behaviors
{
    public class ListViewSelectionModeNoneBehavior : Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += this.Bindable_ItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= this.Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}
