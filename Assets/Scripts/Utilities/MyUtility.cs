
public static class MyUtility
{
    public static string toShortCurrency(this int longValue)   { return GetShortCurrency(longValue); }
    public static string toShortCurrency(this long longValue) { return GetShortCurrency(longValue); }

    public static string toGemShortCurrency(this long longValue) { return GetGemShortCurrency(longValue); }
    public static string toGemShortCurrency(this int longValue) { return GetGemShortCurrency(longValue); }

    public static string toFlexibleCurrency(this long longValue)
    {
        if(GlobalVariables.bIsCoins)
            return GetShortCurrency(longValue);
        else
            return GetGemShortCurrency(longValue);
    }

    private static string GetShortCurrency(long longValue)
    {
        if (longValue == 0)
            return "0";

        bool bIsBillion = false;
        bool bIsMillion = false;
        //bool bIsThousands = false;
        string strSuffix = "";

        if (System.Math.Abs(longValue) > 999999)
        {
            bIsBillion = true;
            strSuffix = " B";
        }
        else if (System.Math.Abs(longValue) > 999)
        {
            bIsMillion = true;
            strSuffix = " M";
        }
        else if (System.Math.Abs(longValue) > 0)
        {
            //bIsThousands = true;
            strSuffix = " K";
        }

        float newVal = 0.0f;
        if (bIsBillion)
            newVal = longValue / 1000000.0f;
        else if (bIsMillion)
            newVal = longValue / 1000.0f;
        else
            newVal = longValue;

        long oldVal = longValue;
        //return newVal.ToString("#.###") + strSuffix;
        string wholeNumber = newVal.ToString().Split('.')[0];
        string roundedNumber = newVal.ToString();

        if (wholeNumber.Length > 2)
            roundedNumber = newVal.ToString("N0");
        else if (wholeNumber.Length > 1)
            //roundedNumber = newVal.ToString("N1");
            roundedNumber = newVal.ToString("#.#");
        else if (wholeNumber.Length > 0)
            //roundedNumber = newVal.ToString("N2");
            roundedNumber = newVal.ToString("#.##");

        return roundedNumber + strSuffix;
    }

    public static string GetGemShortCurrency (long longValue )
    {

        if (longValue == 0)
            return "0";

        bool bIsBillion = false;
        bool bIsMillion = false;
        bool bIsThousands = false;
        string strSuffix = "";

        if (System.Math.Abs (longValue) > 999999999)
        {
            bIsBillion = true;
            strSuffix = " B";
        }
        else if (System.Math.Abs (longValue) > 999999)
        {
            bIsMillion = true;
            strSuffix = " M";
        }
        else if (System.Math.Abs (longValue) > 999)
        {
            bIsThousands = true;
            strSuffix = " K";
        }

        float newVal = 0.0f;
        if (bIsBillion)
            newVal = longValue / 1000000000.0f;
        else if (bIsMillion)
            newVal = longValue / 1000000.0f;
        else if (bIsThousands)
            newVal = longValue / 1000.0f;
        else
            newVal = longValue;

        long oldVal = longValue;
        //return newVal.ToString("#.###") + strSuffix;
        string wholeNumber = newVal.ToString ().Split ('.')[0];
        string roundedNumber = newVal.ToString ();

        if (wholeNumber.Length > 2)
            roundedNumber = newVal.ToString ("N0");
        else if (wholeNumber.Length > 1)
            //roundedNumber = newVal.ToString("N1");
            roundedNumber = newVal.ToString ("#.#");
        else if (wholeNumber.Length > 0)
            //roundedNumber = newVal.ToString("N2");
            roundedNumber = newVal.ToString ("#.##");

        return roundedNumber + strSuffix;
    }

    public static RoomInfo GetRoomInfoFromName(string strRoomName)
    {
        foreach(RoomInfo roomInfo in PhotonNetwork.GetRoomList())
        {
            if (roomInfo.Name == strRoomName)
                return roomInfo;
        }

        return null;
    }

    public static string GetRankTitleByIndex(int rankIndex)
    {
        string[] strRanks = { "ID_Rank01", "ID_Rank02", "ID_Rank03", "ID_Rank04", "ID_Rank05", "ID_Rank06", "ID_Rank07" };

        if(rankIndex < strRanks.Length)
            return LocalisationManager.instance.GetText(strRanks[rankIndex]);

        return "Unknown";
    }

}