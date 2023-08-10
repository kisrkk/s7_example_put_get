using System.IO;
using YamlDotNet.Serialization;
public class CalculationData
{
    public double CalculationValue { get; set; }
}

public static class YAMLHelper
{
    private const string FilePath = "calculation_data.yaml";
 

    public static void SaveCalculationData(double calculationValue)
    {
        var data = new CalculationData { CalculationValue = calculationValue };
        var serializer = new SerializerBuilder().Build();
        var yaml = serializer.Serialize(data);
        File.WriteAllText(FilePath, yaml);
    }

    public static double ReadCalculationData()
    {
        if (!File.Exists(FilePath))
            return 0.0; // Or any default value you prefer

        var deserializer = new DeserializerBuilder().Build();
        var yaml = File.ReadAllText(FilePath);
        var data = deserializer.Deserialize<CalculationData>(yaml);

        return data?.CalculationValue ?? 0.0; // Return the stored value or a default value if deserialization fails
    }
}
