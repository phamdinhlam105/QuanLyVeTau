using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public static class SeedData
    {
        public static void Seed()
        {
            //seat
            Seat seat1 = new Seat { Id = 1, Name = "Ghe 1", Status = 1 };
            Seat seat2 = new Seat { Id = 2, Name = "Ghe 2", Status = 1 };
            Seat seat3 = new Seat { Id = 3, Name = "Ghe 3", Status = 1 };
            Seat seat4 = new Seat { Id = 4, Name = "Ghe 4", Status = 1 };
            AllDataContext.AllSeats.Add(seat1);
            AllDataContext.AllSeats.Add(seat2);
            AllDataContext.AllSeats.Add(seat3);
            AllDataContext.AllSeats.Add(seat4);
            List<Seat> seats1 = new List<Seat> { seat1.Clone(), seat2.Clone(), seat3.Clone(), seat4.Clone() };
            List<Seat> seats2 = new List<Seat> { seat1.Clone(), seat2.Clone(), seat3.Clone(), seat4.Clone() };
            List<Seat> seats3 = new List<Seat> { seat1.Clone(), seat2.Clone(), seat3.Clone(), seat4.Clone() };
            List<Seat> seats4 = new List<Seat> { seat1.Clone(), seat2.Clone(), seat3.Clone(), seat4.Clone() };


            //coach
            Coach coach1 = new Coach { Id = 1, Name = "Toa 1", Seats = new List<Seat>(seats1), Status = 1 };
            Coach coach2 = new Coach { Id = 2, Name = "Toa 2", Seats = new List<Seat>(seats2), Status = 1 };
            Coach coach3 = new Coach { Id = 3, Name = "Toa 3", Seats = new List<Seat>(seats3), Status = 1 };
            Coach coach4 = new Coach { Id = 4, Name = "Toa 4", Seats = new List<Seat>(seats4), Status = 1 };
            AllDataContext.AllCoaches.Add(coach1);
            AllDataContext.AllCoaches.Add(coach2);
            AllDataContext.AllCoaches.Add(coach3);
            AllDataContext.AllCoaches.Add(coach4);
            List<Coach> coaches1 = new List<Coach> { coach1.Clone(), coach2.Clone(), coach3.Clone(), coach4.Clone() };
            List<Coach> coaches2 = new List<Coach> { coach1.Clone(), coach2.Clone(), coach3.Clone(), coach4.Clone() };
            List<Coach> coaches3 = new List<Coach> { coach1.Clone(), coach2.Clone(), coach3.Clone(), coach4.Clone() };

            //station
            Station station1 = new Station { Id = "1", Name = "Nha Trang", Address = "nha trang", City = "Nha Trang" };
            Station station2 = new Station { Id = "2", Name = "Ha Noi", Address = "Ha Noi", City = "Ha Noi" };
            Station station3 = new Station { Id = "3", Name = "Hue", Address = "Hue", City = "Hue" };
            AllDataContext.AllStations.Add(station1);
            AllDataContext.AllStations.Add(station2);
            AllDataContext.AllStations.Add(station3);

            //stationfrom
            StationFrom stationFrom1 = new StationFrom { Id = "1", StationStart = station1, StationsPassed = new List<Station> { station2, station3 } };
            StationFrom stationFrom2 = new StationFrom { Id = "2", StationStart = station2, StationsPassed = new List<Station> { station1, station3 } };
            StationFrom stationFrom3 = new StationFrom { Id = "3", StationStart = station3, StationsPassed = new List<Station> { station1, station2 } };
            AllDataContext.AllStationFroms.Add(stationFrom1);
            AllDataContext.AllStationFroms.Add(stationFrom2);
            AllDataContext.AllStationFroms.Add(stationFrom3);

            //train
            Train train1 = new Train { Id = 1, Coaches = new List<Coach>(coaches1), Name = "SE1", Status = 1 };
            Train train2 = new Train { Id = 2, Coaches = new List<Coach>(coaches2), Name = "TN5", Status = 1 };
            Train train3 = new Train { Id = 3, Coaches = new List<Coach>(coaches3), Name = "SE4", Status = 1 };
            AllDataContext.AllTrains.Add(train1);
            AllDataContext.AllTrains.Add(train2);
            AllDataContext.AllTrains.Add(train3);

            //schedule
            ScheduleBuilder scheduleBuilder = new ScheduleBuilder();
            Schedule schedule1 = scheduleBuilder
                .SetId()
                .SetStation(station2, station1)
                .SetTrain(train1)
                .SetTime(DateTime.Parse("2/12/2023 14:30"), DateTime.Parse("2/14/2023 14:30"))
                .SetStatus(1)
                .Build();
            Schedule schedule2 = scheduleBuilder
                 .SetId()
                .SetStation(station1, station3)
                .SetTrain(train2)
                .SetTime(DateTime.Parse("2/12/2023 16:30"), DateTime.Parse("2/13/2023 5:30"))
                .SetStatus(1)
                .Build();
            Schedule schedule3 = scheduleBuilder
               .SetId()
              .SetStation(station2, station1)
              .SetTrain(train3)
              .SetTime(DateTime.Parse("2/14/2023 18:30"), DateTime.Parse("2/15/2023 20:30"))
              .SetStatus(1)
              .Build();
            AllDataContext.AllSchedules.Add(schedule1);
            AllDataContext.AllSchedules.Add(schedule2);
            AllDataContext.AllSchedules.Add(schedule3);

            //ticket
            TicketBuilder ticketBuilder = new TicketBuilder();
            TrainTicket ticket1 = ticketBuilder
                .SetId()
                .SetCustomer(123456, "Nguyen Van A", 9874213)
                .SetTrainInfo(schedule1)
                .SetPosition(coach3, seat1)
                .SetCreatedDate(DateTime.Parse("1/20/2023 18:30"))
                .Build();
            TrainTicket ticket2 = ticketBuilder
               .SetId()
               .SetCustomer(123456, "Pham Dinh Lam", 9874213)
               .SetTrainInfo(schedule1)
               .SetPosition(coach3, seat2)
               .SetCreatedDate(DateTime.Parse("2/01/2023 18:30"))
               .Build();
            TrainTicket ticket3 = ticketBuilder
               .SetId()
               .SetCustomer(123456, "Nguyen Thi B", 9874213)
               .SetTrainInfo(schedule1)
               .SetPosition(coach3, seat3)
               .SetCreatedDate(DateTime.Parse("1/14/2023 18:30"))
               .Build();
            TrainTicket ticket4 = ticketBuilder
              .SetId()
              .SetCustomer(123456, "Nguyen Thi C", 9874213)
              .SetTrainInfo(schedule1)
              .SetPosition(coach3, seat4)
              .SetCreatedDate(DateTime.Parse("1/14/2023 18:30"))
              .Build();

            AllDataContext.AllTickets.Add(ticket1);
            AllDataContext.AllTickets.Add(ticket2);
            AllDataContext.AllTickets.Add(ticket3);
            AllDataContext.AllTickets.Add(ticket4);

            ScheduleService scheduleService = new ScheduleService();
            scheduleService.UpdateSchedule(ticket1);
            scheduleService.UpdateSchedule(ticket2);
            scheduleService.UpdateSchedule(ticket3);
            scheduleService.UpdateSchedule(ticket4);
        }
    }
}
