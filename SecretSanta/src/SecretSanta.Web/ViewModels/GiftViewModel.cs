using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Web.ViewModels
{
    public class GiftViewModel
    {
        public int Id {get; set;}
        [Required]
        public string Title {get; set;} = "";
        public string Description {get; set;} = "";
        public string Url {get; set;} = "";
        public uint Priority {get; set;} = 1;
        public uint UserReference {get; set;}
    }
}