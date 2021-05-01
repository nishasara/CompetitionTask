using System;
using System.Collections.Generic;
using System.Text;

namespace ShareSkill.Utilities
{
    class ServiceData
    {

        public static String ExcelPath = Resources.ShareSkillResource.ExcelPath;

        public static string TitleData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection( ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Title");
        }

        public static string DescriptionData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Description");
        }

        public static string CategData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Category");
        }

        public static string SubCategData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Subcategory");
        }

        public static string TagsCntData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "SkillExchangeTagsCount");
        }

        public static string SrvcTypeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Service Type");
        }

        public static string LocatnTypeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Location Type");
        }

        public static string SkillTrdeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Skill Trade");
        }

        public static string ActvStatusData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "ActiveStatus");
        }

        public static string StrtDateData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Start date");
        }

        public static string EndDateData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "End date");
        }

        public static string TagsData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Tags");
        }

        public static string TagsDataCount(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "TagsCount");
        }
        public static string[] SkillExchangeData(int RowNum)
        {
            int count = Int32.Parse(TagsCntData(RowNum));
            string[] SkillExchngData = new string[count];
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            for (int i = 0; i < count; i++)
            {
                SkillExchngData[i] = ExcelLibHelpers.ReadData((i + RowNum), "Skill-Exchange");
            }
            return SkillExchngData;
        }

        public static string CreditValue(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Credit");
        }

        public static string AvailableDays(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Available Days");
        }

        public static string AvailableDaysCnt(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "AvailableDaysCount");
        }

        public static string StrtTimeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Start Time");
        }

        public static string EndTimeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "End Time");
        }
    }
}
