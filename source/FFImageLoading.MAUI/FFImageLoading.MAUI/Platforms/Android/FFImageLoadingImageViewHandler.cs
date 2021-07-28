﻿using System;
using System.Threading;
using System.Threading.Tasks;
//using FFImageLoading.Work;
using Android.Widget;
using FFImageLoading.MAUI.Handlers;
using FFImageLoading.Work;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

//[assembly: Xamarin.Forms.ExportImageSourceHandler(typeof(Xamarin.Forms.FileImageSource), typeof(FFImageLoading.MAUI.Platform.FFImageLoadingImageViewHandler))]
//[assembly: Xamarin.Forms.ExportImageSourceHandler(typeof(Xamarin.Forms.StreamImageSource), typeof(FFImageLoading.MAUI.Platform.FFImageLoadingImageViewHandler))]
//[assembly: Xamarin.Forms.ExportImageSourceHandler(typeof(Xamarin.Forms.UriImageSource), typeof(FFImageLoading.MAUI.Platform.FFImageLoadingImageViewHandler))]
//[assembly: Xamarin.Forms.ExportImageSourceHandler(typeof(FFImageLoading.MAUI.EmbeddedResourceImageSource), typeof(FFImageLoading.MAUI.Platform.FFImageLoadingImageViewHandler))]
//[assembly: Xamarin.Forms.ExportImageSourceHandler(typeof(FFImageLoading.MAUI.DataUrlImageSource), typeof(FFImageLoading.MAUI.Platform.FFImageLoadingImageViewHandler))]

namespace FFImageLoading.MAUI.Platform
{
	[Preserve(AllMembers = true)]
	public class FFImageLoadingImageViewHandler : HandlerBase<ImageView>, IImageViewHandler
	{
		public Task LoadImageAsync(Microsoft.Maui.Controls.ImageSource imageSource, ImageView imageView, CancellationToken cancellationToken = default)
		{
			try
			{
				if (!IsValid(imageView))
					return Task.CompletedTask;

				var source = ImageSourceBinding.GetImageSourceBinding(imageSource, null);
				if (source == null)
				{
					imageView.SetImageResource(Android.Resource.Color.Transparent);
					return Task.CompletedTask;
				}

				return LoadImageAsync(source, imageSource, imageView, cancellationToken);
			}
			catch (Exception)
			{
				return Task.CompletedTask;
			}
		}

		private static bool IsValid(ImageView imageView)
		{
			if (imageView == null || imageView.Handle == IntPtr.Zero)
				return false;

#pragma warning disable CS0618 // Type or member is obsolete
			var activity = imageView.Context as Android.App.Activity ?? (Android.App.Activity)Microsoft.Maui.MauiApplication.Context;
#pragma warning restore CS0618 // Type or member is obsolete
			if (activity != null)
			{
				if (activity.IsFinishing)
					return false;
				if (activity.IsDestroyed)
					return false;
			}
			else
			{
				return false;
			}

			return true;
		}

		protected override IImageLoaderTask GetImageLoaderTask(TaskParameter parameters, ImageView imageView)
		{
			return parameters.Into(imageView) as IImageLoaderTask;
		}
	}
}
