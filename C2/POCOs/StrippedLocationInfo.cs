namespace C2.POCOs;

public class StrippedLocationInfo
{
    public StrippedLocationInfo(LocationInfo locationInfo)
    {
        Continent = locationInfo.Continent_Name;
        Country = locationInfo.Country_Name;
        State = locationInfo.State_Prov;
        City = locationInfo.City;
        Zip = locationInfo.Zipcode;
        Latitude = locationInfo.Latitude;
        Longitude = locationInfo.Longitude;
        Flag = locationInfo.Country_Flag;
        TimeZoneName = locationInfo.Time_Zone.Name;
        ISP = locationInfo.Isp;
    }

    public string Continent;
    public string Country;
    public string State;
    public string City;
    public string Zip;
    public string Latitude;
    public string Longitude;
    public string Flag;
    public string TimeZoneName;
    public string ISP;
}
