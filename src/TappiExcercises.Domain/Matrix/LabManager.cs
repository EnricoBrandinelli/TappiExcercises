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

        private void GetHoles(CourseName[,] lab)
        {
            List<int> count = new List<int> ();
            int counts = 0;

            for(int r = 0; r<lab.GetLength(0); r++)
            {
                for(int i = 0; i<lab.GetLength(1); i++)
                {
                    if (lab[r, i] == CourseName.Available)
                        counts++;
                    else
                    {
                        if (counts != 0)
                            count.Add(counts);

                        counts = 0;
                    }                                           
                }
                Holes[r] = new Hole[count.Count];
            }

            for(int k = 0; k<Holes.GetLength(0); k++)
            {
                for(int u=0;u<Holes.GetLength(1);u++)
                {
                    Holes[k][u] = new Hole()
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
