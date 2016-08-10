using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ThatConferenceBot.Forms
{
	[Serializable]
	public class ReservationForm
	{

		public DateTime? ReservationStartDate { get; set; }
		public DateTime? ReservationEndDate { get; set; }
		public Campsite Campsite { get; set; }

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
							IsValid = true,
							Value = response
						};
						if (!await IsDateAvailable(chosenDate))
							result.IsValid = false;
						return result;
					})
				.Field(nameof(ReservationForm.ReservationEndDate),
					validate: async (state, response) =>
					{
						DateTime chosenDate = DateTime.Parse(response.ToString());
						if (!(await IsEndDateValid(state.ReservationStartDate, response as DateTime?)))
							return new ValidateResult { IsValid = false, Feedback = "End date must be after start date and at most a week after the start date." };
						ValidateResult result = new ValidateResult()
						{
							IsValid = true,
							Value = response
						};
						return result;
					})
				.Field(nameof(ReservationForm.Campsite))
				.OnCompletion(MakeReservation)
				.Build();
		}

		private static async Task<bool> IsDateAvailable(DateTime date)
		{
			await Task.Delay(10);
			return true;
		}

		private static async Task<bool> IsEndDateValid(DateTime? start, DateTime? end)
		{
			if (start == null || end == null)
				return false;
			await Task.Delay(10);
			if (end > start && end < start?.AddDays(7))
				return true;
			return false;
		}

		private static async Task MakeReservation(IDialogContext context, ReservationForm state)
		{
			await context.PostAsync($"Reservation successfully created from {state.ReservationStartDate.Value.ToShortDateString()} to {state.ReservationEndDate.Value.ToShortDateString()} in campsite {state.Campsite}!");
		}
	}
}