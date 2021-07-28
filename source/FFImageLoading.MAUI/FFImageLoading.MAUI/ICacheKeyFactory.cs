using System;
using Microsoft.Maui;using Microsoft.Maui.Controls;

namespace FFImageLoading.MAUI
{
    [Preserve(AllMembers = true)]
	public interface ICacheKeyFactory
	{
		string GetKey(ImageSource imageSource, object bindingContext);
	}
}

