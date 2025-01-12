﻿using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Graphics;

#if UITEST
using NUnit.Framework;
using Xamarin.UITest;
using Microsoft.Maui.Controls.Compatibility.UITests;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 488, "Resizing the Label results in wrapped text being cropped on iOS", PlatformAffected.iOS)]
	public class Issue488 : TestContentPage
	{
		protected override void Init()
		{
			var layout = new Compatibility.RelativeLayout
			{
				BackgroundColor = Colors.Gray
			};
			var label = new Label
			{
				Text = "I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text."
			};
			layout.Children.Add(label, () => new Rect(0, 0, 250, 400));
			Content = layout;
		}

		// Issue: #488
		// Text wrapping issue in Label

#if UITEST
		[Test]
		[Category(UITestCategories.ManualReview)]
		public void Issue488TestsLongTextRotation()
		{
			RunningApp.WaitForElement(q => q.Marked("I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text."));
			RunningApp.SetOrientationLandscape();
			RunningApp.Screenshot("Resize Label.Text by rotating to landscape");
			RunningApp.WaitForElement(q => q.Marked("I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text. I am a long bit of text."));
			RunningApp.Screenshot("Entire Label.Text present");
			RunningApp.SetOrientationPortrait();
			RunningApp.Screenshot("Rotated back to portrait");
			Assert.Inconclusive("Manual Review");
		}
#endif
	}
}
