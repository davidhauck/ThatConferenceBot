using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MyFirstBotApplication.Enums;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace MyFirstBotApplication.Helpers
{
	[Serializable]
	public class ReservationForm
	{
		public DateTime? ReservationStartDate { get; set; }
		public DateTime? EndDate
		{
			get
			{
				return ReservationStartDate + TimeSpan.FromDays(7);
			}
		}
		public DateTime? ReservationEndDate { get; set; }
		public Campsite Campsite { get; set; }

		public static IForm<ReservationForm> BuildForm()
		{
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
				.Message("Maximum End Date: {ReservationStartDate}")
				.Field(nameof(ReservationForm.ReservationEndDate))
				.Field(nameof(ReservationForm.Campsite))
				.AddRemainingFields()
				.Message("Thanks for reserving a campsite!")
				.OnCompletionAsync(MakeReservation)
				.Build();
		}

		private static async Task<bool> IsDateAvailable(DateTime date)
		{
			await Task.Delay(10);
			return true;
		}

		private static Task MakeReservation(IDialogContext context, ReservationForm state)
		{
			throw new NotImplementedException();
		}
	}
}