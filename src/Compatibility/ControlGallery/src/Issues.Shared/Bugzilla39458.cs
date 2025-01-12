﻿using System;

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Graphics;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Bugzilla)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 39458, "[UWP/WinRT] Cannot Set CarouselPage.CurrentPage Inside Constructor", PlatformAffected.WinRT)]
	internal class Bugzilla39458 : TestCarouselPage
	{
		public class ChildPage : ContentPage
		{
			public ChildPage(int pageNumber)
			{
				var layout = new StackLayout();
				var MyLabel = new Label
				{
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					FontSize = 21,
					TextColor = Colors.White,
					Text = $"This is page {pageNumber}"
				};
				var TestBtn = new Button
				{
					Text = "Go to Page 2",
					IsEnabled = false,
					BackgroundColor = Colors.White
				};

				if (pageNumber != 2)
				{
					TestBtn.IsEnabled = true;
					TestBtn.Clicked += TestBtn_Clicked;
				}

				layout.Children.Add(MyLabel);
				layout.Children.Add(TestBtn);
				Content = layout;
			}

			private void TestBtn_Clicked(object sender, EventArgs e)
			{
				var carousel = Application.Current.MainPage as CarouselPage;
				carousel.CurrentPage = carousel.Children[1];
			}
		}

		public class DesiredPage : ChildPage
		{
			public DesiredPage(int pageNumber) : base(pageNumber)
			{
			}
		}

		protected override void Init()
		{
			var firstPage = new ChildPage(1);
			firstPage.BackgroundColor = Colors.Blue;
			Children.Add(firstPage);

			var secondPage = new DesiredPage(2);
			secondPage.BackgroundColor = Colors.Red;
			Children.Add(secondPage);

			var thirdPage = new ChildPage(3);
			thirdPage.BackgroundColor = Colors.Green;
			Children.Add(thirdPage);

			CurrentPage = secondPage;
		}

#if UITEST
		[Test]
		public void Bugzilla39458Test()
		{
			RunningApp.WaitForElement(q => q.Marked("This is page 2"));
		}
#endif
	}
}
