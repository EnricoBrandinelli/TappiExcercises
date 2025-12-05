using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Matrix
{
    public class LabManager
    {
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public int TotalSlots { get; private set; }
        public DayOfWeek[] OpeningDays { get; private set; }
        public CourseName[,] Bookings { get; private set; }
        public Hole[][] Holes { get; private set; }

        public LabManager(TimeOnly startTime, TimeOnly endTime, DayOfWeek[] openingDays)
        {
            if (startTime >= endTime) throw new ArgumentException("Start time must be before end time.");
            StartTime = startTime;
            EndTime = endTime;
            OpeningDays = openingDays;
            TotalSlots = EndTime.Hour - StartTime.Hour;
            Bookings = new CourseName[openingDays.Length, TotalSlots];
            Holes = new Hole[OpeningDays.Length][];
        }
        public bool CheckBookingAvailability(Booking newBooking)
        {
            int dayIndex = GetDayIndex(newBooking.DayOfWeek);
            if (dayIndex == -1)
                return false;

            int requestedDurationSlots = newBooking.Duration;
            int minStartSlotIndex = FromHourToIndex(newBooking.StartTime.Hour);
            int maxStartSlotIndex = TotalSlots - requestedDurationSlots;

            if (minStartSlotIndex >= TotalSlots || maxStartSlotIndex < 0)
                return false;

            int startCandidate = minStartSlotIndex;
            bool bookingFound = false;
            while (startCandidate < maxStartSlotIndex && !bookingFound)
            {
                bool isSlotAvailable = true;
                int currentSlotIndex = startCandidate;
                while (currentSlotIndex < currentSlotIndex + requestedDurationSlots && isSlotAvailable)
                {
                    if (Bookings[dayIndex, currentSlotIndex] != CourseName.Available)
                    {
                        isSlotAvailable = false;
                        startCandidate = currentSlotIndex;
                    }
                    if (isSlotAvailable)
                        currentSlotIndex++;
                }
                if (!isSlotAvailable)
                    startCandidate++;
                else
                    bookingFound = true;
            }
            return bookingFound;
        }

        public void RegisterBooking(Booking booking)
        {
            bool availability = CheckBookingAvailability(booking);
            if (availability == false)
                throw new ArgumentException("There is no availability for your booking");

            int startindex = FromHourToIndex(booking.StartTime.Hour);
            int endindex = startindex + booking.Duration;
            int dayindex = GetDayIndex(booking.DayOfWeek);

            bool flag = false;
            bool reservationmade = true;
            for(int i = startindex; i<=endindex || !flag; i++)
            {
                endindex = i + booking.Duration;

                for(int a = i; a<=endindex;a++)
                {
                    if (Bookings[dayindex, a] != CourseName.Available)
                        reservationmade = false;                   
                }

                if(reservationmade)
                {
                    while(i<=endindex)
                    {
                        Bookings[dayindex, i] = booking.CourseName;
                    }
                    flag = true;
                }

            }
        }

        private void GetHoles(CourseName[,] lab)
        {
            List<int> counts = new List<int>();
            List<int> indexes = new List<int>();
            int count = 0;

            for(int r = 0; r<lab.GetLength(0); r++)
            {
                count = 0;
                counts.Clear();
                indexes.Clear();
                for(int i = 0; i<lab.GetLength(1); i++)
                {
                    if (lab[r, i] == CourseName.Available)
                    {
                        if (count == 0)
                            indexes.Add(i);

                        count++;                       
                    }                        
                    else
                    {
                        if (count != 0)
                            counts.Add(count);

                        count = 0;
                    }                                           
                }

                if (count != 0)
                    counts.Add(count);

                Holes[r] = new Hole[counts.Count];

                for(int i = 0; i < Holes[r].GetLength(1); i++)
                {
                    Holes[r][i] = new Hole(counts[i], indexes[i]);
                }
            }           
        }


        private int GetDayIndex(DayOfWeek day)
        {
            for (int i = 0; i < OpeningDays.Length; i++)
            {
                if (OpeningDays[i] == day)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FromIdxToHour(int idx)
        {
            return idx + StartTime.Hour;
        }

        public int FromHourToIndex(int hour)
        {
            return hour - StartTime.Hour;
        }
    }
}
