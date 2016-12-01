// Basado en: https://css-tricks.com/snippets/css/a-guide-to-flexbox/

using System;
using System.Collections.Generic;
using System.Linq;
using FlexLayout;
using Xamarin.Forms;

namespace FlexLayout
{
	public class FlexLayout : BaseLayout
	{
		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			IList<View> children = new List<View>();

			SizeRequest childSizeRequest = default(SizeRequest);

			foreach (var child in Children)
			{
				if (!child.IsVisible)
					continue;

				childSizeRequest = child.GetSizeRequest(double.PositiveInfinity, height);
				double childWidth = childSizeRequest.Request.Width;
				double childHeight = childSizeRequest.Request.Height;

				if (x + childWidth >= width)
				{
					FlexLine flexLine = GenerateFlexLine(children);
					SizeRequest flexLineSizeRequest = flexLine.GetSizeRequest(double.PositiveInfinity, height);
					double flexLineWidth = childSizeRequest.Request.Width;
					double flexLineHeight = childSizeRequest.Request.Height;
					LayoutChildIntoBoundingRegion(flexLine, new Rectangle(0, y, width, flexLineHeight));
					x = 0;
					y += flexLineHeight; //DependingFlexOrientation(flexLine.CrossSize(height), flexLine.CrossSize(width));
					children.Clear();
				}
				children.Add(child);

				x += (childWidth + Spacing);
				//DependingFlexOrientation(() => { x += (childWidth + Spacing); }, () => { y += (childHeight + Spacing); });

			}

			FlexLine lastFlexLine = GenerateFlexLine(children);
			SizeRequest lastFlexLineSizeRequest = lastFlexLine.GetSizeRequest(double.PositiveInfinity, height);
			double lastFlexLineWidth = childSizeRequest.Request.Width;
			double lastFlexLineHeight = childSizeRequest.Request.Height;
			LayoutChildIntoBoundingRegion(lastFlexLine, new Rectangle(0, y, width, lastFlexLineHeight));

		}

		private FlexLine GenerateFlexLine(IList<View> children)
		{
			var flexLine = new FlexLine()
			{
				Orientation = Orientation,
				AlignItems = AlignItems,
				Spacing = Spacing,
				BackgroundColor = Color.Transparent,
			};
			foreach (var child in children)
				flexLine.Children.Add(child);

			return flexLine;
		}
	}
}

