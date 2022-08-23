﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml;
using WPoint = Windows.Foundation.Point;
namespace Microsoft.Maui.Platform
{
	internal static class RoutedEventArgsExtensions
	{

		public static void SetHandled(this RoutedEventArgs e, bool value)
		{
			if (e is RightTappedRoutedEventArgs rt)
				rt.Handled = value;
			else if (e is TappedRoutedEventArgs t)
				t.Handled = value;
			else if (e is DoubleTappedRoutedEventArgs dt)
				dt.Handled = value;
		}

		public static WPoint GetPosition(this RoutedEventArgs e, UIElement? relativeTo)
		{
			if (e is RightTappedRoutedEventArgs rt)
				return rt.GetPosition(relativeTo);
			else if (e is TappedRoutedEventArgs t)
				return t.GetPosition(relativeTo);
			else if (e is DoubleTappedRoutedEventArgs dt)
				return dt.GetPosition(relativeTo);

			throw new InvalidOperationException();
		}
	}
}
