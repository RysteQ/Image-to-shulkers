public class Spawn_Shulkers
{
    public Spawn_Shulkers(List<string> colours, int heightOfImage)
    {
        shulkerColours = colours;
        imageHeight = heightOfImage;
    }

    public void spawnShulkers(string outFilename)
    {
        if (File.Exists(outFilename))
            File.Delete(outFilename);

        StreamWriter outFile = new StreamWriter(outFilename);
        int zOffset = 0;
        int yOffset = 0;

        for (int i = 0; i < shulkerColours.Count; i += imageHeight)
        {
            if (shulkerColours[i] != "NEW_COLUMN")
            {
                outFile.WriteLine("/summon minecraft:shulker ~1 ~" + yOffset + " ~" + zOffset + " {Color:" + getColourCode(shulkerColours[i]) + passengerGenerator(i) + paddingGenerator());
            } else
            {
                zOffset = -1;
                yOffset++;
            }

            zOffset++;
        }

        outFile.Close();
    }

    private string passengerGenerator(int currentIndex)
    {
        string toReturn = "";
        
        for (int i = 1; i < imageHeight; i++)
        {
            toReturn += ", Passengers:[{id:shulker, Color:" + getColourCode(shulkerColours[i + currentIndex]).ToString();
        }

        return toReturn;
    }

    private string paddingGenerator()
    {
        string toReturn = "}";

        for (int i = 0; i < imageHeight - 1; i++)
            toReturn += "]}";

        return toReturn;
    }

    private int getColourCode(string colourName)
    {
        switch (colourName)
        {
            case "white":
                return 0;
            case "orange":
                return 1;
            case "magenta":
                return 2;
            case "light_blue":
                return 3;
            case "yellow":
                return 4;
            case "lime":
                return 5;
            case "pink":
                return 6;
            case "gray":
                return 7;
            case "light_gray":
                return 8;
            case "cyan":
                return 9;
            case "purple":
                return 10;
            case "blue":
                return 11;
            case "brown":
                return 12;
            case "green":
                return 13;
            case "red":
                return 14;
            case "black":
                return 15;
            default:
                return 0;
        }
    }

    private List<string> shulkerColours;
    private int imageHeight;
}