using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySeed
{
    public static class Utility
    {
        public static string readString(this ExcelWorksheet sheet, int row, int col)
        {
            return sheet.Cells[row, col].Value.ToString().Trim();
        }

        public static int readInteger(this ExcelWorksheet sheet, int row, int col)
        {
            string s = sheet.Cells[row, col].Value.ToString().Trim();
            return Convert.ToInt32(s);
        }
        //ovako i za ostale podatke
        public static decimal readDecimal(this ExcelWorksheet sheet, int row, int col)
        {
            return decimal.Parse(sheet.Cells[row, col].Value.ToString().Trim());
        }
        public static DateTime readDate(this ExcelWorksheet sheet, int row, int col)
        {
            string s = sheet.Cells[row, col].Value.ToString().Trim();
            DateTime d= Convert.ToDateTime(s);
            return d;
        }

    }
}
