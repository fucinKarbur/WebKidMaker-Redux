using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
	public class KidConverter
	{
		public Texture2D ConvertBytesToTexture(byte[] bytes)
		{
			Texture2D texture = new(1, 1);

			return texture.LoadImage(bytes) ? texture : null;
		}

		public byte[] ConvertTextureToBytes(Texture2D texture)
		{
			return texture.EncodeToPNG();
		}
	}
}