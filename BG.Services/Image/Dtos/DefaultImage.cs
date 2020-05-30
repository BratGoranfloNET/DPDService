using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace BG.Services.Image
{
	public class DefaultImage : MemoryStream
	{
		public DefaultImage(string virtualPath, string backGroundHtmlColor, string foregroundHtmlColor)
		{
			string letter = "?";

			if (!string.IsNullOrWhiteSpace(virtualPath))
			{
				var slug = Path.GetFileNameWithoutExtension(virtualPath);

				if (!"placeholder".Equals(slug))
					letter = $"{slug.First()}".ToUpper();
			}

			var backgroundColor = ColorTranslator.FromHtml(backGroundHtmlColor);
			var foreGroundColor = ColorTranslator.FromHtml(foregroundHtmlColor);

			using (var baseFont = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Regular, GraphicsUnit.Pixel))
			{
				using (var bitmap = new Bitmap(1000, 1000, PixelFormat.Format24bppRgb))
				{
					using (var graphics = Graphics.FromImage(bitmap))
					{
						var textSize = graphics.MeasureString(letter, baseFont);
						var fontScale = Math.Max(textSize.Width / bitmap.Width, textSize.Height / bitmap.Height);

                        using (var scaledFont = new Font(FontFamily.GenericSansSerif, baseFont.SizeInPoints / fontScale, FontStyle.Regular, GraphicsUnit.Pixel))                        
                        {
                            graphics.Clear(backgroundColor);
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            graphics.CompositingQuality = CompositingQuality.HighQuality;

                            StringFormat strinngFormat = new StringFormat(StringFormat.GenericTypographic)
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center,
                                FormatFlags = StringFormatFlags.MeasureTrailingSpaces
                            };

                            textSize = graphics.MeasureString(letter, scaledFont);

                            graphics.DrawString(
                                letter,
                                scaledFont,
                                new SolidBrush(foreGroundColor),
                                new RectangleF(
                                    0,
                                    0,
                                    bitmap.Width,
                                    bitmap.Height
                                ),
                                strinngFormat
                            );

                            bitmap.Save(this, ImageFormat.Jpeg);

                            Position = 0;
                        }
					}
				}
			}
		}
	}
}
