﻿// Copyright (c) 2010-2015 Anders Gustafsson, Cureos AB.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

namespace Windows.UI
{
	public static class ColorExtensions
	{
		 public static int ToArgb(this Color color)
		 {
			 return (color.A << 24) | (color.R << 16) | (color.G << 8) | color.B;
		 }
	}
}