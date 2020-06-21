namespace EgnHelper
{
    using System;

    public class EgnData
    {
        public EgnGender Gender { get; set; }

        public int CurrentAge { get; set; }

        public DateTime BirthDate { get; set; }

        public string Region { get; set; }

        /// <summary>
        /// Returns the count of the people that are born before this human, for the selected birth date and for the same gender
        /// </summary>
        public int BornCountBeforeThisHuman { get; set; }

        public EgnConvertionStatus Status { get; set; }
    }
}