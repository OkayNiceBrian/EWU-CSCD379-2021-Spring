using System;
using System.Collections.Generic;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<GroupViewModel> Groups = new List<GroupViewModel>{
            new GroupViewModel {Id = 0, GroupName = "First Group"},
            new GroupViewModel {Id = 1, GroupName = "Second Group"},
        };

        public static List<UserViewModel> Users = new List<UserViewModel>{
            new UserViewModel {Id = 0, FirstName = "Inigo", LastName = "Montoya"},
            new UserViewModel {Id = 1, FirstName = "Princess", LastName = "Buttercup"},
        };
        
        public static List<GiftViewModel> Gifts = new List<GiftViewModel>{
            new GiftViewModel {Id = 0, Title = "Sword", Description = "A cool sword", Url = "Amazon.com/sword", Priority = 1, UserReference = 1},
            new GiftViewModel {Id = 1, Title = "Peppermint Butler", Description = "A new peppermint butler", Url = "Amazon.com/pmb", Priority = 1, UserReference = 2},
        };
    }
}