using HotChoculate.Infrastructure.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace HotChoculate.Infrastructure.Core.Extensions
{
    public static class SqlValues
    {
        public static object ValueForSQL(object objValue, DataTypes objDataType)
        {
            switch (objDataType)
            {
                case DataTypes.Date:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {

                        return DBNull.Value;
                    }
                    else
                    {
                        return Convert.ToDateTime(objValue);
                    }

                case DataTypes.DateTimeDateOnly:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {

                        return DBNull.Value;
                    }
                    else
                    {
                        return Convert.ToDateTime(objValue).ToShortDateString();
                    }

                case DataTypes.Time:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {

                        return System.DBNull.Value;
                    }
                    else
                    {

                        return System.Convert.ToDateTime(objValue).ToShortTimeString();
                    }

                case DataTypes.DateTime:
                case DataTypes.DateTimeLong:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Convert.ToDateTime(objValue);
                    }

                case DataTypes.DateTimeTimeOnly:
                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return System.Convert.ToDateTime(objValue).ToShortTimeString();

                    }

                case DataTypes.Boolean:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {
                        return DBNull.Value;
                    }
                    else
                    {

                        return Convert.ToBoolean(objValue);
                    }

                case DataTypes.Currency:
                case DataTypes.CurrencyPos:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {

                        return System.DBNull.Value;
                    }
                    else
                    {

                        objValue = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol.Replace(Convert.ToChar(objValue), '\0');

                        if (System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator != null)
                        {
                            objValue = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator.Replace(Convert.ToChar(objValue), '\0');
                        }

                        if (double.TryParse(Convert.ToString(objValue), out double objValueResult))
                        {

                            return Convert.ToDecimal(objValueResult);
                        }
                        else
                        {

                            return DBNull.Value;
                        }

                    }

                case DataTypes.Integer:
                case DataTypes.IntegerPos:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {
                        return DBNull.Value;
                    }
                    else
                    {

                        if (int.TryParse(Convert.ToString(objValue), out int objValueResult))
                        {
                            return System.Convert.ToInt32(objValueResult);
                        }
                        else
                        {
                            return DBNull.Value;
                        }
                    }

                case DataTypes.Short:

                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {

                        return DBNull.Value;
                    }
                    else
                    {

                        if (short.TryParse(Convert.ToString(objValue), out short objValueResult))
                        {

                            return Convert.ToInt16(objValueResult);
                        }
                        else
                        {

                            return DBNull.Value;

                        }

                    }

                case DataTypes.PhoneNumberCleaned:

                    if (objValue == DBNull.Value || string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Convert.ToString(Regex.Replace(Convert.ToString(objValue), "\\D", string.Empty)).Trim();
                    }

                default:
                    if (string.IsNullOrEmpty(Convert.ToString(objValue)))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Convert.ToString(objValue).Trim();
                    }
            }
        }

        public static object ValueForSQL(object objValue, SqlDbType objDataType)
        {
            switch (objDataType)
            {
                case SqlDbType.NVarChar:
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.VarChar:
                    return ValueForSQL(objValue, DataTypes.Character);

                case SqlDbType.BigInt:
                case SqlDbType.Int:
                case SqlDbType.SmallInt:
                case SqlDbType.TinyInt:
                    return ValueForSQL(objValue, DataTypes.Integer);

                case SqlDbType.Money:
                case SqlDbType.Float:
                case SqlDbType.Decimal:
                case SqlDbType.SmallMoney:
                    return ValueForSQL(objValue, DataTypes.Decimal);

                case SqlDbType.Bit:
                    return ValueForSQL(objValue, DataTypes.Boolean);

                case SqlDbType.Date:
                    return ValueForSQL(objValue, DataTypes.Date);

                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.Timestamp:
                    return ValueForSQL(objValue, DataTypes.DateTime);

                case SqlDbType.Time:
                    return ValueForSQL(objValue, DataTypes.Time);

                default:
                    return ValueForSQL(objValue, DataTypes.Character);

            }
        }
    }
}
