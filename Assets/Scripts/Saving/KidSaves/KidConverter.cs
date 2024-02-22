using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
	public class KidConverter
	{
		private Texture2D _texture = new(100,100);

		public Texture2D ConvertBytesToTexture(byte[] bytes)
		{
			return _texture.LoadImage(bytes) ? _texture : null;
		}

		public byte[] ConvertTextureToBytes(Texture2D texture)
		{
			return texture.EncodeToPNG();
		}

		
	}
}