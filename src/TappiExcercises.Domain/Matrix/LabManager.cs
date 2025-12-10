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
        public int CheckBookingAvailability(Booking newBooking)
        {
            int dayIndex = GetDayIndex(newBooking.DayOfWeek);
            if (dayIndex == -1)
                return -1;

            int requestedDurationSlots = newBooking.Duration;
            int minStartSlotIndex = FromHourToIndex(newBooking.StartTime.Hour);
            int maxStartSlotIndex = TotalSlots - requestedDurationSlots;

            if (minStartSlotIndex >= TotalSlots || maxStartSlotIndex < 0)
                return -1;

            int startCandidate = minStartSlotIndex;
            bool bookingFound = false;
            while (startCandidate < maxStartSlotIndex && !bookingFound)
            {
                bool isSlotAvailable = true;
                int currentSlotIndex = startCandidate;
                while (currentSlotIndex < startCandidate + requestedDurationSlots && isSlotAvailable)
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
            if (bookingFound)
                return startCandidate;
            else
                return -1;
        }

        public void RegisterBooking(Booking booking)
        {
            int dayindex = GetDayIndex(booking.DayOfWeek);
            int availability = CheckBookingAvailability(booking);
            if(availability != -1)
            {
                for(int i = availability; i<availability+booking.Duration; i++)
                {
                    Bookings[dayindex, i] = booking.CourseName;
                }
            }
                
        }

        private void SmartRegister(int StartIndex, int row, int Duration,  CourseName coursename)
        {
            for(int i = StartIndex; i<StartIndex+Duration; i++)
            {
                Bookings[row, i] = coursename;
            }
        }

        public void SmartBooking(Booking booking)
        {
            int availabity = CheckBookingAvailability(booking);
            if(availabity != -1)
            {
                int offset = 0;
                int row = 0;
                int count = 0;
                bool flag = true;
                foreach (Hole[] hole in Holes)
                {
                    foreach(Hole h in hole)
                    {
                        if(h.Lenght == booking.Duration)
                        {
                            SmartRegister(h.OffSet, h.Row, booking.Duration,  booking.CourseName);
                            flag = false;
                            break;
                        }

                        if (count == 0 && h.Lenght > booking.Duration)
                        {
                            offset = h.OffSet;
                            row = h.Row;
                            count++;
                        }
                        else if (count != 0 && h.Lenght > booking.Duration && h.Lenght < count)
                        {
                            offset = h.OffSet;
                            row = h.Row;
                        }
                    }

                    if (!flag)
                        break;
                }

                if(flag)
                    SmartRegister(offset, row, booking.Duration,  booking.CourseName);
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
                    Holes[r][i] = new Hole(counts[i], indexes[i], r);
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
