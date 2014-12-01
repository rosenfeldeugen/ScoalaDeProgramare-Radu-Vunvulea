using System;
//CR: Bad namespace
namespace HolidayPlanner.Requests
{
    //CR:If you had to add this comment, then something is no quite OK.
    // EmailConnector class responsibility is alto to resolve the 'From' field. 
    public class EmailConnector : IConnector<Email>
    {
        public void Send(Email email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email", "Email cannot be null");

            }

            //SMTP .NET library call
        }
    }
}