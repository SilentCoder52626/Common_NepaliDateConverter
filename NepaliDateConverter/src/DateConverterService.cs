namespace NepaliDateConverter
{
    public class DateConverterService : IDateConverterService
    {

        public DateConverterService()
        {
        }
        public DateTime ToAD(string date)
        {

            int def_eyy = 0;
            int def_emm = 0;
            int def_edd = 0;
            int def_nyy = 0;
            int total_eDays = 0;
            int total_nDays = 0;
            int a = 0;
            int day = 0;
            int m = 0;
            int y = 0;
            int i = 0;
            int j = 0;
            int k = 0;
            int numDay = 0;

            //split nepali dates to get its year,month and day

            System.String[] userDateParts = date.Split(new[] { "/" }, System.StringSplitOptions.None);
            int yy = int.Parse(userDateParts[0]);
            int mm = int.Parse(userDateParts[1]);
            int dd = int.Parse(userDateParts[2]);

            //get starting nepali and english date for conversion 
            //Initialize english date
            Tuple<int, int[]> initializationDates = GetClosestEnglishDateAndNepaliDateToAD(yy);

            int nepali_init_date = initializationDates.Item1;
            int[] english_init_date = initializationDates.Item2;
            //Initialize english date
            //def_eyy = 1943;
            //def_emm = 4;
            //def_edd = 13;

            def_eyy = english_init_date[0];
            def_emm = english_init_date[1];
            def_edd = english_init_date[2];

            //Equivalent nepali date
            // def_nyy = 2000;
            def_nyy = nepali_init_date;

            //Initializations
            total_eDays = 0;
            total_nDays = 0;
            a = 0;
            day = 3;
            m = 0;
            i = 0;

            //  k = 0;
            k = nepali_init_date;
            numDay = 0;

            int[] month = new int[]{
            0,
            31,
            28,
            31,
            30,
            31,
            30,
            31,
            31,
            30,
            31,
            30,
            31
        };

            int[] lmonth = new int[]{
            0,
            31,
            29,
            31,
            30,
            31,
            30,
            31,
            31,
            30,
            31,
            30,
            31
        };

            while ((i < (yy - def_nyy)))
            {
                j = 1;
                while ((j <= 12))
                {
                    total_nDays += GetLastDayOfNepaliMonth(k, j);
                    j += 1;
                }

                i += 1;
                k += 1;
            }

            j = 1;
            while ((j < mm))
            {
                total_nDays += GetLastDayOfNepaliMonth(k, j);
                j += 1;
            }
            total_nDays += dd;

            total_eDays = def_edd;
            m = def_emm;
            y = def_eyy;


            while ((!(total_nDays == 0)))
            {
                if ((IsLeapYear(y)))
                {
                    a = lmonth[m];
                }
                else
                {
                    a = month[m];
                }

                total_eDays += 1;
                day += 1;

                if ((total_eDays > a))
                {
                    m += 1;
                    total_eDays = 1;

                    if ((m > 12))
                    {
                        y += 1;
                        m = 1;
                    }
                }

                if ((day > 7))
                    day = 1;
                total_nDays -= 1;

            }
            numDay = day;

            return (new DateTime(y, m, total_eDays));


        }
        public Tuple<int, int[]> GetClosestEnglishDateAndNepaliDateToAD(int nep_year)
        {
            try
            {
                if (nep_year > 2105)
                    throw new Exception("Nepali date must be between 1970 and 2105.");

                else if (nep_year >= 2100)
                    return Tuple.Create(2100, new int[] { 2043, 04, 14 });
                else if (nep_year >= 2095)
                    return Tuple.Create(2095, new int[] { 2038, 04, 13 });

                else if (nep_year >= 2090)
                    return Tuple.Create(2090, new int[] { 2033, 04, 13 });

                else if (nep_year >= 2085)
                    return Tuple.Create(2085, new int[] { 2028, 04, 12 });

                else if (nep_year >= 2080)
                    return Tuple.Create(2080, new int[] { 2023, 04, 13 });

                else if (nep_year >= 2075)
                    return Tuple.Create(2075, new int[] { 2018, 04, 13 });

                else if (nep_year >= 2070)
                    return Tuple.Create(2070, new int[] { 2013, 04, 13 });

                else if (nep_year >= 2065)
                    return Tuple.Create(2065, new int[] { 2008, 04, 12 });

                else if (nep_year >= 2060)
                    return Tuple.Create(2060, new int[] { 2003, 04, 13 });

                else if (nep_year >= 2055)
                    return Tuple.Create(2055, new int[] { 1998, 04, 13 });

                else if (nep_year >= 2050)
                    return Tuple.Create(2050, new int[] { 1993, 04, 12 });

                else if (nep_year >= 2045)
                    return Tuple.Create(2045, new int[] { 1988, 04, 12 });

                else if (nep_year >= 2040)
                    return Tuple.Create(2040, new int[] { 1983, 04, 13 });

                else if (nep_year >= 2035)
                    return Tuple.Create(2035, new int[] { 1978, 04, 13 });

                else if (nep_year >= 2030)
                    return Tuple.Create(2030, new int[] { 1973, 04, 12 });

                else if (nep_year >= 2025)
                    return Tuple.Create(2025, new int[] { 1968, 04, 12 });

                else if (nep_year >= 2020)
                    return Tuple.Create(2020, new int[] { 1963, 04, 13 });

                else if (nep_year >= 2015)
                    return Tuple.Create(2015, new int[] { 1958, 04, 12 });

                else if (nep_year >= 2010)
                    return Tuple.Create(2010, new int[] { 1953, 04, 12 });

                else if (nep_year >= 2005)
                    return Tuple.Create(2005, new int[] { 1948, 04, 12 });

                else if (nep_year >= 2000)
                    return Tuple.Create(2000, new int[] { 1943, 04, 13 });

                else if (nep_year >= 1995)
                    return Tuple.Create(1995, new int[] { 1938, 04, 12 });

                else if (nep_year >= 1990)
                    return Tuple.Create(1990, new int[] { 1933, 04, 12 });

                else if (nep_year >= 1985)
                    return Tuple.Create(1985, new int[] { 1928, 04, 12 });

                else if (nep_year >= 1980)
                    return Tuple.Create(1980, new int[] { 1923, 04, 12 });

                else if (nep_year >= 1975)
                    return Tuple.Create(1975, new int[] { 1918, 04, 12 });

                else if (nep_year >= 1970)
                    return Tuple.Create(1970, new int[] { 1913, 04, 12 });
                else
                    throw new Exception("Nepali Date must be between 1970 and 2105");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsLeapYear(int year)
        {
            if ((year % 100 == 0))
            {
                if ((year % 400 == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((year % 4 == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int GetLastDayOfNepaliMonth(int year, int month)
        {
            Dictionary<int, int[]> daysInMonthByYear = new Dictionary<int, int[]>();
            daysInMonthByYear.Add(1970, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1971, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1972, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(1973, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1974, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1975, new int[] { 31, 31, 32, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1976, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1977, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1978, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1979, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1980, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1981, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1982, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1983, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1984, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1985, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1986, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1987, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1988, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1989, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1990, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1991, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1992, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1993, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1994, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1995, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(1996, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1997, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1998, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1999, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2000, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2001, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2002, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2003, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2004, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2005, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2006, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2007, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2008, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });

            daysInMonthByYear.Add(2009, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2010, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2011, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2012, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2013, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2014, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2015, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2016, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2017, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2018, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2019, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2020, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2021, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2022, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2023, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2024, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2025, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2026, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2027, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2028, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2029, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2030, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2031, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2032, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2033, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2034, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2035, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });

            daysInMonthByYear.Add(2036, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2037, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2038, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2039, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2040, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2041, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2042, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2043, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2044, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2045, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2046, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2047, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2048, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2049, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });

            daysInMonthByYear.Add(2050, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2051, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2052, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2053, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2054, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2055, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2056, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2057, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2058, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2059, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2060, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2061, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2062, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2063, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2064, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2065, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2066, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });
            daysInMonthByYear.Add(2067, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2068, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2069, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2070, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2071, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2072, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2073, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2074, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2075, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2076, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2077, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2078, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2079, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2080, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2081, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2082, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2083, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2084, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2085, new int[] { 31, 32, 31, 32, 30, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2086, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2087, new int[] { 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2088, new int[] { 30, 31, 32, 32, 30, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2089, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });

            daysInMonthByYear.Add(2090, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2091, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2092, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2093, new int[] { 31, 32, 31, 31, 31, 31, 30, 29, 30, 29, 30, 31 });
            daysInMonthByYear.Add(2094, new int[] { 31, 31, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2095, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2096, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2097, new int[] { 31, 32, 31, 31, 31, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2098, new int[] { 31, 31, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2099, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2100, new int[] { 31, 32, 31, 32, 30, 31, 30, 29, 30, 29, 30, 30 });


            daysInMonthByYear.Add(2101, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2102, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2103, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2104, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2105, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2106, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2107, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2108, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2109, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2110, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2111, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2112, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2113, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2114, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2115, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2116, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2117, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2118, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2119, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2120, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });


            return (daysInMonthByYear[year])[month - 1];
        }

        public NepaliDate ToBS(DateTime date)
        {
            NepaliDate nepaliDate = new NepaliDate();
            //Breaking given english date
            int yy = 0;
            int mm = 0;
            int dd = 0;
            yy = date.Year;
            mm = date.Month;
            dd = date.Day;

            //English month data
            int[] month = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            int[] lmonth = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            int def_eyy = 0;
            int def_nyy = 0;
            int def_nmm = 0;
            int def_ndd = 0;
            int total_eDays = 0;
            int total_nDays = 0;
            int a = 0;
            int day = 0;
            int m = 0;
            int y = 0;
            int i = 0;
            int j = 0;
            int numDay = 0;

            //Initialize english date
            Tuple<int[], int[], int> initializationDates = GetClosestEnglishDateAndNepaliDate(date);

            int[] english_init_date = initializationDates.Item1;
            int[] nepali_init_date = initializationDates.Item2;
            // def_eyy = 1944;
            def_eyy = english_init_date[0];

            //Equivalent nepali date
            def_nyy = nepali_init_date[0];
            def_nmm = nepali_init_date[1];
            def_ndd = nepali_init_date[2];

            //Initializations
            total_eDays = 0;
            total_nDays = 0;
            a = 0;
            day = 6;
            m = 0;
            i = 0;
            j = 0;
            numDay = 0;

            //Count total number of days in terms of year
            while ((i < (yy - def_eyy)))
            {
                j = 0;
                if ((IsLeapYear(def_eyy + i)))
                {
                    while ((j < 12))
                    {
                        total_eDays += lmonth[j];
                        j += 1;
                    }
                }
                else
                {
                    while ((j < 12))
                    {
                        total_eDays += month[j];
                        j += 1;
                    }

                }
                i += 1;
            }

            //Count total number of days in terms of month
            i = 0;
            while ((i < (mm - 1)))
            {
                if ((this.IsLeapYear(yy)))
                {
                    total_eDays += lmonth[i];
                }
                else
                {
                    total_eDays += month[i];
                }
                i += 1;
            }

            //Count total number of days in terms of dates
            total_eDays += dd;

            // i = 0;
            //below i is the starting nepali year, used in looping to loop through years above the specified year
            i = def_nyy;
            j = def_nmm;
            total_nDays = def_ndd;
            m = def_nmm;
            y = def_nyy;

            //Count nepali date from array
            while ((!(total_eDays == 0)))
            {
                a = GetLastDayOfMonthNep(i, j);
                total_nDays += 1;
                day += 1;

                if ((total_nDays > a))
                {
                    m += 1;
                    total_nDays = 1;
                    j += 1;
                }

                if ((day > 7))
                    day = 1;
                if ((m > 12))
                {
                    y += 1;
                    m = 1;
                }

                if ((j > 12))
                {
                    j = 1;
                    i += 1;
                }
                total_eDays -= 1;
            }

            numDay = day;

            //return (new System.DateTime(y, m, total_nDays));
            //format = {4/30/2073 12:00:00 AM}

            nepaliDate.Year = y;
            nepaliDate.Month = GetTwoDigitNumber(m);
            nepaliDate.Day = GetTwoDigitNumber(total_nDays);
            nepaliDate.WeekDayName = GetNepaliDayOfWeek(date.DayOfWeek.ToString());
            nepaliDate.MonthName = GetNepaliMonth(m);
            return nepaliDate;

        }
        private string GetNepaliMonth(int month)
        {
            return nepaliMonthUnicode[month].Trim();
        }
        public static List<string> MonthListRomanized = new List<string>
        {
            "Baisakh",
            "Jestha",
            "Ashadh",
            "Shrawan",
            "Bhadra",
            "Ashwin",
            "Kartik",
            "Mangshir",
            "Poush",
            "Magh",
            "Falgun",
            "Chaitra",
        };
        public static Dictionary<int, string> nepaliMonthUnicode = new Dictionary<int, string>() {
            {1, "बैशाख"},
            {2, "जेष्ठ"},
            {3, "आषाढ"},
            {4, "श्रावण"},
            {5, "भाद्र"},
            {6, "असोज"},
            {7, "कार्तिक"},
            {8, "मंसिर"},
            {9, "पौष"},
            {10, "माघ"},
            {11, "फागुन"},
            {12, "चैत्र"},
        };
        public string GetNepaliDayOfWeek(string day)
        {

            switch (day)
            {
                case "Sunday":
                    return "आइतवार";
                case "Monday":
                    return "सोमवार";
                case "Tuesday":
                    return "मङ्गलवार";
                case "Wednesday":
                    return "बुधवार";
                case "Thursday":
                    return "बिहिवार";
                case "Friday":
                    return "शुक्रवार";
                case "Saturday":
                    return "शनिवार";
                default:
                    return "";
            }
        }
        protected string GetTwoDigitNumber(int number)
        {
            switch (number)
            {
                case 1:
                    return "01";
                case 2:
                    return "02";
                case 3:
                    return "03";
                case 4:
                    return "04";
                case 5:
                    return "05";
                case 6:
                    return "06";
                case 7:
                    return "07";
                case 8:
                    return "08";
                case 9:
                    return "09";
            }
            return number.ToString();
        }
        public Tuple<int[], int[], int> GetClosestEnglishDateAndNepaliDate(DateTime english_date)
        {
            try
            {
                if (english_date.Year > 2065)
                    throw new Exception("English date must be between 1914 and 2065.");

                else if (english_date.Year >= 2039)
                    return Tuple.Create(new int[] { 2039 }, new int[] { 2095, 09, 16 }, 1);

                else if (english_date.Year >= 2034)
                    return Tuple.Create(new int[] { 2034 }, new int[] { 2090, 09, 16 }, 1);

                else if (english_date.Year >= 2029)
                    return Tuple.Create(new int[] { 2029 }, new int[] { 2085, 09, 16 }, 1);

                else if (english_date.Year >= 2024)
                    return Tuple.Create(new int[] { 2024 }, new int[] { 2080, 09, 15 }, 1);

                else if (english_date.Year >= 2019)
                    return Tuple.Create(new int[] { 2019 }, new int[] { 2075, 09, 16 }, 2);

                else if (english_date.Year >= 2014)
                    return Tuple.Create(new int[] { 2014 }, new int[] { 2070, 09, 16 }, 3);

                else if (english_date.Year >= 2009)
                    return Tuple.Create(new int[] { 2009 }, new int[] { 2065, 09, 16 }, 4);

                else if (english_date.Year >= 2004)
                    return Tuple.Create(new int[] { 2004 }, new int[] { 2060, 09, 16 }, 4);

                else if (english_date.Year >= 1999)
                    return Tuple.Create(new int[] { 1999 }, new int[] { 2055, 09, 16 }, 5);

                else if (english_date.Year >= 1994)
                    return Tuple.Create(new int[] { 1994 }, new int[] { 2050, 09, 16 }, 6);

                else if (english_date.Year >= 1989)
                    return Tuple.Create(new int[] { 1989 }, new int[] { 2045, 09, 17 }, 0);

                else if (english_date.Year >= 1984)
                    return Tuple.Create(new int[] { 1984 }, new int[] { 2040, 09, 16 }, 0);

                else if (english_date.Year >= 1979)
                    return Tuple.Create(new int[] { 1979 }, new int[] { 2035, 09, 16 }, 1);

                else if (english_date.Year >= 1974)
                    return Tuple.Create(new int[] { 1974 }, new int[] { 2030, 09, 16 }, 2);


                else if (english_date.Year >= 1969)
                    return Tuple.Create(new int[] { 1969 }, new int[] { 2025, 09, 17 }, 3);

                else if (english_date.Year >= 1964)
                    return Tuple.Create(new int[] { 1964 }, new int[] { 2020, 09, 16 }, 3);

                else if (english_date.Year >= 1959)
                    return Tuple.Create(new int[] { 1959 }, new int[] { 2015, 09, 16 }, 4);

                else if (english_date.Year >= 1954)
                    return Tuple.Create(new int[] { 1954 }, new int[] { 2010, 09, 17 }, 5);

                else if (english_date.Year >= 1949)
                    return Tuple.Create(new int[] { 1949 }, new int[] { 2005, 09, 17 }, 6);

                else if (english_date.Year >= 1944)
                    return Tuple.Create(new int[] { 1944 }, new int[] { 2000, 09, 16 }, 6);

                else if (english_date.Year >= 1939)
                    return Tuple.Create(new int[] { 1939 }, new int[] { 1995, 09, 16 }, 0);

                else if (english_date.Year >= 1934)
                    return Tuple.Create(new int[] { 1934 }, new int[] { 1990, 09, 16 }, 1);

                else if (english_date.Year >= 1929)
                    return Tuple.Create(new int[] { 1929 }, new int[] { 1985, 09, 17 }, 2);

                else if (english_date.Year >= 1924)
                    return Tuple.Create(new int[] { 1924 }, new int[] { 1980, 09, 16 }, 2);

                else if (english_date.Year >= 1919)
                    return Tuple.Create(new int[] { 1919 }, new int[] { 1975, 09, 17 }, 3);

                else if (english_date.Year >= 1914)
                    return Tuple.Create(new int[] { 1914 }, new int[] { 1970, 09, 17 }, 4);


                else
                    throw new Exception("English date must be between 1914 and 2065.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLastDayOfMonthNep(int year, int month)
        {
            Dictionary<int, int[]> daysInMonthByYear = new Dictionary<int, int[]>();
            daysInMonthByYear.Add(1970, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1971, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1972, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(1973, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1974, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1975, new int[] { 31, 31, 32, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1976, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1977, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1978, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1979, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1980, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1981, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1982, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1983, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1984, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1985, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1986, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1987, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1988, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(1989, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1990, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1991, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1992, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1993, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1994, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1995, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(1996, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(1997, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1998, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(1999, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2000, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2001, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2002, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2003, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2004, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2005, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2006, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2007, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2008, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });

            daysInMonthByYear.Add(2009, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2010, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2011, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2012, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2013, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2014, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2015, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2016, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2017, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2018, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2019, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2020, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2021, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2022, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2023, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2024, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2025, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2026, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2027, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2028, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2029, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2030, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2031, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2032, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2033, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2034, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2035, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });

            daysInMonthByYear.Add(2036, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2037, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2038, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2039, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2040, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2041, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2042, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2043, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2044, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2045, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2046, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2047, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2048, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2049, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });

            daysInMonthByYear.Add(2050, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2051, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2052, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2053, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2054, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2055, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2056, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2057, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2058, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2059, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2060, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2061, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });

            daysInMonthByYear.Add(2062, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2063, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2064, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2065, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2066, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });
            daysInMonthByYear.Add(2067, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2068, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2069, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2070, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2071, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2072, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2073, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2074, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2075, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2076, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2077, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2078, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2079, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });

            daysInMonthByYear.Add(2080, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2081, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });
            daysInMonthByYear.Add(2082, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2083, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2084, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2085, new int[] { 31, 32, 31, 32, 30, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2086, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2087, new int[] { 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2088, new int[] { 30, 31, 32, 32, 30, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2089, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });

            daysInMonthByYear.Add(2090, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2091, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2092, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2093, new int[] { 31, 32, 31, 31, 31, 31, 30, 29, 30, 29, 30, 31 });
            daysInMonthByYear.Add(2094, new int[] { 31, 31, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2095, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2096, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2097, new int[] { 31, 32, 31, 31, 31, 31, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2098, new int[] { 31, 31, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2099, new int[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 });
            daysInMonthByYear.Add(2100, new int[] { 31, 32, 31, 32, 30, 31, 30, 29, 30, 29, 30, 30 });


            daysInMonthByYear.Add(2101, new int[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2102, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2103, new int[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2104, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2105, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2106, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2107, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2108, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2109, new int[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2110, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2111, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 });
            daysInMonthByYear.Add(2112, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2113, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2114, new int[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2115, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2116, new int[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 });

            daysInMonthByYear.Add(2117, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2118, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2119, new int[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 });
            daysInMonthByYear.Add(2120, new int[] { 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 });

            daysInMonthByYear.Add(2121, new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 });
            daysInMonthByYear.Add(2122, new int[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 });

            return (daysInMonthByYear[year])[month - 1];
        }



    }
}
