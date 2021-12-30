using System.Drawing;

/*
 * Input: Bitmap image
 * Output: List (string)
 * 
 * Purpose: To find what colour each pixel is with the semi hardcoded values the config file has, if a colour is not found it will just throw an exception
 */

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
                Color currentPixelColourRaw = image.GetPixel(x, y);
                string currentPixelColour = currentPixelColourRaw.Name.ToString().Substring(2, 6);

                for (int i = 0; i < colourValues.Count; i++)
                {
                    if (colourValues[i].Substring(0, 2) != "C_")
                    {
                        if (currentPixelColour == colourValues[i].ToString())
                        {
                            for (int k = i; k >= 0; k--)
                            {
                                if (colourValues[k].Substring(0, 2) == "C_")
                                {
                                    toReturn.Add(colourValues[k].Remove(0, 2));

                                    found = true;

                                    i = colourValues.Count;
                                    k = -1;
                                }
                            }

                            if (found == false)
                            {
                                throw new Exception("The colour with the RGB value of " + currentPixelColour +
                                                    " at the position x: " + x + " y: " + y +
                                                    " is not recognised, please update the config file with the new RGB value for the corresponding colour");
                            } else
                            {
                                found = false;
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