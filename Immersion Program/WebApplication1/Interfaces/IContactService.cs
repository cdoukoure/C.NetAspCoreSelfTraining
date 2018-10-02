using System;
using System.Data.SqlTypes;


namespace WebAspCoreDapper.Interfaces
{
    public interface IContactService
    {
        string GetRandomString(Int32 minLen, Int32 maxLen, Int32 seed);

        SqlString GetRandomPattern(SqlString pat, SqlInt32 seed);

        DateTime GetRandomDateTime();
    }
}
