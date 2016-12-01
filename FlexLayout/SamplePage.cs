using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace FlexLayout
{
	public class SamplePage : ContentPage
	{
		public SamplePage()
		{
			var mainLayout = new RelativeLayout();

			var justifyButtonsLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
			};
			mainLayout.Children.Add(justifyButtonsLayout,
									Constraint.Constant(0),
									Constraint.Constant(0),
									Constraint.RelativeToParent(p => p.Width),
									Constraint.Constant(60));
			var alingButtonsLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
			};
			mainLayout.Children.Add(alingButtonsLayout,
									Constraint.Constant(0),
									Constraint.Constant(60),
									Constraint.RelativeToParent(p => p.Width),
									Constraint.Constant(60));

			/*var layout = new FlexLayout()
			{
				Orientation = StackOrientation.Horizontal,
				StyleId = "container",
				Spacing = 10,
				BackgroundColor = Color.Gray,
				Children = {
					new BoxView() { BackgroundColor = Color.White, HeightRequest=100, WidthRequest=100 },
					new BoxView() { BackgroundColor = Color.White, HeightRequest=200, WidthRequest=100 },
					new BoxView() { BackgroundColor = Color.White, HeightRequest=100, WidthRequest=100 },
					new BoxView() { BackgroundColor = Color.White, HeightRequest=200, WidthRequest=100 },
				},
				JustifyContent = FlexJustifyContent.End,
				AlignItems = FlexAlignItems.Center,
			};*/
			var layout = new FlexLayout
			{
				Orientation = FlexOrientation.Horizontal,
				AlignItems = FlexAlignItems.End,
				Spacing = 5,
				BackgroundColor = Color.Gray,
				Children = {

					//new BoxView { BackgroundColor = Color.White, WidthRequest=100, HeightRequest=100 },
					//new BoxView { BackgroundColor = Color.Red, WidthRequest=200, HeightRequest=50 },
					//new BoxView { BackgroundColor = Color.Blue, WidthRequest=50, HeightRequest=100 },
					//new BoxView { BackgroundColor = Color.Black, WidthRequest=10, HeightRequest=150 },

					// Horizontal
					new BoxView { BackgroundColor = Color.Purple, HeightRequest=100, WidthRequest=100 },
					new BoxView { BackgroundColor = Color.Green, HeightRequest=200, WidthRequest=100 },
					new BoxView { BackgroundColor = Color.Olive, HeightRequest=100, WidthRequest=100 },
					new BoxView { BackgroundColor = Color.Aqua, HeightRequest=200, WidthRequest=100 },

					// Vertical
					//new BoxView { BackgroundColor = Color.White, WidthRequest=100, HeightRequest=100 },
					//new BoxView { BackgroundColor = Color.Red, WidthRequest=200, HeightRequest=100 },
					//new BoxView { BackgroundColor = Color.Blue, WidthRequest=100, HeightRequest=100 },
					//new BoxView { BackgroundColor = Color.Black, WidthRequest=200, HeightRequest=100 },
				},
				//JustifyContent = FlexJustifyContent.End,
				//AlignItems = FlexAlignItems.Center,
			};
			mainLayout.Children.Add(layout,
									Constraint.Constant(0),
									Constraint.Constant(120),
									Constraint.RelativeToParent(p => p.Width),
									Constraint.RelativeToParent(p => p.Height - 120)
								   );

			var startButton = new Button
			{
				Text = "S",
				WidthRequest = 60,
			};
			justifyButtonsLayout.Children.Add(startButton);
			startButton.Clicked += (sender, e) => layout.JustifyContent = FlexJustifyContent.Start;

			var endButton = new Button
			{
				Text = "E",
				WidthRequest = 60,
			};
			justifyButtonsLayout.Children.Add(endButton);
			endButton.Clicked += (sender, e) => layout.JustifyContent = FlexJustifyContent.End;

			var centerButton = new Button
			{
				Text = "C",
				WidthRequest = 60,
			};
			justifyButtonsLayout.Children.Add(centerButton);
			centerButton.Clicked += (sender, e) => layout.JustifyContent = FlexJustifyContent.Center;

			var spaceBetweenButton = new Button
			{
				Text = "SB",
				WidthRequest = 60,
			};
			justifyButtonsLayout.Children.Add(spaceBetweenButton);
			spaceBetweenButton.Clicked += (sender, e) => layout.JustifyContent = FlexJustifyContent.SpaceBetween;

			var spaceAroundButton = new Button
			{
				Text = "SA",
				WidthRequest = 60,
			};
			justifyButtonsLayout.Children.Add(spaceAroundButton);
			spaceAroundButton.Clicked += (sender, e) => layout.JustifyContent = FlexJustifyContent.SpaceAround;

			var alignStartButton = new Button
			{
				Text = "AS",
				WidthRequest = 60,
			};
			alingButtonsLayout.Children.Add(alignStartButton);
			alignStartButton.Clicked += (sender, e) => layout.AlignItems = FlexAlignItems.Start;

			var alignEndButton = new Button
			{
				Text = "AE",
				WidthRequest = 60,
			};
			alingButtonsLayout.Children.Add(alignEndButton);
			alignEndButton.Clicked += (sender, e) => layout.AlignItems = FlexAlignItems.End;

			var alignCenterButton = new Button
			{
				Text = "AC",
				WidthRequest = 60,
			};
			alingButtonsLayout.Children.Add(alignCenterButton);
			alignCenterButton.Clicked += (sender, e) => layout.AlignItems = FlexAlignItems.Center;

			var alignStrechButton = new Button
			{
				Text = "AST",
				WidthRequest = 60,
			};
			alingButtonsLayout.Children.Add(alignStrechButton);
			alignStrechButton.Clicked += (sender, e) => layout.AlignItems = FlexAlignItems.Strech;

			var verticalButton = new Button
			{
				Text = "V",
				WidthRequest = 60,
			};
			alingButtonsLayout.Children.Add(verticalButton);
			verticalButton.Clicked += (sender, e) => layout.Orientation = FlexOrientation.Vertical;

			var horizontalButton = new Button
			{
				Text = "H",
				WidthRequest = 60,
			};
			alingButtonsLayout.Children.Add(horizontalButton);
			horizontalButton.Clicked += (sender, e) => layout.Orientation = FlexOrientation.Horizontal;

			Content = mainLayout;//new ScrollView { Content = mainLayout };
		}
	}
}


