﻿// Copyright (c) 2010-2013 Anders Gustafsson, Cureos AB.
// This source is subject to the Microsoft Public License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

using Dicom.Imaging.Codec.Jpeg;

namespace Dicom.Imaging.Codec
{
	public class DicomJpegProcess1Codec : DicomJpegNativeCodec
	{
		public override DicomTransferSyntax TransferSyntax
		{
			get { return DicomTransferSyntax.JPEGProcess1; }
		}

		protected override IJpegNativeCodec GetCodec(int bits, DicomJpegParams jparams)
		{
			if (bits == 8)
				return new Jpeg8Codec(JpegMode.Baseline, 0, 0);
			throw new DicomCodecException("Unable to create JPEG Process 1 codec for bits stored == {0}", bits);
		}
	}
}