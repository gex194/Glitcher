namespace Glitcher.Services;

public class ImageGlitchService : IImageGlitchService
{
    public ImageGlitchService()
    {
    }

    public void GlitchImage(string imagePath, string outputPath, int amount = 1, int numberOfBytes = 500)
    {
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image not found. Make sure you have 'input.jpg' inside your root folder");
            return;
        }
        
        if (!Directory.Exists("output"))
        {
            Directory.CreateDirectory("output");
            Console.WriteLine("Output directory created");
        }
        else
        {
            Console.WriteLine("Output directory found");
        }

        for (int n = 0; n < amount; n++)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            Random random = new Random();
            int headerSize = random.Next(2000, 10500);
            int safeZoneStart = headerSize;
            int safeZoneEnd = imageBytes.Length - headerSize;
            
            outputPath = "./output/" + new DateTime().ToString("yyyy_MM_dd_HHmmss") + "_" + n + "_glitched.jpg";
            for (int i = headerSize; i < random.Next(headerSize, headerSize + numberOfBytes); i++)
            {
                int position = random.Next(safeZoneStart, safeZoneEnd);
                if (i % 2 == 0)
                {
                    imageBytes[position] ^= 0xFF;

                }
                else
                {
                    imageBytes[position] = (byte)random.Next(150, 254);
                }
            }
            File.WriteAllBytes(outputPath, imageBytes);
            Console.WriteLine($"Glitched image saved to: {outputPath}");
        }
    }
}