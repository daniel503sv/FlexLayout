using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlexLayout
{
	public enum FlexJustifyContent
	{
		Start,
		End,
		Center,
		SpaceBetween,
		SpaceAround
	}

	public enum FlexAlignItems
	{
		Start,
		End,
		Center,
		Strech,
		Baseline
	}

	public enum FlexOrientation
	{
		Horizontal,
		Vertical
	}

	public abstract class BaseLayout : Layout<View>
	{
		public static readonly BindableProperty JustifyContentProperty = BindableProperty.Create(
			propertyName: "JustifyContent",
			returnType: typeof(FlexJustifyContent),
			declaringType: typeof(BaseLayout),
			defaultValue: FlexJustifyContent.Start,
			defaultBindingMode: BindingMode.TwoWay,
			propertyChanged: (bindable, oldvalue, newvalue) => ((BaseLayout)bindable).ForceLayout());

		public FlexJustifyContent JustifyContent
		{
			get { return (FlexJustifyContent)GetValue(JustifyContentProperty); }
			set { SetValue(JustifyContentProperty, value); }
		}

		public static readonly BindableProperty AlignItemsProperty = BindableProperty.Create(
			propertyName: "AlignItems",
			returnType: typeof(FlexAlignItems),
			declaringType: typeof(BaseLayout),
			defaultValue: FlexAlignItems.Start,
			defaultBindingMode: BindingMode.TwoWay,
			propertyChanged: (bindable, oldvalue, newvalue) => ((BaseLayout)bindable).ForceLayout());

		public FlexAlignItems AlignItems
		{
			get { return (FlexAlignItems)GetValue(AlignItemsProperty); }
			set { SetValue(AlignItemsProperty, value); }
		}

		public static readonly BindableProperty SpacingProperty = BindableProperty.Create(
			propertyName: "Spacing",
			returnType: typeof(double),
			declaringType: typeof(BaseLayout),
			defaultValue: default(double),
			defaultBindingMode: BindingMode.TwoWay,
			propertyChanged: (bindable, oldvalue, newvalue) => ((BaseLayout)bindable).ForceLayout());

		public double Spacing
		{
			get { return (double)GetValue(SpacingProperty); }
			set { SetValue(SpacingProperty, value); }
		}

		public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
			propertyName: "Orientation",
			returnType: typeof(FlexOrientation),
			declaringType: typeof(BaseLayout),
			defaultValue: FlexOrientation.Horizontal,
			defaultBindingMode: BindingMode.TwoWay,
			propertyChanged: (bindable, oldvalue, newvalue) => ((BaseLayout)bindable).ForceLayout());

		public FlexOrientation Orientation
		{
			get { return (FlexOrientation)GetValue(OrientationProperty); }
			set { SetValue(OrientationProperty, value); }
		}

		protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
		{
			double height = 0;
			double minHeight = 0;
			double width = 0;
			double minWidth = 0;

			for (int i = 0; i < Children.Count; i++)
			{
				var child = (View)Children[i];

				if (!child.IsVisible)
					continue;
				var childSizeRequest = child.GetSizeRequest(double.PositiveInfinity, height);
				height = Math.Max(height, childSizeRequest.Minimum.Height);
				minHeight = Math.Max(minHeight, childSizeRequest.Minimum.Height);
				width += childSizeRequest.Request.Width;
				minWidth += childSizeRequest.Minimum.Width;
			}

			return new SizeRequest(new Size(width, height), new Size(minWidth, minHeight));
		}

		#region Helpers
		public double CrossSize(double containerSize)
		{
			double crossSize = 0;
			foreach (var child in Children)
			{
				SizeRequest childSizeRequest = child.GetSizeRequest(double.PositiveInfinity, containerSize);
				crossSize = DependingFlexOrientation(Math.Max(crossSize, childSizeRequest.Request.Height),
										  Math.Max(crossSize, childSizeRequest.Request.Width));
			}
			return crossSize;
		}

		protected T DependingFlexOrientation<T>(T horizontalCase, T verticalCase)
		{
			if (Orientation == FlexOrientation.Horizontal)
				return horizontalCase;
			else
				return verticalCase;
		}
		protected void DependingFlexOrientation(Action horizontalCase, Action verticalCase)
		{
			if (Orientation == FlexOrientation.Horizontal)
				horizontalCase();
			else
				verticalCase();
		}

		protected double CalcSpare(double crossSize, double childWidth, double childHeight)
		{
			return DependingFlexOrientation(crossSize - childHeight, crossSize - childWidth);
		}
		#endregion
	}
}


