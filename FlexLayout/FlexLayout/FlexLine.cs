using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FlexLayout
{
	public class FlexLine : BaseLayout
	{
		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			System.Diagnostics.Debug.WriteLine ("FlexLine recived y: " + y);
			double crossSize = 0;
			double insideY = this.Bounds.Location.Y;
			System.Diagnostics.Debug.WriteLine("Inside bound in Y: " + insideY);
			crossSize = DependingFlexOrientation(CrossSize(width), CrossSize(height));
			y = insideY;
			foreach (var child in Children)
			{
				if (!child.IsVisible)
					continue;

				SizeRequest childSizeRequest = child.GetSizeRequest(double.PositiveInfinity, height);
				double childWidth = childSizeRequest.Request.Width;
				double childHeight = childSizeRequest.Request.Height;
				System.Diagnostics.Debug.WriteLine ("Rectangle (" + x + ","+y+")");
				LayoutChildIntoBoundingRegion(child, AlignItemsSwitch(crossSize, x, this.Bounds.Y, childWidth, childHeight));
				DependingFlexOrientation(() => { x += (childWidth + Spacing); }, () => { insideY += (childHeight + Spacing); });
			}
		}

		#region Align-Items Methods

		private Rectangle AlignItemsSwitch(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			System.Diagnostics.Debug.WriteLine ("rectangle y: " + y);
			var defaultRectangle = new Rectangle(x, this.Bounds.Y, childWidth, childHeight);
			switch (AlignItems)
			{
				case FlexAlignItems.Start:
					return defaultRectangle;
				case FlexAlignItems.End:
					return AlignEnd(crossSize, x, this.Bounds.Y, childWidth, childHeight);
				case FlexAlignItems.Center:
					return AlignCenter(crossSize, x, this.Bounds.Y, childWidth, childHeight);
				case FlexAlignItems.Strech:
					return AlignStrech(crossSize, x, this.Bounds.Y, childWidth, childHeight);
				case FlexAlignItems.Baseline:
					return defaultRectangle;
				default:
					return defaultRectangle;
			}
		}

		private Rectangle AlignEnd(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			double spare = CalcSpare(crossSize, childWidth, childHeight);

			return DependingFlexOrientation(new Rectangle(x, this.Bounds.Y + spare, childWidth, childHeight),
											new Rectangle(x + spare, this.Bounds.Y, childWidth, childHeight));
		}

		private Rectangle AlignCenter(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			double spare = CalcSpare(crossSize, childWidth, childHeight) / 2;

			return DependingFlexOrientation(new Rectangle(x, this.Bounds.Y + spare, childWidth, childHeight),
											new Rectangle(x + spare, this.Bounds.Y, childWidth, childHeight));
		}

		private Rectangle AlignStrech(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			return DependingFlexOrientation(new Rectangle(x, this.Bounds.Y, childWidth, crossSize),
											new Rectangle(x, this.Bounds.Y, crossSize, childHeight));
		}
		#endregion
	}
}


