using System.Drawing;

public class Detect_Colour
{
    public Detect_Colour(Bitmap image)
    {
        this.image = image;
    }

    public List<string> getColours(Config_File configFile)
    {
        List<string> colourValues = configFile.readConfigFile();
        List<string> toReturn = new List<string>();
        bool found = false;

        for (int x = 0; x < image.Width; x++)
        {
            for (int y = image.Height - 1; y >= 0; y--)
            {
                Color currentPixelColour = image.GetPixel(x, y);

                for (int i = 0; i < colourValues.Count; i++)
                {
                    if (colourValues[i].Substring(0, 2) != "C_")
                    {
                        if (currentPixelColour.Name.ToString().Substring(2, 6) == colourValues[i].ToString())
                        {
                            for (int k = i; k >= 0; k--)
                            {
                                if (colourValues[k].Substring(0, 2) == "C_")
                                {
                                    toReturn.Add(colourValues[k].Remove(0, 2));
                                    i = colourValues.Count;
                                    k = -1;
                                }
                            }
                        }
                    }
                }
            }
        }

        return toReturn;
    }

    private Bitmap image;
}