using System.IO;

public class Config_File
{
    public Config_File(string configFileName)
    {
        this.configFileName = Directory.GetCurrentDirectory() + "\\" + configFileName;
    }

    public List<string> readConfigFile()
    {
        StreamReader configFileReader = new StreamReader(configFileName);
        string[] configFileDataRaw = configFileReader.ReadToEnd().ToLower().Split('\n');
        List<string> toReturn = new List<string>();

        for (int i = 0; i < configFileDataRaw.Length; i++)
        {
            toReturn.Add("C_" + configFileDataRaw[i].Split(' ')[0].Trim());

            for (int j = 1; j < configFileDataRaw[i].Split(' ').Length; j++)
            {
                toReturn.Add(configFileDataRaw[i].Split(' ')[j].Trim());
            }
        }

        return toReturn;
    }

    private string configFileName;
}