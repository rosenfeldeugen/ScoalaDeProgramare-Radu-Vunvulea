using System;

namespace HolidayPlanner.Requests
{
    //CR: This is a request for a new employee?
    public class NewEmployeeHolidayRequest : HolidayRequest
    {
        public NewEmployeeHolidayRequest(Email email, IConnectorResolver connectorResolver)
            : base(connectorResolver)
        {
            SetRequestInformation(email);
        }

        private void SetRequestInformation(Email email)
        {
            // parse the email content and retrives holiday request information
            EmployeeName = email.Title;
            EmployeeEmail = "EmployeeEmail";
            ManagerEmail = "ManagerEmail";
            From = DateTime.Now.AddDays(3);
            To = From.AddDays(7);
        }

        public void Approve()
        {
            Email emailToHR = ConvertRequestToEmailForHR();
            //CR: why not emailToHR.Send()?
            SendEmail(emailToHR);
        }

        public void Reject()
        {
            Email emailToEmployee = ConvertRejectRequestToEmailForEmployee();
            //CR: why not emailToEmployee.Send()?
            SendEmail(emailToEmployee);
        }

        private Email ConvertRequestToEmailForHR()
        {
            Email holidayRequestEmail = new Email()
            {
                Body =
                    string.Format(
                        "YES {0} {1} {2} {3}",
                        EmployeeEmail,
                        EmployeeName,
                        From,
                        To),
                Title = string.Format("Holiady Request accepted from {0}", EmployeeName),
            };
            holidayRequestEmail.ReceiverCollection.Add(ManagerEmail);

            return holidayRequestEmail;
        }

        private Email ConvertRejectRequestToEmailForEmployee()
        {
            Email holidayRequestEmail = new Email()
            {
                Body =
                    string.Format(
                        "NO {0} {1} {2} {3}",
                        EmployeeEmail,
                        EmployeeName,
                        From,
                        To),
                Title = "Holiday Request rejected"
            };
            holidayRequestEmail.ReceiverCollection.Add(ManagerEmail);

            return holidayRequestEmail;
        }

    }
}