using System;
using System.Linq;

namespace Lab6.Migrations
{
    public class DummyData
    {
        public static void Initialize(Lab6Context db)
        {
            if (!db.Parties.Any())
            {
                db.Parties.Add(new Party
                {
                    PartyName = "Bithday Party",
                    PartyDate = Convert.ToDateTime("1989/09/19"),
                    ExpectedNumberOfGuests = 50,
                    Address = "@night"
                });
                db.Parties.Add(new Party
                {
                    PartyName = "Halloween Party",
                    PartyDate = Convert.ToDateTime("2017/10/31"),
                    ExpectedNumberOfGuests = 30,
                    Address = "@home"
                });
                db.Parties.Add(new Party
                {
                    PartyName = "Christmas Party",
                    PartyDate = Convert.ToDateTime("2017/12/25"),
                    ExpectedNumberOfGuests = 100,
                    Address = "@street"
                });
                db.Parties.Add(new Party
                {
                    PartyName = "New Year's Eve Party",
                    PartyDate = Convert.ToDateTime("2017/12/31"),
                    ExpectedNumberOfGuests = 400,
                    Address = "@street"
                });
                db.SaveChanges();
            }
        }
    }
}