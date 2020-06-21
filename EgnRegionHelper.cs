using System.Collections.Generic;
using System.Linq;

namespace EgnHelper
{
    public class EgnRegionHelper
    {
        private static List<EgnRegion> _regions;

        static EgnRegionHelper()
        {
            _regions = new List<EgnRegion>();

            _regions.Add(new EgnRegion { Name = "Благоевград", MaxCode = 43 });
            _regions.Add(new EgnRegion { Name = "Бургас", MaxCode = 93 });
            _regions.Add(new EgnRegion { Name = "Варна", MaxCode = 139 });
            _regions.Add(new EgnRegion { Name = "Велико Търново", MaxCode = 169 });
            _regions.Add(new EgnRegion { Name = "Видин", MaxCode = 183 });
            _regions.Add(new EgnRegion { Name = "Враца", MaxCode = 217 });
            _regions.Add(new EgnRegion { Name = "Габрово", MaxCode = 233 });
            _regions.Add(new EgnRegion { Name = "Кърджали", MaxCode = 281 });
            _regions.Add(new EgnRegion { Name = "Кюстендил", MaxCode = 301 });
            _regions.Add(new EgnRegion { Name = "Ловеч", MaxCode = 319 });
            _regions.Add(new EgnRegion { Name = "Монтана", MaxCode = 341 });
            _regions.Add(new EgnRegion { Name = "Пазарджик", MaxCode = 377 });
            _regions.Add(new EgnRegion { Name = "Перник", MaxCode = 395 });
            _regions.Add(new EgnRegion { Name = "Плевен", MaxCode = 435 });
            _regions.Add(new EgnRegion { Name = "Пловдив", MaxCode = 501 });
            _regions.Add(new EgnRegion { Name = "Разград", MaxCode = 527 });
            _regions.Add(new EgnRegion { Name = "Русе", MaxCode = 555 });
            _regions.Add(new EgnRegion { Name = "Силистра", MaxCode = 575 });
            _regions.Add(new EgnRegion { Name = "Сливен", MaxCode = 601 });
            _regions.Add(new EgnRegion { Name = "Смолян", MaxCode = 623 });
            _regions.Add(new EgnRegion { Name = "София - град", MaxCode = 721 });
            _regions.Add(new EgnRegion { Name = "София - окръг", MaxCode = 751 });
            _regions.Add(new EgnRegion { Name = "Стара Загора", MaxCode = 789 });
            _regions.Add(new EgnRegion { Name = "Добрич (Толбухин)", MaxCode = 821 });
            _regions.Add(new EgnRegion { Name = "Търговище", MaxCode = 843 });
            _regions.Add(new EgnRegion { Name = "Хасково", MaxCode = 871 });
            _regions.Add(new EgnRegion { Name = "Шумен", MaxCode = 903 });
            _regions.Add(new EgnRegion { Name = "Ямбол", MaxCode = 925 });
            _regions.Add(new EgnRegion { Name = "Друг/Неизвестен", MaxCode = 999 });
        }

        /// <summary>
        /// Returns born count before this human for the selected birth date and for the same gender
        /// </summary>
        public static int GetBornCountBeforeThisHuman(short regionCode)
        {
            var minRegionCode = _regions
                .OrderByDescending(x => x.MaxCode)
                .FirstOrDefault(x => x.MaxCode <= regionCode)
                .MaxCode;

            var result = (regionCode - minRegionCode) / 2;
            return result;
        }

        public static EgnRegion GetRegionByCode(short regionCode)
        {
            // We are taking the first maxCode region which can contain the specified regionCode in it's range
            return _regions
                .OrderBy(x => x.MaxCode)
                .FirstOrDefault(x => x.MaxCode >= regionCode);
        }
    }
}