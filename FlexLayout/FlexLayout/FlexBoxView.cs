using System;
using Xamarin.Forms.Platform;
using Xamarin.Forms;



namespace FlexLayout
{
	public class FlexBoxView : FlexView
	{

	}

	public interface IFlexView
	{

	}

	public enum FlexAlignSelf
	{
		Start,
		End,
		Center,
		Fill
	}

	public enum FlexGrow
	{
		auto
	}

	public enum FlexShrink
	{
		NoWrap,
		Wrap,
		Reverse
	}
	public enum FlexBasis
	{
		auto,
		fill,
		max,
		min
	}

	public abstract class FlexView : View
	{
		//Properties
		public static readonly BindableProperty BasisProperty = BindableProperty.Create (
				propertyName: "Basis",
				returnType: typeof (FlexBasis),
				declaringType: typeof (FlexView),
				defaultValue: FlexBasis.auto,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: HandleBasisPropertyChanged
		);

		public FlexBasis Basis {
			get { return (FlexBasis)GetValue (BasisProperty); }
			set {
				SetValue (BasisProperty, value);
			}
		}

		public static readonly BindableProperty GrowProperty = BindableProperty.Create (
			propertyName: "Grow",
			returnType: typeof (FlexGrow),
			declaringType: typeof (FlexView),
			defaultValue: FlexGrow.auto,
			defaultBindingMode: BindingMode.OneWay,
			propertyChanged: HandleGrowPropertyChanged
		);

		public FlexGrow Grow {
			get { return (FlexGrow)GetValue (GrowProperty); }
			set {
				SetValue (GrowProperty, value);
			}
		}

		public static readonly BindableProperty AlignSelfProperty = BindableProperty.Create (
			propertyName: "AlignSelf",
			returnType: typeof (FlexAlignSelf),
			declaringType: typeof (FlexView),
			defaultValue: FlexAlignSelf.Center,
			defaultBindingMode: BindingMode.OneWay,
			propertyChanged: HandleAlignSelfPropertyChanged
		);
		public FlexAlignSelf AlignSelf {
			get { return (FlexAlignSelf)GetValue (AlignSelfProperty); }
			set {
				SetValue (AlignSelfProperty, value);
				changeVerticalOption (AlignSelf);
			}
		}

		static void HandleAlignSelfPropertyChanged (BindableObject bindable, object oldValue, object newValue)
		{
			// on align change
			var option = (FlexAlignSelf)newValue;
			var box = (FlexView)bindable;
			box.changeVerticalOption (option);
		}

		static void HandleGrowPropertyChanged (BindableObject bindable, object oldValue, object newValue)
		{
			//var box = (FlexBoxView)bindable;
			//var option = (FlexGrow)newValue;

			//on grow Change
		}

		static void HandleBasisPropertyChanged (BindableObject bindable, object oldValue, object newValue)
		{
			//on basis Change
		}


		public void changeVerticalOption (FlexAlignSelf option)
		{
			switch (option) {
			case FlexAlignSelf.Center:
				this.VerticalOptions = LayoutOptions.Center;
				break;

			case FlexAlignSelf.End:
				this.VerticalOptions = LayoutOptions.End;
				break;
			case FlexAlignSelf.Start:
				this.VerticalOptions = LayoutOptions.Start;
				break;
			case FlexAlignSelf.Fill:
				this.VerticalOptions = LayoutOptions.Fill;
				break;
			}

		}
	}

}
