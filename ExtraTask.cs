using System;
using System.Collections.Generic;

namespace Names;

internal static class ExtraTask
{
    public static double[] GetAverageBirthsPerDayByMonth(NameData[] names)
    {
        var birthsPerYearMonth = new Dictionary<(int Year, int Month), int>();

        foreach (var name in names)
        {
            var key = (name.BirthDate.Year, name.BirthDate.Month);

            if (!birthsPerYearMonth.TryAdd(key, 1))
                birthsPerYearMonth[key]++;
        }

        var monthBirthsSum = new double[12];
        var monthCount = new int[12];

        foreach (var ((year, month), birthsCount) in birthsPerYearMonth)
        {
            var dayRate = (double)birthsCount / DateTime.DaysInMonth(year, month);

            monthBirthsSum[month - 1] += dayRate;
            monthCount[month - 1]++;
        }

        var result = new double[12];
        for (var i = 0; i < 12; i++)
            if (monthCount[i] != 0)
                result[i] = monthBirthsSum[i] / monthCount[i];

        return result;
    }
}