namespace C2.POCOs;

public class LocationInfo
{
    public string Ip { get; set; }
    public string Continent_Code { get; set; }
    public string Continent_Name { get; set; }
    public string Country_Code2 { get; set; }
    public string Country_Code3 { get; set; }
    public string Country_Name { get; set; }
    public string Country_Name_Official { get; set; }
    public string Country_Capital { get; set; }
    public string State_Prov { get; set; }
    public string State_Code { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public bool IsEu { get; set; }
    public string Calling_Code { get; set; }
    public string Country_Tld { get; set; }
    public string Languages { get; set; }
    public string Country_Flag { get; set; }
    public string Geoname_Id { get; set; }
    public string Isp { get; set; }
    public string Connection_Type { get; set; }
    public string Organization { get; set; }
    public CurrencyInfo Currency { get; set; }
    public TimeZoneInfo Time_Zone { get; set; }
}

public class CurrencyInfo
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
}

public class TimeZoneInfo
{
    public string Name { get; set; }
    public int Offset { get; set; }
    public int Offset_With_Dst { get; set; }
    public string Current_Time { get; set; }
    public double Current_Time_Unix { get; set; }
    public bool Is_Dst { get; set; }
    public int Dst_Savings { get; set; }
}

