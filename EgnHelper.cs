namespace EgnHelper
{
    using System;

    public class EgnHelper : IEgnHelper
    {
        /// <summary>
        /// Retruns basic bulgarian citizen information using the specified EGN
        /// </summary>
        public EgnData GetEgnData(string egn)
        {
            if (egn.Length != 10)
                return new EgnData { Status = EgnConvertionStatus.InvalidEgn };

            if (!IsControlDigitCorrect(egn))
                return new EgnData { Status = EgnConvertionStatus.InvalidEgn };

            var birthYear = Convert.ToInt16(egn[0..2]);
            var birthMonth = Convert.ToByte(egn[2..4]);
            var birthDay = Convert.ToByte(egn[4..6]);
            var gender = Convert.ToByte(egn[8..9]);
            var regionCode = Convert.ToInt16(egn[6..9]);

            var resultBirthYearPrefix = "19";

            // born after 1999
            if (birthMonth >= 41)
            {
                birthMonth -= 40;
                resultBirthYearPrefix = "20";
            }
            // born before 1900
            else if (birthMonth >= 21)
            {
                birthMonth -= 20;
                resultBirthYearPrefix = "18";
            }

            var resultBirthYear = Convert.ToInt16($"{resultBirthYearPrefix}{birthYear.ToString().PadLeft(2, '0')}");
            var now = DateTime.Now;
            var currentYear = now.Year;
            var currentMonth = now.Month;
            var currentDay = now.Day;

            var age = (byte)(currentYear - resultBirthYear - 1);
            if ((currentMonth > birthMonth) || (currentMonth == birthMonth && currentDay >= birthDay))
                age++;

            return new EgnData
            {
                Gender = gender % 2 == 0 ? EgnGender.Male : EgnGender.Female,
                CurrentAge = age,
                BirthDate = new DateTime(resultBirthYear, birthMonth, birthDay),
                Region = EgnRegionHelper.GetRegionByCode(regionCode)?.Name,
                BornCountBeforeThisHuman = EgnRegionHelper.GetBornCountBeforeThisHuman(regionCode),
                Status = EgnConvertionStatus.ValidEgn
            };
        }

        private bool IsControlDigitCorrect(string egn)
        {
            var controlDigit = Convert.ToByte(egn[9..10]);

            var first = GetControlResult(egn[0], 2);
            var second = GetControlResult(egn[1], 4);
            var third = GetControlResult(egn[2], 8);
            var fourth = GetControlResult(egn[3], 5);
            var fifth = GetControlResult(egn[4], 10);
            var sixth = GetControlResult(egn[5], 9);
            var seventh = GetControlResult(egn[6], 7);
            var eighth = GetControlResult(egn[7], 3);
            var ninth = GetControlResult(egn[8], 6);

            var firstResult = (first + second + third + fourth + fifth + sixth + seventh + eighth + ninth);
            var secondResult = firstResult - (11 * (firstResult / 11));

            return controlDigit == secondResult;
        }

        private byte GetControlResult(char egnChar, byte weight)
        {
            // - '0' converts the char to int without getting its ASCII representation code
            return Convert.ToByte((egnChar - '0') * weight);
        }
    }
}