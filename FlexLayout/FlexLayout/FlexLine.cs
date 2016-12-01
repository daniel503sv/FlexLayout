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
			double crossSize = 0;
			crossSize = DependingFlexOrientation(CrossSize(width), CrossSize(height));

			foreach (var child in Children)
			{
				if (!child.IsVisible)
					continue;

				SizeRequest childSizeRequest = child.GetSizeRequest(double.PositiveInfinity, height);
				double childWidth = childSizeRequest.Request.Width;
				double childHeight = childSizeRequest.Request.Height;
				LayoutChildIntoBoundingRegion(child, AlignItemsSwitch(crossSize, x, y, childWidth, childHeight));

				DependingFlexOrientation(() => { x += (childWidth + Spacing); }, () => { y += (childHeight + Spacing); });
			}
		}

		#region Align-Items Methods

		private Rectangle AlignItemsSwitch(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			var defaultRectangle = new Rectangle(x, y, childWidth, childHeight);
			switch (AlignItems)
			{
				case FlexAlignItems.Start:
					return defaultRectangle;
				case FlexAlignItems.End:
					return AlignEnd(crossSize, x, y, childWidth, childHeight);
				case FlexAlignItems.Center:
					return AlignCenter(crossSize, x, y, childWidth, childHeight);
				case FlexAlignItems.Strech:
					return AlignStrech(crossSize, x, y, childWidth, childHeight);
				case FlexAlignItems.Baseline:
					return defaultRectangle;
				default:
					return defaultRectangle;
			}
		}

		private Rectangle AlignEnd(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			double spare = CalcSpare(crossSize, childWidth, childHeight);

			return DependingFlexOrientation(new Rectangle(x, y + spare, childWidth, childHeight),
											new Rectangle(x + spare, y, childWidth, childHeight));
		}

		private Rectangle AlignCenter(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			double spare = CalcSpare(crossSize, childWidth, childHeight) / 2;

			return DependingFlexOrientation(new Rectangle(x, y + spare, childWidth, childHeight),
											new Rectangle(x + spare, y, childWidth, childHeight));
		}

		private Rectangle AlignStrech(double crossSize, double x, double y, double childWidth, double childHeight)
		{
			return DependingFlexOrientation(new Rectangle(x, y, childWidth, crossSize),
											new Rectangle(x, y, crossSize, childHeight));
		}
		#endregion
	}
}


