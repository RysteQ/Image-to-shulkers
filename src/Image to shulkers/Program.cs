using System.Drawing;

/*
 * Input: File (image)
 * Output: File (txt)
 * 
 * Purpose: The purpose of this program is to turn any image into coloured minecraft shulkers, it takes an image as the input
 * and outputs a text file with the command needed for each column, in the future I will add a python script or anything
 * to automate the process of reading the commands and executing them in minecraft
 * 
 * Note: If you expect for me to comment my own code then lower your expectasions
*/

if (args.Length == 0)
{
    Console.WriteLine("No input file");
    Console.ReadKey();

    return;
}

Bitmap inputImage = new Bitmap(Image.FromFile(args[0]));

if (inputImage.Height * inputImage.Width > 10000)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Are you sure you want to continue with this image (Y / N) ?");
    Console.Write(">>> ");

    if (Console.ReadKey().ToString().ToUpper() == "N")
    {
        return;
    }
}

Detect_Colour detectColour = new Detect_Colour(inputImage);
List<string> colours = detectColour.getColours(new Config_File("config.cfg"));
Spawn_Shulkers shulkers = new Spawn_Shulkers(colours, inputImage.Height);
Datapack newDatapack = new Datapack();

newDatapack.createDatapack(shulkers.spawnShulkers("out.txt"));

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Done !!!!");
Console.ReadKey();