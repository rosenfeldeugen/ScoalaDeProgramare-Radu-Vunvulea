namespace HolidayPlanner.Requests
{
    //CR: What's happened after executing SubmitRequest? The instance will become SubmitedHolidayRequest? ;)
    public class UnsubmitedHolidayRequest : HolidayRequest
    {
        public UnsubmitedHolidayRequest(IConnectorResolver connectorResolver) 
            : base(connectorResolver)
        {
        }

        public void SubmitRequest()
        {
            Email holidayRequestEmail = ConvertRequestToEmailForManager();
            IConnector<Email> emailConnector = connectorResolver.Resolve<Email>();
            emailConnector.Send(holidayRequestEmail);
        }

        private Email ConvertRequestToEmailForManager()
        {
            Email holidayRequestEmail = new Email()
            {
                Body =
                    string.Format(
                        "some custom message and string format with using HolidayRequest properties {0} {1} {2} {3}",
                        EmployeeEmail,
                        EmployeeName,
                        From,
                        To),
                Title = string.Format("New Holiday Request from {0}", EmployeeName),
            };
            holidayRequestEmail.ReceiverCollection.Add(ManagerEmail);

            return holidayRequestEmail;
        }
    }
}