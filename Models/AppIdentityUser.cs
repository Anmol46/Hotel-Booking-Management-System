using DtoModel;
using Microsoft.AspNetCore.Identity;

namespace Models
{

    public class AppIdentityUser : IdentityUser
    {

        public override string Id { get; set; }

        public override string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string PhoneNumber { get; set; }

        public override string Email { get; set; }

        public virtual List<Booking> Bookings { get; set; }


        public void UpdateUserEmail(string NewEmail)
        {
            this.Email = NewEmail;
        }

    }

}