using System;
using System.Drawing.Imaging;
using System.Drawing;

namespace MTG.DataExtractor.Files.Format
{
    public class Jpeg
    {

        public static void VaryQualityLevel(string strImageOrigine, string strImageFinale, int iCompression)
        {
            // Get a bitmap.
            Bitmap bmp1 = new Bitmap(strImageOrigine);
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID 
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 
            // An EncoderParameters object has an array of EncoderParameter 
            // objects. In this case, there is only one 
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, iCompression);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(strImageFinale, jgpEncoder, myEncoderParameters);

        }


        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

    }
}
