using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime Id { get; set; }
        [Key]
        [StringLength(7)]
        public string PasseportNumber { get; set; }

        public string EmailAddress { get; set; }

        [MinLength(3, ErrorMessage = "min 3")]
        [MaxLength(25,ErrorMessage ="max 25")]
            public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string TelNumber { get; set; }
        [Display(Name ="Date Of Birth")]
        public DateTime BirthDate { get; set; }
        public ICollection<Flight> Flights { get; set; }
        
        public bool CheckProfile(string prenom, string nom,string email=null)
        {
            if (email != null)
                return (prenom == FirstName && nom == LastName && email == EmailAddress);
            else
                return (prenom == FirstName && nom == LastName);
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");

        }

    }

}
