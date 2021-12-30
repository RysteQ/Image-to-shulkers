public class Datapack
{
    public void createDatapack(List<string> information)
    {
        if (File.Exists(Environment.CurrentDirectory + "\\image.mcfunction"))
            File.Delete(Environment.CurrentDirectory + "\\image.mcfunction");

        StreamWriter functionFile = new StreamWriter(Environment.CurrentDirectory + "\\image.mcfunction");

        for (int i = 0; i < information.Count; i++)
        {
            functionFile.WriteLine("execute as @a run " + information[i]);
        }

        functionFile.Close();
    }
}