namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var dayLabels = GetLabels(31);

        var birthsCount = new double[dayLabels.Length];
        foreach (var person in names)
            if (person.Name == name && person.BirthDate.Day != 1)
                birthsCount[person.BirthDate.Day - 1]++;

        return new HistogramData($"Рождаемость людей с именем '{name}'", dayLabels, birthsCount);
    }

    private static string[] GetLabels(int count)
    {
        var labels = new string[count];
        for (var i = 0; i < count; i++)
            labels[i] = (i + 1).ToString();

        return labels;
    }
}