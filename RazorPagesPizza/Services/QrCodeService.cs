using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QRCoder;

namespace RazorPagesPizza.Services
{
	public class QrCodeService
	{
		private readonly QRCodeGenerator _generator;
		
		public QrCodeService(QRCodeGenerator generator)
		{
			_generator = generator;
		}
		
		public string GetQrCodeAsBase64(string textToEncode)
		{
			QRCodeData qrCodeData = _generator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q);
			var qrCode = new PngByteQRCode(qrCodeData);
			
			return Convert.ToBase64String(qrCode.GetGraphic(4));
		}
	}
}