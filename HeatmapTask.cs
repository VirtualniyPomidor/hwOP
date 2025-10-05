namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        const int monthShift = 1;
        const int dayShift = 2;

        var monthLabels = GetLabels(12, monthShift);
        var dayLabels = GetLabels(30, dayShift);

        var heatMap = new double[dayLabels.Length, monthLabels.Length];
        foreach (var name in names)
            if (name.BirthDate.Day != 1)
                heatMap[name.BirthDate.Day - dayShift, name.BirthDate.Month - monthShift]++;

        return new HeatmapData("Карта интенсивности рождаемости", heatMap, dayLabels, monthLabels);
    }

    private static string[] GetLabels(int n, int shift)
    {
        var labels = new string[n];
        for (var i = 0; i < n; i++)
            labels[i] = (i + shift).ToString();

        return labels;
    }
}