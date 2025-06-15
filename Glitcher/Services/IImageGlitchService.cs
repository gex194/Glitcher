namespace Glitcher.Services;

public interface IImageGlitchService
{
    public void GlitchImage(string imagePath, string outputPath, int amount = 1, int numberOfBytes = 1050);
}