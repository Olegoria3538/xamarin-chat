using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OurMessenger2
{
	public partial class MainPage : ContentPage
	{
		public const string OurTitle = "Title for our messenger";
		public MainPage()
		{
			Title = "Main page";

			InitializeComponent();

			var trigger = new Trigger(typeof(Editor));
			trigger.Property = Editor.IsFocusedProperty;
			trigger.Value = true;
			trigger.EnterActions.Add(new EditorTriggerAction());
			trigger.ExitActions.Add(new EditorTriggerAction());
			MyEditor.Triggers.Add(trigger);
		}
		private void ButtonApplyText_Pressed(object sender, EventArgs e)
		{
			ComplicatedLabel.Text = MyEditor.Text;
		}
		private void ButtonChangeColor_Pressed(object sender, EventArgs e)
		{
			Resources["LabelColor"] = Color.Green;
		}
		private async void ButtonAskMe_Pressed(object sender, EventArgs e)
		{
			var sheetResult = await DisplayActionSheet("Title", "NO!", "Destroy", "First", "Second", "Third");
			var result = await DisplayAlert("Title", "Are you sure?", "Yes", "No");
			await DisplayAlert("Title", $"For information: {sheetResult}, {result}", "Ok");
		}

		private void ButtonSecond_Pressed(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new SecondPage());
		}
		private void ButtonThird_Pressed(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new ThirdPage());
		}
	}

	public class EditorTriggerAction : TriggerAction<Editor>
	{
		protected override void Invoke(Editor sender)
		{
			sender.FadeTo(sender.IsFocused ? 1 : 0.5);
		}
	}
	public class RednessExtension : IMarkupExtension
	{
		public double Value { get; set; }
		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
		{

			return Color.FromRgb(Value, 0, 0);
		}
	}
}
