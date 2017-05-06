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
		/*
		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			IList<View> childs = new List<View> ();
			IList<View> children = new List<View> ();
			//Padding = new Thickness (10, 10, 10, 10);
			SizeRequest childSizeRequest = default (SizeRequest);
			SetSpacing (Children);
			double horizontal = x;
			double vertical = y;
			double maxHeight = 0;
			//x += 25;
			foreach (var child in Children) {
				if (!child.IsVisible)
					continue;

				childSizeRequest = child.GetSizeRequest (double.PositiveInfinity, height);
				double childWidth = childSizeRequest.Request.Width;
				double childHeight = childSizeRequest.Request.Height;

				if (x + childWidth >= width) {
					FlexLine flexLine = GenerateFlexLine (children);
					if (maxHeight < child.HeightRequest) {
						maxHeight = child.HeightRequest;
					}
					SizeRequest flexLineSizeRequest = flexLine.GetSizeRequest (double.PositiveInfinity, height);
					double flexLineWidth = childSizeRequest.Request.Width;
					double flexLineHeight = childSizeRequest.Request.Height;
					System.Diagnostics.Debug.WriteLine ("vertical: " + vertical);

					LayoutChildIntoBoundingRegion (flexLine, new Rectangle (x, vertical, width, maxHeight));
					System.Diagnostics.Debug.WriteLine ("bound in y:Y " + flexLine.Bounds.Location.Y); 
					vertical += maxHeight + Spacing;
					maxHeight = 0;
					x = horizontal;
					y += flexLineHeight; //DependingFlexOrientation(flexLine.CrossSize(height), flexLine.CrossSize(width));
					children.Clear ();
				}
				children.Add (child);
				x += (childWidth + Spacing);
				//DependingFlexOrientation(() => { x += (childWidth + Spacing); }, () => { y += (childHeight + Spacing); });

			}

			FlexLine lastFlexLine = GenerateFlexLine (children);
			SizeRequest lastFlexLineSizeRequest = lastFlexLine.GetSizeRequest (double.PositiveInfinity, height);
			double lastFlexLineWidth = childSizeRequest.Request.Width;
			double lastFlexLineHeight = childSizeRequest.Request.Height;
			LayoutChildIntoBoundingRegion (lastFlexLine, new Rectangle (0, y, width, lastFlexLineHeight));
		}


		*/

		//functional

		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			IList<View> childs = new List<View> ();
			IList<View> children = new List<View>();
			//Padding = new Thickness (10, 10, 10, 10);
			SizeRequest childSizeRequest = default(SizeRequest);
			SetSpacing (Children);
			double horizontal = x;
			double vertical = y;
			double maxHeight = 0;
			//x += 25;
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
					foreach (View LineChild in children) 
					{
						if (maxHeight < LineChild.HeightRequest) {
							maxHeight = LineChild.HeightRequest;
						}
					}
					SizeRequest flexLineSizeRequest = flexLine.GetSizeRequest(double.PositiveInfinity, height);
					double flexLineWidth = childSizeRequest.Request.Width;
					double flexLineHeight = childSizeRequest.Request.Height;
					LayoutChildIntoBoundingRegion(flexLine, new Rectangle(x, vertical, width, maxHeight));
					vertical += maxHeight + Spacing;
					maxHeight = 0;
					x = horizontal;
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
				Orientation = this.Orientation,
				AlignItems = this.AlignItems,
				Spacing = this.Spacing,
				BackgroundColor = Color.Transparent,
			};
			foreach (var child in children)
				flexLine.Children.Add(child);
			
			return flexLine;
		}

		private void SetSpacing (IList<View> childs)
		{
			double xSpace = Padding.Left+Padding.Right;
			double ySpace = Padding.Top + Padding.Bottom;

			foreach (View child in childs) {
				xSpace += child.Width;
			}
			Spacing = (this.Width-xSpace) / childs.Count;
			Padding = new Thickness (10, 10, 10, 10);
			//Spacing = 10;
		}
	}
}

