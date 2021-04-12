using System;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<GroupViewModel> Events = new List<EventViewModel>{
            new GroupViewModel {Id = 0, Title = "First Presentation", Description = "Simple Description", Date = DateTime.Now.AddMonths(-2), Location="IntelliTect Office", SpeakerId = 0},
            new GroupViewModel {Id = 1, Title = "Second Presentation", Description = "Another simple description", Date = DateTime.Now.AddMonths(-1), Location="IntelliTect Office", SpeakerId = 1},
        };

        public static List<UserViewModel> Speakers = new List<SpeakerViewModel>{
            new SpeakerViewModel {Id = 0, FirstName = "Inigo", LastName = "Montoya", EmailAddress = "Inigo.Montoya@princessbride.com"},
            new SpeakerViewModel {Id = 1, FirstName = "Princess", LastName = "Buttercup", EmailAddress = "Inigo.Montoya@princessbride.com"},
        };
        public static List<GiftViewModel> Speakers = new List<SpeakerViewModel>{
            new SpeakerViewModel {Id = 0, FirstName = "Inigo", LastName = "Montoya", EmailAddress = "Inigo.Montoya@princessbride.com"},
            new SpeakerViewModel {Id = 1, FirstName = "Princess", LastName = "Buttercup", EmailAddress = "Inigo.Montoya@princessbride.com"},
        };
    }
}