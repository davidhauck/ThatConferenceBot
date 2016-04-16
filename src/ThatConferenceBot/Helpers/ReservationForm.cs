using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MyFirstBotApplication.Enums;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using MyFirstBotApplication.Domain;
using MyFirstBotApplication.Domain.Models;

namespace MyFirstBotApplication.Helpers
{
	[Serializable]
	public class ReservationForm
	{
       
		public DateTime? ReservationStartDate { get; set; }
		public DateTime? ReservationEndDate { get; set; }
		public MyFirstBotApplication.Enums.Campsite Campsite { get; set; }

		public static IForm<ReservationForm> BuildForm()
		{
			DateTime possibleEndDate = DateTime.MinValue;
			return new FormBuilder<ReservationForm>()
				.Message("We will create you a reservation!")
				.Field(nameof(ReservationForm.ReservationStartDate),
					validate: async (state, response) =>
					{
						DateTime chosenDate = DateTime.Parse(response.ToString());
						ValidateResult result = new ValidateResult()
						{
							IsValid = true
						};
						if (!await IsDateAvailable(chosenDate))
							result.IsValid = false;
						return result;
					})
				.Field(nameof(ReservationForm.ReservationEndDate),
					validate: async (state, response) =>
					{
						DateTime chosenDate = DateTime.Parse(response.ToString());
						ValidateResult result = new ValidateResult()
						{
							IsValid = true
						};
						return result;
					})
				.Field(nameof(ReservationForm.Campsite))
				.OnCompletionAsync(MakeReservation)
				.Build();
		}

		private static async Task<bool> IsDateAvailable(DateTime date)
		{
			await Task.Delay(10);
			return true;
		}

		private static DateTime GetPossibleEndDateForStartDate(DateTime value)
		{
			return value + TimeSpan.FromDays(7);
		}

		private static Task MakeReservation(IDialogContext context, ReservationForm state)
		{
            ThatConferenceBotDbContext dbContext = new ThatConferenceBotDbContext();

       //TODO: have to change this to reference Campsite.Id... There is no Id in the enum
      bool isCampsiteInAReservation = dbContext.Reservations.Where(r => r.Campsite.Name == state.Campsite.ToString()).Any() ;
            if (isCampsiteInAReservation)
            {
                List<Reservation> reservations = dbContext.Reservations.Where(r => r.Campsite.Name == state.Campsite.ToString()).ToList();

                var datesBooked = new List<DateTime>();
                foreach (Reservation r in reservations)
                {
                    for (var dt = r.ArrivalDate; dt <= r.DepartueDate; dt = dt.AddDays(1))
                    {
                        datesBooked.Add(dt);
                    }
                }
              
                var datesRequested = new List<DateTime>();

                for (var date = (DateTime)state.ReservationStartDate; date <= (DateTime)state.ReservationEndDate; date = date.AddDays(1))
                {
                    if (date != state.ReservationEndDate)
                    {
                        datesRequested.Add(date);
                    }
                }
               
                foreach (DateTime dt in datesBooked)
                {
                    bool isDateBooked  = datesRequested.Contains(dt);
                }
             

            }
            throw new NotImplementedException();
		}
	}
}