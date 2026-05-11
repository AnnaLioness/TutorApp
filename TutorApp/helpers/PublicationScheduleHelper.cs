using Models.Enums;
using Models.Models;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorApp.helpers
{
    public class PublicationScheduleHelper
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Рассчитать дату и время публикации на основе материала
        /// </summary>
        public DateTime CalculateSchedule(MaterialModel material)
        {
            DateTime scheduledDate = CalculateDate(material);
            TimeSpan scheduledTime = CalculateTime(material.AgeGroup);
            DateTime result = scheduledDate.Date + scheduledTime;

            if (result <= DateTime.Now)
            {
                result = GetNextAvailableDate(material, result);
            }

            return result;
           // return DateTime.Now.AddMinutes(10);
        }

        private DateTime CalculateDate(MaterialModel material)
        {
            if (material.IsHoliday && material.Holiday.HasValue)
            {
                DateTime holidayDate = GetHolidayDate(material.Holiday.Value, DateTime.Now.Year);
                if (holidayDate.Date < DateTime.Now.Date)
                {
                    holidayDate = GetHolidayDate(material.Holiday.Value, DateTime.Now.Year + 1);
                }
                return holidayDate;
            }

            return GetRandomDateInSeason(material.Season, DateTime.Now.Year);
        }

        private DateTime GetHolidayDate(Holiday holiday, int year)
        {
            var field = holiday.GetType().GetField(holiday.ToString());
            var attribute = field?.GetCustomAttribute<HolidayDate>();

            if (attribute != null)
            {
                return new DateTime(year, attribute.Month, attribute.Day);
            }

            return new DateTime(year, 1, 1);
        }

        private DateTime GetRandomDateInSeason(Season season, int year)
        {
            var (startDate, endDate) = GetSeasonDateRange(season, year);

            if (endDate.Date < DateTime.Now.Date)
            {
                (startDate, endDate) = GetSeasonDateRange(season, year + 1);
            }

            int daysRange = (endDate - startDate).Days;
            int randomDays = _random.Next(0, daysRange + 1);
            return startDate.AddDays(randomDays);
        }

        private (DateTime start, DateTime end) GetSeasonDateRange(Season season, int year)
        {
            return season switch
            {
                Season.Весна => (new DateTime(year, 3, 1), new DateTime(year, 5, 31)),
                Season.Лето => (new DateTime(year, 6, 1), new DateTime(year, 8, 31)),
                Season.Осень => (new DateTime(year, 9, 1), new DateTime(year, 11, 30)),
                Season.Зима => (new DateTime(year, 12, 1), new DateTime(year, 12, 31)),
                _ => (new DateTime(year, 1, 1), new DateTime(year, 12, 31))
            };
        }

        private TimeSpan CalculateTime(AgeGroup ageGroup)
        {
            return ageGroup switch
            {
                AgeGroup.A => new TimeSpan(16, 0, 0),
                AgeGroup.B => new TimeSpan(17, 0, 0),
                AgeGroup.C => new TimeSpan(18, 0, 0),
                AgeGroup.D => new TimeSpan(19, 0, 0),
                _ => new TimeSpan(18, 0, 0)
            };
        }

        private DateTime GetNextAvailableDate(MaterialModel material, DateTime currentDate)
        {
            DateTime nextDate = currentDate;
            int maxAttempts = 365;
            int attempts = 0;

            while (nextDate <= DateTime.Now && attempts < maxAttempts)
            {
                if (material.IsHoliday && material.Holiday.HasValue)
                {
                    int nextYear = nextDate.Year + 1;
                    nextDate = GetHolidayDate(material.Holiday.Value, nextYear);
                    nextDate = nextDate.Date + CalculateTime(material.AgeGroup);
                }
                else
                {
                    nextDate = nextDate.AddDays(1);
                    TimeSpan targetTime = CalculateTime(material.AgeGroup);
                    nextDate = nextDate.Date + targetTime;

                    var (seasonStart, seasonEnd) = GetSeasonDateRange(material.Season, nextDate.Year);
                    if (nextDate.Date > seasonEnd)
                    {
                        (seasonStart, seasonEnd) = GetSeasonDateRange(material.Season, nextDate.Year + 1);
                        int randomDays = _random.Next(0, (seasonEnd - seasonStart).Days);
                        nextDate = seasonStart.AddDays(randomDays).Date + targetTime;
                    }
                }
                attempts++;
            }

            return nextDate;
        }
    }
}
