using System;
using Xamarin.Forms;

namespace FlexLayout
{
	public interface IFlexItem//<T> : View where T : View
	{
		


		//original interface
		/*public View View;
		public Rectangle Region;
		public double X
		{
			get
			{
				return Region.X;
			}
			set
			{
				Region.X = value;
			}
		}
		public double Y
		{
			get
			{
				return Region.Y;
			}
			set
			{
				Region.Y = value;
			}
		}
		public double Height
		{
			get
			{
				return Region.Height;
			}
			set
			{
				Region.Height = value;
			}
		}
		public double Width
		{
			get
			{
				return Region.Width;
			}
			set
			{
				Region.Width = value;
			}
		}

		public FlexItem()
		{
			View = default(View);
			Region = default(Rectangle);
		}

		public FlexItem(View view, Rectangle region)
		{
			View = view;
			Region = region;
		}*/

		/*
		public static readonly BindableProperty ItemProperty =
			BindableProperty.Create<FlexItem<T>, View>(f => f.Item, null);

		public View Item { 
			get {
				return (View)GetValue( ItemProperty );
			}
			set {
				SetValue( ItemProperty, value );
			}
		}

		public static readonly BindableProperty OrderProperty =
			BindableProperty.Create<FlexItem<T>, int>(f => f.Order, 0);

		public int Order { 
			get {
				return (int)GetValue( OrderProperty );
			}
			set {
				SetValue( OrderProperty, value );
			}
		}

		public static readonly BindableProperty GrowProperty =
			BindableProperty.Create<FlexItem<T>, float>(f => f.Grow, 0);

		public float Grow
		{
			get
			{
				return (float)GetValue(GrowProperty);
			}
			set
			{
				SetValue(GrowProperty, value);
			}
		}

		public static readonly BindableProperty ShrinkProperty =
			BindableProperty.Create<FlexItem<T>, float>(f => f.Shrink, 1);

		public float Shrink { 
			get {
				return (float)GetValue( ShrinkProperty );
			}
			set {
				SetValue( ShrinkProperty, value );
			}
		}

		public static readonly BindableProperty BasisProperty =
			BindableProperty.Create<FlexItem<T>, float>(f => f.Basis, 0);

		public float Basis
		{
			get
			{
				return (float)GetValue(BasisProperty);
			}
			set
			{
				SetValue(BasisProperty, value);
			}
		}*/
	}
}

